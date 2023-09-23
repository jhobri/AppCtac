namespace Back.Ctac.Dto.Base
{
    public class InstitucionEducativaGradoBaseRequestDto<T> : InstitucionEducativaAnioBaseRequestDto
    {

        public T GradoId { get; set; }
    }
}
