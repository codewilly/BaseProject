using BaseProject.Domain.Core.Interfaces;
using System;
using System.Threading.Tasks;

namespace BaseProject.Application.Interfaces
{
    public interface IExampleAppService
    {
        Task<IResult<Guid>> Create();

        IResult<string> Get(bool throwEx);
    }
}
