namespace SimbirsoftWorkshop.WebApi.Services
{
    public class ErrorServiceResult : ServiceResult
    {
        public ErrorServiceResult(string errorMessage)
            : base(ServiceResultType.Error)
        {
            ErrorMessage = errorMessage ?? throw new System.ArgumentNullException(nameof(errorMessage));
        }

        public string ErrorMessage { get; }
    }
}
