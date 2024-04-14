using Bookify.Application.Abstraction.Messaging;
using Bookify.Domain.Apartments;

namespace Bookify.Application.Apartments.UploadApartmentsJob.Commands
{
    public sealed record InsertApartmentsCommand(List<Apartment> Apartments) : ICommand;
}
