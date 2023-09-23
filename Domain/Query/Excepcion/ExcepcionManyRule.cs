using Minedu.Fw.Domain.SeedWork;
using Minedu.Fw.General.Response.Status;

namespace Back.Ctac.Query.Excepcion
{
    public class ExcepcionManyRule : IBusinessRule
    {
        private readonly IEnumerable<MessageStatusResponse> _data;
        private readonly string _accion;

        public ExcepcionManyRule(IEnumerable<MessageStatusResponse> _validaciones, string accion)
        {
            _data = _validaciones;
            _accion = accion;

        }

        public string Message { get; set; } = string.Empty;

        public bool Failed()
        {

            if (_data.Any())
            {
                var sb = new System.Text.StringBuilder();
                _data.ToList().ForEach(x =>
                {

                    sb.AppendLine(x.Message);
                });

                //Message = $"{_data.FirstOrDefault().Message} {_accion}";
                Message = $"{sb.ToString()} {_accion}";
                return true;
            }
            return false;
        }
    }
}