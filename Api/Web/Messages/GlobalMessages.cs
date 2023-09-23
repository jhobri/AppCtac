namespace Back.Ctac.Api.Messages
{
    public partial class GlobalMessages
    {
        public class Red
        {
            public const string StatusFalse = "La solicitud con los parámetros ingresados no ha sido satisfactoria.";
        }
        public class Require
        {
            //public const string Usuario = "Debe ingresar el usuario.";
            public const string Anexo = "Debe ingresar el anexo.";

            public const string CodigoModular = "Debe ingresar el código modular.";
            public const string IdNivel = "Debe ingresar el nivel.";
            public const string IdGrado = "Debe ingresar el grado.";
            public const string IdSeccion = "Debe ingresar la sección.";
            public const string IdSeccionFase = "Debe ingresar la sección fase.";
            public const string IdDisenioCurricular = "Debe ingresar el diseño curricular.";
            public const string IdFase = "Debe ingresar la fase.";           
            public const string IdPeriodo = "Debe ingresar el período.";
            public const string IdPeriodoPromocional = "Debe ingresar el período promocional.";
            public const string IdPeriodoEvaluacion = "Debe ingresar el período evaluación.";

            //public const string IdPersona = "Debe ingresar el código de la persona.";

            public const string IdModalidad = "Debe ingresar la modalidad.";
            public const string IdAnio = "Debe ingresar el año académico.";
            public const string IdDisenio = "Debe ingresar el diseño curricular.";
            public const string AreaId = "Debe ingresar el área.";
            public const string RolId = "Debe ingresar el rol.";
            public const string UsuarioId = "Debe ingresar el usuario.";

            public const string Estudiante = "Debe ingresar el listado de estudiante.";
            public const string Areas = "Debe ingresar área.";
            public const string PersonaId = "Debe ingresar el id del estudiante.";

            public const string NombreArchivo = "Debe ingresar el nombre del archivo.";
            public const string ByteArchivo = "Debe ingresar el contenido del archivo.";

           
            

        }

        public class ValidFormat
        {
            public const string Usuario = "El usuario debe tener solo caracteres alfanuméricos.";
            public const string Anexo = "El anexo debe tener 1 dígito.";
            public const string CodigoModular = "El código modular debe tener 7 dígitos.";
            public const string IdAnio = "El año académico debe ser mayor o igual al año 2021 y menor o igual al año actual.";
            public const string IdNivel = "En el nivel educativo el primer caracter deber ser una letra mayúscula seguido de un dígito.";
            public const string IdGrado = "El grado debe tener 2 dígitos.";
            public const string IdGradoHabilitar = "El grado debe ser numérico y mayor a 0.";
            public const string IdPeriodoEvaluacion = "El período evaluación debe ser numérico y mayor a 0.";
            
            public const string IdSeccion = "La sección debe tener 2 caracteres.";
            public const string IdSeccionGeneral = "La sección debe ser numérico y mayor a 0.";
            public const string IdDisenioCurricular = "El diseño curricular debe tener 2 dígitos.";
            public const string IdAula = "El aula debe tener 1 dígito.";
            public const string IdPeriodo = "El período debe tener 2 caracteres.";
            public const string IdPeriodoPromocional = "El período promocional es un número entero positivo.";

            public const string IdTipoPeriodo = "El período debe ser 1 caracter.";
            public const string IdTipoSede = "El tipo sede debe tener 1 dígito.";
            public const string IdSede = "La sede debe tener 1 dígito.";
            public const string IdModalidad = "La modalidad debe tener 2 dígitos.";
            public const string IdDisenio = "El diseño curricular debe tener 2 dígitos.";
            public const string AreaId = "El área debe tener entre 1 a 4 caracteres alfanuméricos.";
            public const string RolId = "El rol debe tener 3 caracteres numéricos.";
            public const string IdSeccionFase = "Sección fase debe ser numérico y mayor a 0.";
            public const string IdSeccionHabilitar = "Sección debe ser numérico y mayor a 0.";
            public const string IdPersona = "El id de la persona ser mayor a 0 y numérico.";
            public const string NombreArchivoExcel = "Nombre del archivo debe tener 40 o mas caracteres alfanuméricos.";
            public const string ExtensionNombreArchivoExcel = "El archivo subido no es un archivo excel.";
            public const string PrefijoNombreArchivoExcel = "El prefijo del archivo excel, no corresponde a la sección en proceso..";


        }

    }
}
