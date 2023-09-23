namespace Back.Ctac.Dto.Base
{
    public class ItemCodeBase<X, Y, Z> : ItemBase<X>
    {
        public Y Code { get; set; }
    }
}