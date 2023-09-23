namespace Back.Ctac.Transversal.Enum
{
    public enum EnumEstadoInformeProgreso : short
    {
        Ninguno = -1,
        SinProcesamiento = 0,
        PorGenerar = 1,
        Generando = 2,
        Generado = 3
    }
}