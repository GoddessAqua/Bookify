using Bookify.Application.Abstraction.Messaging;

namespace Bookify.Application.Apartments.AssignApartmentsTask
{
    public record AssignApartmentsTaskCommand(
        string FileName, 
        byte[] FileContent) : ICommand<Guid>;
}
