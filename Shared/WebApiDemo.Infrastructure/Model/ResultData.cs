using System;
using System.Diagnostics.CodeAnalysis;
using WebApiDemo.Infrastructure.Enums;

namespace WebApiDemo.Infrastructure.Models
{
    [ExcludeFromCodeCoverage]
    public class ResultData
    {
        public ResultData(
            string resultCode,
            ResultType resultType)
        {
            if (resultType == ResultType.Error)
            {
                throw new ArgumentException(nameof(resultType));
            }

            ResultCode = resultCode;
            ResultType = resultType;
        }

        public ResultData(string exceptionMessage, string resultCode)
        {
            ResultCode = resultCode;
            ExceptionMessage = exceptionMessage;
            ResultType = ResultType.Error;
        }

        public string ResultCode { get; }

        public ResultType ResultType { get; }

        public string ExceptionMessage { get; }
    }
}
