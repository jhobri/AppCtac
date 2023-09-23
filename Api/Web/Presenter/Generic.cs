using Back.Ctac.Transversal.Constants;

namespace Back.Ctac.Api.Presenter;

public static class Generic
{


    internal static IEnumerable<dynamic> GetPeriodoEvaluacionTab2(IEnumerable<dynamic> data)
    {


        foreach (var item in data)
        {
            foreach (var s in item.Secciones)
            {
                if (s.Estado.Id == EstadoProceso.CierreAnual)
                    s.Estado.Nombre = "Cerrado";
            }
        }
        return data;
    }

    internal static IEnumerable<dynamic> GetPeriodoEvaluacionGradoTab2(IEnumerable<dynamic> data)
    {
        foreach (var item in data)
        {
            if (item.Estado.Id == EstadoProceso.CierreAnual)
                item.Estado.Nombre = "Cerrado";// filtro?.EstadoNombre ?? item.EstadoNombre;
        }

        return data;
    }
}