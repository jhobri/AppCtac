using Back.Ctac.Dto.Base;

namespace Back.Ctac.Dto.Nota
{
    public class GetNotaEstudianteRequest : IeBase
    {

        public string NivelId { get; set; }
        public string GradoId { get; set; }
    }
}