using Quartz;
using MediatR;
using Bookify.Application.Apartments.UploadApartmentsJob.Queries;
using Microsoft.Extensions.Logging;

namespace Bookify.Infrastructure.Jobs
{
    [DisallowConcurrentExecution]
    internal sealed class UploadApartmentsJob : IJob
    {
        private readonly ISender _sender;
        private readonly ILogger<UploadApartmentsJob> _logger;

        public UploadApartmentsJob(ISender sender, ILogger<UploadApartmentsJob> logger)
        {
            _sender = sender;
            _logger = logger;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            var query = new GetUnresolvedTasksJobQuery();

            var result = await _sender.Send(query, context.CancellationToken);

            if (result.Value.Any())
                _logger.LogInformation("{result}", result.Value.First().CreatedOnUtc);
        }
    }
}
