namespace SimbirsoftWorkshop.WebApi.Services
{
    public class SuccessServiceResult : ServiceResult
    {
        public SuccessServiceResult() : base(ServiceResultType.Success) { }
    }

    public class SuccessServiceResult<TValue> : SuccessServiceResult, IServiceResult<TValue>
    {
        public SuccessServiceResult(TValue value)
        {
            Value = value;
        }

        public TValue Value { get; }
    }
}
