using Bookify.Application.Abstraction.Messaging;

namespace Bookify.Application.Apartments.UploadApartmentsJob.Commands
{
    public sealed record SetResolvedStatusCommand(Guid Id) : ICommand;
}
