namespace Back.Ctac.Data.Setting
{
    internal static class Procedure
    {

        internal static class Query
        {

            internal const string USP_SEL_ACCESO_MODULO_POR_ANIO = "[seguridad].[USP_SEL_ACCESO_MODULO_POR_ANIO]";
            internal const string USP_SEL_ACCESO_MODULO_POR_GRADO = "[seguridad].[USP_SEL_ACCESO_MODULO_POR_GRADO]";

            #region RECUPERACION-RESPONSABLE-EVALUACION
            internal const string USP_SEL_GRADO_AREA_RESPONSABLE = "evaluacion.USP_SEL_GRADO_AREA_RESPONSABLE";
            #endregion

            internal const string USP_SEL_GRADO_BY_IE = "procesamiento.USP_SEL_GRADO_BY_IE";
            internal const string USP_SEL_ESTUDIANTES_BY_IE_EVALUADOR = "evaluacion.USP_SEL_ESTUDIANTES_BY_IE_EVALUADOR";
            internal const string USP_SEL_ESTUDIANTES_BY_IE_EVALUADOR_MULTIPLE = "evaluacion.USP_SEL_ESTUDIANTES_BY_IE_EVALUADOR_MULTIPLE";

            internal const string USP_SEL_ESTUDIANTES_SECCION_BY_ID = "evaluacion.USP_SEL_ESTUDIANTES_SECCION_BY_ID";
            internal const string USP_SEL_ESTUDIANTE_AREA_DESPROBADO_BY_IE_EVALUADOR = "evaluacion.USP_SEL_ESTUDIANTE_AREA_DESPROBADO_BY_IE_EVALUADOR";
            internal const string USP_SEL_IE_EVALUACION_BY_ANIO = "procesamiento.USP_SEL_IE_EVALUACION_BY_ANIO";

            internal const string USP_SEL_ENUMERADO_BY_TIPO = "[configuracion].[USP_SEL_ENUMERADO_BY_TIPO]";
            internal const string USP_SEL_NOTA_ESTUDIANTE_COMPETENCIA = "evaluacion.USP_SEL_NOTA_ESTUDIANTE_COMPETENCIA";
            internal const string USP_SEL_NOTA_ESTUDIANTE_REGULAR_BY_IE_EVALUADOR = "evaluacion.USP_SEL_NOTA_ESTUDIANTE_REGULAR_BY_IE_EVALUADOR";


        }

        internal static class Command
        {
            internal const string USP_INS_IE_EVALUACION = "[evaluacion].[USP_INS_IE_EVALUACION]";
            internal const string USP_INS_GRADO_AREA_RESPONSABLE = "evaluacion.USP_INS_GRADO_AREA_RESPONSABLE";
            internal const string USP_UPD_AUTORIZACION_EVALUACION_EXTERNA = "evaluacion.USP_UPD_AUTORIZACION_EVALUACION_EXTERNA";




        }
    }
}