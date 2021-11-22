namespace SimbirsoftWorkshop.WebApi.Services
{
    public enum ServiceResultType
    {
        Success,
        Error
    }

    public interface IServiceResult
    {
        ServiceResultType Type { get; }
    }

    public interface IServiceResult<TValue>
    {
        public TValue Value { get; }
    }

    public abstract class ServiceResult : IServiceResult
    {
        public ServiceResult(ServiceResultType type)
        {
            Type = type;
        }

        public ServiceResultType Type { get; }
    }
}
