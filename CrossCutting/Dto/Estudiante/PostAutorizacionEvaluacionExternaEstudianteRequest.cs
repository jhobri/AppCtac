using Back.Ctac.Dto.Base;
using System.ComponentModel;

namespace Back.Ctac.Dto.Estudiante;

public class PostAutorizacionEvaluacionExternaEstudianteRequest : InstitucionEducativaAnioBaseRequestDto
{

    //[DisplayName("El código modular destino")]
    //public string CodigoModularDestino { get; set; }



    //[DisplayName("El código grado")]
    //public string GradoId { get; set; }

    [DisplayName("El código estudiante")]
    public int? EstudianteSeccionId { get; set; }

    [DisplayName("El Nro. de resolución")]
    public string Resolucion { get; set; }

    [DisplayName("La fecha de autorización")]
    public DateTime? Fecha { get; set; }
}
