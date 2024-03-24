using Bookify.Application.Abstraction.Messaging;

namespace Bookify.Application.Apartments.UploadApartments
{
    public record UploadApartmentsCommand(
        string FileName, 
        byte[] FileContent) : ICommand<Guid>;
}
