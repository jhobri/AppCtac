using Back.Ctac.Dto.TipoRecuperacion;

namespace Back.Ctac.Dto.Estudiante
{
    public class EstudianteTipoRecuperacionResponse
    {
        public int PersonaId { get; set; }
        public string Nombres { get; set; }
        public string CodigoEstudiante { get; set; }
        public TipoRecuperacionResponse TipoRecuperacion { get; set; }
    }
}
