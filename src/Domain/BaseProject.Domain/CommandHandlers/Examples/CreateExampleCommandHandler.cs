using BaseProject.Domain.Core.Commands;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BaseProject.Domain.CommandHandlers.Examples
{

    public class CreateExampleCommand : Command<Guid>
    {
        public string Name { get; set; }

        public override void Validate()
        {
            ValidationResult = new();

            base.Validate();
        }
    }

    public class CreateExampleCommandHandler : IRequestHandler<CreateExampleCommand, Guid>
    {
        public async Task<Guid> Handle(CreateExampleCommand request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            request.Validate();

            return Guid.NewGuid();
        }
    }
}
