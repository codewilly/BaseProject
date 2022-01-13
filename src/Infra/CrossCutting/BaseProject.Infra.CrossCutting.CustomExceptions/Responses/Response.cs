using System;

namespace BaseProject.Infra.CrossCutting.CustomExceptions.Responses
{
    public abstract class Response
    {
        public Response(string traceId)
        {
            TraceId = traceId;
            At = DateTime.Now;
        }

        public string TraceId { get; }

        public DateTime At { get; }
    }
}
