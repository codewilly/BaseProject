using System.Net;

namespace BaseProject.Domain.Core.Interfaces
{
    public interface IResult
    {
        HttpStatusCode GetStatusCode();
    }

    public interface IResult<T> : IResult
    {
        T GetData();
    }
}
