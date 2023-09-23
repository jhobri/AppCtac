using Back.Ctac.Transversal.Validations;
using Minedu.Fw.General.Response.Status;
using Newtonsoft.Json;

namespace Back.Ctac.Transversal.Extension;

public static class HelperType<T>
{


    public static StatusResponse<T> ConvertFromDynamicV2(StatusResponse<dynamic> data)
    {
        var entidad = new StatusResponse<T>();
        entidad.Success = data.Success;
        entidad.Code = data.Code;
        entidad.Message = data.Message;
        entidad.Validations = data.Validations;
        if (data.Success)
        {
            entidad.Data = JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(data.Data));
        }
        return entidad;
    }


}
public static class HelperTypeConvert
{
    public static StatusResponse<T> GetResponse<T>(this StatusResponse<dynamic> data, bool generarError = false)
    {
        var entidad = new StatusResponse<T>();
        entidad.Success = data.Success;
        entidad.Code = data.Code;
        entidad.Message = data.Message;
        entidad.Validations = data.Validations;
        if (data.Success)
        {
            entidad.Data = JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(data.Data));
        }
        if (generarError && !entidad.Success)
        {

            if (entidad.Validations is not null && entidad.Validations.Any())
                CustomException.Excepcion(entidad.Validations.Select(query => query.Message).Aggregate((a, b) => a + ", " + b), string.Empty);
        }

        return entidad;
    }
    public static IEnumerable<T> GetArray<T>(this StatusResponse<dynamic> data, bool generarError = false)
    {
        var entidad = new StatusResponse<IEnumerable<T>>();
        entidad.Success = data.Success;
        entidad.Code = data.Code;
        entidad.Message = data.Message;
        entidad.Validations = data.Validations;
        if (data.Success)
        {
            entidad.Data = JsonConvert.DeserializeObject<IEnumerable<T>>(JsonConvert.SerializeObject(data.Data));
        }
        if (generarError && !entidad.Success)
        {

            if (entidad.Validations is not null && entidad.Validations.Any())
                CustomException.Excepcion(entidad.Validations.Select(query => query.Message).Aggregate((a, b) => a + ", " + b), string.Empty);
        }

        if (entidad.Success && entidad.Data.Any())
            return entidad.Data;
        else
            return Enumerable.Empty<T>();
    }
    public static T GetEntity<T>(this StatusResponse<dynamic> data, bool generarError = false)
    {
        var entidad = new StatusResponse<T>();
        entidad.Success = data.Success;
        entidad.Code = data.Code;
        entidad.Message = data.Message;
        entidad.Validations = data.Validations;
        if (data.Success)
        {
            entidad.Data = JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(data.Data));
        }
        if (generarError && !entidad.Success)
        {

            if (entidad.Validations is not null && entidad.Validations.Any())
                CustomException.Excepcion(entidad.Validations.Select(query => query.Message).Aggregate((a, b) => a + ", " + b), string.Empty);
            //throw new Exception(entidad.Validations.Select(query => query.Message).Aggregate((a, b) => a + ", " + b));
        }

        return entidad.Data;


    }

}