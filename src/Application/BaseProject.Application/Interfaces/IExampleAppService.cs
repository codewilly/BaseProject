using BaseProject.Domain.Core.Interfaces;

namespace BaseProject.Application.Interfaces
{
    public interface IExampleAppService
    {
        IResult Create();

        IResult<string> Get(bool throwEx, bool throwInvalid);
    }
}
