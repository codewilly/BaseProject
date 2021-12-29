using BaseProject.Domain.Core.Interfaces;
using BaseProject.Domain.Core.Models;

namespace BaseProject.Domain.Core.Bases
{
    public abstract class BaseResult
    {
        protected IResult Success()
        {
            return new Result();
        }

        protected IResult<T> Success<T>(T data)
        {
            return new Result<T>(data);
        }
    }
}
