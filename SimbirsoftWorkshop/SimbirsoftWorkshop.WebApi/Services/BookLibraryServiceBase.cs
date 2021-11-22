using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartFormat;

namespace SimbirsoftWorkshop.WebApi.Services
{
    public abstract class BookLibraryServiceBase
    {
        protected SuccessServiceResult Success() => new SuccessServiceResult();
        protected SuccessServiceResult<TValue> Success<TValue>(TValue value) => new SuccessServiceResult<TValue>(value);
        protected ErrorServiceResult Error(string errorMessage) => new ErrorServiceResult(errorMessage);
        protected ErrorServiceResult Error(string errorMessage, params object[] args) => new ErrorServiceResult(errorMessage.FormatSmart(args));
    }
}
