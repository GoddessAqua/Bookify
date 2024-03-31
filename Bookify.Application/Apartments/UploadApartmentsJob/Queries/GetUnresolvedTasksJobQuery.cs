using Bookify.Application.Abstraction.Messaging;
using Bookify.Application.Apartments.UploadApartmentsJob.Responses;

namespace Bookify.Application.Apartments.UploadApartmentsJob.Queries
{
    public sealed record GetUnresolvedTasksJobQuery()
        : IQuery<IReadOnlyList<ApartmentsTasksResponse>>;
}
