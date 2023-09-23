using Back.Ctac.Dto.Base;

namespace Back.Ctac.Dto.Grado
{
    public class GetGradoLstResponse : ItemCodeBase<int, string, byte>
    {

        public ItemBase<short> Estado { get; set; }
    }
    //public class GetRecuperacionGradoLstRestResponse
    //{
    //    public string Id { get; set; }
    //    public string Nombre { get; set; }
    //    public short EsIngresante { get; set; }
    //}
}
