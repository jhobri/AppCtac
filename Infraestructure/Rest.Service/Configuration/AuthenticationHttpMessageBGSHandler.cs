using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Minedu.Fw.General.Models.Configurations;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Back.Ctac.Rest.Service.Configuration
{
    public class AuthenticationHttpMessageBGSHandler<T> : DelegatingHandler where T : class
    {
        private const string Scheme = "Bearer";
        private readonly JwtSiagieMsaConfiguration _jwtSiagieMsaConfiguration;
        private readonly JwtPadronConfiguration _jwtPadronConfiguration;
        private readonly RequestConfiguration _requestConfiguration;

        public AuthenticationHttpMessageBGSHandler(
            JwtSiagieMsaConfiguration jwtSiagieMsaConfiguration,
            JwtPadronConfiguration jwtPadronConfiguration,
            IOptions<RequestConfiguration> requestConfig
            )
        {
            _jwtSiagieMsaConfiguration = jwtSiagieMsaConfiguration;
            _jwtPadronConfiguration = jwtPadronConfiguration;
            _requestConfiguration = requestConfig.Value;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var microservice = typeof(T).Name;
            var jwtBuild = new JwtConfigurationResponse();
            var loginApi = await LoginAsync();
            switch (microservice)
            {
                case "IPadronApiGateway":
                    jwtBuild = await GenerarJwtPadronMsa();
                    break;

                case "ISiagieMsaIeAdministracionApiGateway":
                case "ISiagieMsaEvaluacionPeriodoApiGateway":
                case "ISiagieMsaProcesoApiGateway":
                case "ISiagieMsaEvaluacionPeriodoGeneralApiGateway":
                case "ISiagieMsaMaestroApiGateway":
                    jwtBuild = await GenerarJwtSiagieMsa(loginApi.Rol, loginApi.User);
                    break;

                default:
                    break;
            }
            var jwt = jwtBuild;
            request.Headers.Authorization = new AuthenticationHeaderValue(Scheme, jwt.Token);
            request.Headers.Add(_requestConfiguration.KeySHAJwtRsaParameterName, jwt.key);
            request.Headers.Add(_requestConfiguration.userParameterName, loginApi.User);
            return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
        }

        public async Task<JwtConfigurationResponse> GenerarJwtSiagieMsa(string rol, string usuario)
        {
            try
            {
                string token = "";
                string sha = "";
                using (RSA rsa = RSA.Create())
                {
                    rsa.ImportRSAPrivateKey(_jwtSiagieMsaConfiguration.KeyPrivateByte, out _);

                    var signingCredentials = new SigningCredentials(new RsaSecurityKey(rsa), SecurityAlgorithms.RsaSha256)
                    {
                        CryptoProviderFactory = new CryptoProviderFactory { CacheSignatureProviders = false }
                    };

                    var now = DateTime.Now;
                    var unixTimeSeconds = new DateTimeOffset(now).ToUnixTimeSeconds();

                    var jwt = new JwtSecurityToken(
                        audience: _jwtSiagieMsaConfiguration.Audience,
                        issuer: _jwtSiagieMsaConfiguration.Issuer,
                        claims: new Claim[] {
                            new Claim(JwtRegisteredClaimNames.Iat, unixTimeSeconds.ToString(), ClaimValueTypes.Integer64),
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                            new Claim("agw", _jwtSiagieMsaConfiguration.Agw),
                            new Claim(_requestConfiguration.userTokenParameterName, usuario),
                            new Claim(_requestConfiguration.rolTokenParameterName, rol),
                            new Claim("agm", rol==_jwtSiagieMsaConfiguration.Agp?"1":"0"),
                            //new Claim(_requestConfiguration.userAppParameterName, _jwtSiagieMsaConfiguration.Agl),
                            //new Claim("user", _jwtSiagieMsaConfiguration.Agl),
                            //new Claim("rol", _jwtSiagieMsaConfiguration.Agp)
                        },
                        notBefore: now.AddSeconds(_jwtSiagieMsaConfiguration.NotBefore),
                        expires: now.AddSeconds(_jwtSiagieMsaConfiguration.Expires),
                        signingCredentials: signingCredentials
                    );

                    token = new JwtSecurityTokenHandler().WriteToken(jwt);
                    sha = await GenerarSha256(token);
                }

                return await Task.FromResult(new JwtConfigurationResponse()
                {
                    key = sha,
                    Token = token
                });
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<JwtConfigurationResponse> GenerarJwtPadronMsa()
        {
            try
            {
                string token = "";
                string sha = "";
                using (RSA rsa = RSA.Create())
                {
                    rsa.ImportRSAPrivateKey(_jwtPadronConfiguration.KeyPrivateByte, out _);

                    var signingCredentials = new SigningCredentials(new RsaSecurityKey(rsa), SecurityAlgorithms.RsaSha256)
                    {
                        CryptoProviderFactory = new CryptoProviderFactory { CacheSignatureProviders = false }
                    };

                    var now = DateTime.Now;
                    var unixTimeSeconds = new DateTimeOffset(now).ToUnixTimeSeconds();

                    var jwt = new JwtSecurityToken(
                        audience: _jwtPadronConfiguration.Audience,
                        issuer: _jwtPadronConfiguration.Issuer,
                        claims: new Claim[] {
                            new Claim(JwtRegisteredClaimNames.Iat, unixTimeSeconds.ToString(), ClaimValueTypes.Integer64),
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                            new Claim("agw", _jwtPadronConfiguration.Agw),
                            new Claim("X-WSP", _jwtPadronConfiguration.Agl),
                            new Claim("X-WSG", _jwtPadronConfiguration.Agp)
                        },
                        notBefore: now.AddSeconds(_jwtPadronConfiguration.NotBefore),
                        expires: now.AddSeconds(_jwtPadronConfiguration.Expires),
                        signingCredentials: signingCredentials
                    );

                    token = new JwtSecurityTokenHandler().WriteToken(jwt);
                }

                return await Task.FromResult(new JwtConfigurationResponse()
                {
                    key = sha,
                    Token = token
                });
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<string> GenerarSha256(string token)
        {
            var ok = await Task.Run(() =>
            {
                using (SHA256 sha256Hash = SHA256.Create())
                {
                    // ComputeHash - returns byte array
                    byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(token));

                    // Convert byte array to a string
                    StringBuilder builder = new StringBuilder();
                    for (int i = 0; i < bytes.Length; i++)
                    {
                        builder.Append(bytes[i].ToString("x2"));
                    }
                    return builder.ToString();
                }
            });
            return ok;
        }

        private async Task<LoginBGS> LoginAsync()
        {
            var ok = await Task.Run(() =>
            {
                return new LoginBGS() { Rol = _jwtSiagieMsaConfiguration.Agp, User = _jwtSiagieMsaConfiguration.Agl };
            });
            return ok;
        }
    }

    public class LoginBGS
    {
        public string User { get; set; }
        public string Rol { get; set; }
    }
}