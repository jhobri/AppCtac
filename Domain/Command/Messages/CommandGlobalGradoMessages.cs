namespace Back.Ctac.Command.Messages
{
    public static class CommandGlobalGradoMessages
    {
        public const string GRADO_PROCESAR_OK = "El grado fue procesada correctamente.";
        public const string GRADO_PROCESAR_NO_OK = "No es posible procesar el grado.";
        public const string SECCION_PROCESAR_OK = "la sección fue procesada correctamente.";
        public const string SECCION_PROCESAR_NO_OK = "No es posible procesar la sección.";
        public const string SECCION_CARGA_NOTA_NO_OK = "No es posible cargar las notas.";
        public const string SECCION_CARGA_CALIFICACION_NO_OK = "No es posible cargar las calificaciones.";
        public const string SECCION_ACTUALIZAR_NOTA_NO_OK = "No es posible actualizar notas de la sección.";
        public const string SECCION_FASE_PROCESAR_OK = "la sección fue procesada correctamente.";
        public const string SECCION_FASE_PROCESAR_NO_OK = "No es posible procesar la sección.";
        public const string SECCION_FASE_EVALUAR_NO_OK = "No es posible evaluar la sección.";
        public const string GRADO_HABILITAR_NO_OK = "No es posible habilitar grado.";
        public const string GRADO_ABRIR_CIERRE_ANUAL_NO_OK = "No es posible abrir el cierre anual del grado.";
        public const string NO_ES_EBA = "La institución educativa no es válida, no pertenece a la modalidad Educación Básica Alternativa.";
        public const string NO_ES_EBR = "La institución educativa no es válida, no pertenece a la modalidad EBR o EBE.";
        public const string GRADO_REGISTRAR_NO_OK = "No es posible registrar notas del grado.";
    }

    public static class CommandGlobalSeccionMessages
    {
        public const string SECCION_PROCESAR_OK = "La sección fue procesado correctamente.";
        public const string SECCION_PROCESAR_NO_OK = "No es posible procesar la sección.";

        public const string SECCION_REGISTRAR_NO_OK = "No es posible registrar notas de la sección.";
        public const string SECCION_HABILITAR_NO_OK = "No es posible habilitar sección.";
        public const string SECCION_ABRIR_CIERRE_ANUAL_NO_OK = "No es posible abrir cierre anual de la sección.";
    }
    public static class CommandGlobalIeMessages
    {
        public const string IE_PROCESAR_OK = "La institución educativa fue procesada correctamente.";
        public const string IE_PROCESAR_NO_OK = "No es posible procesar la institución educativa.";
    }
}
