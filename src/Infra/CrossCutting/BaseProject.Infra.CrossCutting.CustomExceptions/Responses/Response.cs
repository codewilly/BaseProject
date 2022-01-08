using System;

namespace BaseProject.Infra.CrossCutting.CustomExceptions.Responses
{
    public abstract class Response
    {
        public Response()
        {
            TraceId = Guid.NewGuid(); // TODO: Implementar trace id funcional
            At = DateTime.Now;
        }

        public Guid TraceId { get; }

        public DateTime At { get; }
    }
}
