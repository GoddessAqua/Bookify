using Bookify.Application.Abstraction.Data;
using Bookify.Application.Abstraction.Messaging;
using Bookify.Application.Apartments.UploadApartmentsJob.Responses;
using Bookify.Domain.Abstractions;
using Bookify.Domain.ApartmentTask;
using Dapper;

namespace Bookify.Application.Apartments.UploadApartmentsJob.Queries
{
    internal sealed class GetUnresolvedTasksJobQueryHandler : IQueryHandler<GetUnresolvedTasksJobQuery, IReadOnlyList<ApartmentsTasksResponse>>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        private static readonly int NotResolvedStatus =
            (int)ApartmentTaskStatus.NotResolved;

        public GetUnresolvedTasksJobQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
           => _sqlConnectionFactory = sqlConnectionFactory;

        public async Task<Result<IReadOnlyList<ApartmentsTasksResponse>>> Handle(
            GetUnresolvedTasksJobQuery request,
            CancellationToken cancellationToken)
        {
            using var connection = _sqlConnectionFactory.CreateConnection();

            const string sql = """
            SELECT
                a.created_on_utc as CreatedOnUtc,
                a.file_name as FileName,
                a.file_data as FileData
            FROM apartmentstasks AS a
            WHERE a.status = @NotResolvedStatus
            """;

            var tasks = await connection.QueryAsync<ApartmentsTasksResponse>(sql, new { NotResolvedStatus });

            return tasks.ToList();
        }
    }
}
