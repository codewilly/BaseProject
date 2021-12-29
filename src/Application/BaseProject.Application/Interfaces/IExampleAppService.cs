using BaseProject.Domain.Core.Interfaces;

namespace BaseProject.Application.Interfaces
{
    public interface IExampleAppService
    {
        IResult<string> Get();
    }
}
