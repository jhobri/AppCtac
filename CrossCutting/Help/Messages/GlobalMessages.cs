namespace Back.Ctac.Transversal.Messages
{
    public static partial class GlobalMessages
    {
        public const string NINGUN_REGISTRO_ACTUALIZADO = "No se actualizó ningún registro";
        public const string NINGUN_REGISTRO_CREADO = "No se creó ningún registro.";
        public const string NINGUN_REGISTRO_ELIMINADO = "No se eliminó ningún registro.";

    }
    //public partial class MensajesInstitucionEducativa
    //{

    //    public const string Existe = "La institución educativa no se encuentra disponible o no existe.";
    //    public const string EsEba = "La institución educativa es EBA.";
    //    public const string ExisteEnDiseno = "La institución educativa no cuenta con diseño curricular para el año ingresado.";
    //}
    public static class ParametroExcel
    {
        //public const string REGISTRO_NOTAS_POR_PERIODO_NO_OK = "La configuración del Registro de Evaluación se encuentra configurado por Notas Finales. Si desea cambiarla debe ir a la opción Año escolar.";
        //public const string IE_NO_EXISTE_EN_ANIO = "La institución educativa no se encuentra disponible para el año ingresado.";
        public const string SHEET_GENERALIDADES_EXCEL_NO_EXISTE = "Información de pestaña generalidades del archvio seleccionado no se encontró.";
        public const string ExtensionNombreArchivoExcel = "El archivo subido no es un archivo excel.";

    }
    public static class MensajesIeAnio
    {
        public const string REGISTRO_NOTAS_POR_PERIODO_PROMOCIONAL_NO_OK = "La configuración del registro de evaluaciones es por notas finales. Debe realizar o solicitar el cambio a notas por período en la opción período promocional por IE.";
        public const string REGISTRO_NOTAS_POR_PERIODO_NO_OK = "La configuración del Registro de Evaluación se encuentra configurado por Notas Finales. Si desea cambiarla debe ir a la opción Año escolar.";
        public const string IE_NO_EXISTE_EN_ANIO = "La institución educativa no se encuentra disponible para el año ingresado.";
        public const string IE_SIN_CIERRE_ANIO = "La institución educativa no se encuentra aperturado.";
        public const string IE_ES_EBA = "La institución educativa es EBA.";
        public const string IE_NO_EXISTE = "La institución educativa no se encuentra disponible o no existe.";

    }
    public static class MensajesPlantillaConfiguracion
    {

        public const string PLANTILLA_NO_EXISTE_EN_ANIO_GRADO = "No existe configurado tipo plantilla excel para el grado y año seleccionado.";

    }
    public static class MensajesFase
    {
        public const string FASE_NO_EXISTE = "No existe la fase.";
        public const string PERIODO_PROMOCIONAL_NO_EXISTE = "No existe el período promocional.";

    }
    public static class MensajesGrado
    {
        public const string GRADO_NO_EXISTE = "No existe el grado.";

    }
    public static class MensajesDisenio
    {
        public const string DISENIO_NO_EXISTE = "No existe el diseño curricular.";

    }
    public static class MensajesPeriodoPromocional
    {
        public const string PERIODO_PROMOCIONAL_NO_EXISTE = "No existe el período promocional para el año seleccionado.";

    }
    public static class MensajesSeccion
    {
        //public const string SECCION_INSERTAR_OK = "La sección fue insertado correctamente.";
        //public const string SECCION_INSERTAR_NO_OK = "No es posible insertar la sección.";
        //public const string SECCION_ACTUALIZAR_OK = "La sección fue actualizado correctamente.";
        //public const string SECCION_AREA_DOCENTE_ACTUALIZAR_OK = "La sección fue actualizado correctamente.";
        //public const string SECCION_ACTUALIZAR_NO_OK = "No es posible actualizar la sección.";
        //public const string SECCION_ELIMINAR_OK = "La sección fue eliminada correctamente.";
        //public const string SECCION_ELIMINAR_NO_OK = "No es posible eliminar la sección.";
        public const string ID_SECCION_FASE_NO_EXISTE = "El identificador de la sección fase período promocional no existe.";
        public const string SECCION_NO_EXISTE = "No existe la sección.";
        public const string SECCION_CON_NOMINA = " La sección cuenta con nómina de matrícula generada o aprobada.";
        public const string DATA_EXCEL_SECCION_NO_OK = " No existe registros en el excel cargado.";
        //public const string SECCION_PERIODO_PROMOCIONAL_NO_EXISTE = "No existe el período promocional.";
        //public const string SECCION_PERIODO_EVALUACION_PROMOCIONAL_NO_EXISTE = "No existe el período evaluación de período promocional.";
        //public const string SECCION_PROGRAMA_NO_EXISTE = "No existe el programa.";
        //public const string SECCION_FORMA_ATENCION_NO_EXISTE = "No existe la forma de atención.";
        //public const string SECCION_TIPO_SEDE_NO_EXISTE = "No existe el tipo sede.";
        //public const string SECCION_SEDE_NO_EXISTE = "No existe la sede.";
        //public const string SECCION_TIENE_MATRICULA = "La sección cuenta con estudiantes matriculados.";
        //public const string SECCION_TIENE_ASISTENCIA = "La sección tiene asistencias asociadas.";
        //public const string SECCION_TIENE_EXAMEN = "La sección tiene exámenes asociados.";
        //public const string SECCION_TIENE_FORMATO_OFICIAL = "La sección tiene formatos oficiales asociados.";
        //public const string SECCION_TIENE_GRUPO = "La sección tiene grupos asociados.";
        //public const string SECCION_TURNO_YA_EXISTE = "La sección y el turno ya existe para la Institución Educativa.";
        //public const string SECCION_YA_EXISTE = "La sección ya existe para la Institución Educativa.";
        //public const string SECCION_TIENE_AREAS = "La sección cuenta con asignación de horario de personal.";
        //public const string SECCION_TIENE_AREAS_DOCENTE = "La sección cuenta con asignación de horario de personal.";
        //public const string SECCION_TIENE_ANIO_IE_PERIODO = "La sección cuenta año/ie/período.";
    }


    public static class MensajesTipoCalificacionAnioGrado
    {
        public const string TIPO_CALIFICACION_GRADO_NO_EXISTE = "No existe configurado tipo calificación para el año y grado seleccionado.";
    }
    public static class MensajesAreaGradoAnioIE
    {
        public const string AREA_GRADO_NO_EXISTE = "No existe configurado áreas para el grado seleccionado.";
        public const string AREA_GRADO_DOCENTE_NO_EXISTE = "El docente no cuenta con áreas asignadas para el grado seleccionado. No es posible realizar la descarga.";
    }
    public static class MensajesCompetenciasGradoAnioIE
    {
        public const string COMPETENCIA_GRADO_NO_EXISTE = "No existe configurado competencias para el grado seleccionado.";
    }
    public static class MensajesEstudianteSeccion
    {
        public const string ESTUDIANTE_SECCION_EN_PROCESO_MATRICULA_EXISTE = "En la sección seleccionada existe al menos un estudiante que no se encuentra asociado(a) a la nómina de matrícula.";


        public const string ESTUDIANTE_SECCION_NO_EXISTE = "El grado y sección seleccionado no cuenta con estudiantes matriculados.";

        public const string POSTERGADO_ESTUDIANTE_SECCION_NO_EXISTE = "El grado y sección seleccionado no cuenta con estudiantes postergados.";
        public const string RECTIFICCION_ESTUDIANTE_SECCION_NO_EXISTE = "El grado y sección seleccionado no cuenta con estudiantes a rectificar.";

    }
    public static class MensajesTallerSeleccionable
    {
        public const string IE_TALLER_SELECCIONABLE_GRADO_NO_EXISTE = "No se cuenta con estudiantes asociados al Taller en una o más secciones del grado.";

    }
    public static class MensajesPeriodo
    {
        public const string PERIODO_NO_EXISTE = "El período no existe.";
        public const string PERIODO_PROMOCIONAL_NO_EXISTE = "El período promocional no existe.";

    }
    public static class MensajesNominaOficialSeccion
    {
        public const string NOMINA_OFICIAL_SECCION_NO_EXISTE = "La sección no tiene nómina oficial.";
    }

    public static class MensajesEstadoCierreIe
    {
        public const string ESTADO_CIERRE_IE_CERRADO = "El período de evaluación se encuentra en estado “Cerrado”";
    }
    public static class MensajesEstadoPeriodo
    {
        public const string ESTADO_PERIODO_NO_EN_EVALUACION = "El período de evaluación no se encuentra en estado “En evaluación”";
    }
    public static class MensajesEstadoProceso
    {
        public const string ESTADO_PROCESO_NO_EN_PROCESO = "El período de evaluación no se encuentra en estado “En proceso”";
    }
    public static class MensajesEstudianteGrado
    {
        public const string ESTUDIANTE_GRADO_NO_EXISTE = "El grado seleccionado no cuenta con estudiantes matriculados.";
    }
    public static class MensajesTiposRecuperacion
    {
        public const string TIPOS_RECUPERACION_NO_EXISTE = "No existe configuración de tipos de recuperación";
    }
}