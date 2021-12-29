using System;

namespace BaseProject.Infra.CrossCutting.Middleware.Models
{
    public class ExceptionResponse
    {
        public ExceptionResponse(string title)
        {
            Title = title;

            Date = DateTime.Now;
        }

        public ExceptionResponse(string title, Exception ex) : this(title)
        {
            Message = ex.Message;
            StackTrace = ex.StackTrace;           
        }

        public Guid TraceId { get; set; } // TODO: Implementar TraceId

        public string Title { get; set; }

        public string Message { get; set; }

        public string StackTrace { get; set; }

        public DateTime Date { get; private set; }
    }
}
