using System;

namespace BaseProject.Infra.CrossCutting.CustomExceptions.Responses
{
    public class ExceptionResponse : Response
    {
        public ExceptionResponse(Exception ex, string traceId) : base(traceId)
        {
            Message = ex.Message;
            StackTrace = ex.StackTrace;           
        }

        public string Message { get; set; }

        public string StackTrace { get; set; }
    }
}
