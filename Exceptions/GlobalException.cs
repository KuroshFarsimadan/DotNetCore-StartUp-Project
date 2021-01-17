using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Skeleton.Exceptions
{
    public class GlobalException
    {
        public GlobalException(int statusCode, string errorMessage, string exceptionStackTrace)
        {
            this.StatusCode = statusCode;
            this.ExceptionMessage = errorMessage;
            this.ExceptionStackTrace = exceptionStackTrace;
        }

        public int StatusCode { get; set; }
        public string ExceptionMessage { get; set; }
        public string ExceptionStackTrace { get; set; }
    }
}
