using MediatR;

namespace Back.Ctac.Query.Enumerado
{
    public class EnumeradoQuery : IRequest<IEnumerable<EnumeradoResponse>>
    {
        public EnumeradoRequest entity;

        public EnumeradoQuery(EnumeradoRequest request)
        {
            entity = request;
        }
    }
}