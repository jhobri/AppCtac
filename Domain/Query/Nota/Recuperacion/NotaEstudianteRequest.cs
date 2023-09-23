using Back.Ctac.Dto.Base;

namespace Back.Ctac.Query.Nota.Recuperacion
{
    public class NotaEstudianteRequest : IeBase
    {
        public string NivelId { set; get; }
        public string GradoId { get; set; }
    }
}