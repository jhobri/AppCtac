namespace Back.Ctac.Api.ViewModel.Excel
{
    public class ArchivoResponseModel
    {
        public string FileName { get; set; }
        public byte[] File { get; set; }
        public string ContentType { get; set; }
        public int ContentLength { get; set; }
    }
}
