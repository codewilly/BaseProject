using System;

namespace BaseProject.Infra.CrossCutting.CustomExceptions.Responses
{
    public class ExceptionResponse : Response
    {
        public ExceptionResponse(string title)
        {
            Title = title;
        }

        public ExceptionResponse(string title, Exception ex) : this(title)
        {
            Message = ex.Message;
            StackTrace = ex.StackTrace;           
        }

        public string Title { get; set; }

        public string Message { get; set; }

        public string StackTrace { get; set; }
    }
}
