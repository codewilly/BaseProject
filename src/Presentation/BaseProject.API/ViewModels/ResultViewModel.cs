using System;

namespace BaseProject.API.ViewModels
{
    public class ResultViewModel
    {
        public ResultViewModel()
        {
            At = DateTime.Now;
        }

        public Guid TraceId { get; set; }

        public DateTime At { get; private set; }
    }

    public class ResultViewModel<T> : ResultViewModel
    {
        public T Data { get; set; }
    }
}
