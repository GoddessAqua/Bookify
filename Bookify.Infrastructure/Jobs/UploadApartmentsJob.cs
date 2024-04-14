using Quartz;
using MediatR;
using Microsoft.Extensions.Logging;
using Bookify.Application.Abstraction.CSVParser;
using Bookify.Infrastructure.CSVParser.CSVModels;

namespace Bookify.Infrastructure.Jobs
{
    [DisallowConcurrentExecution]
    internal sealed class UploadApartmentsJob : IJob
    {
        private readonly ISender _sender;
        private readonly ILogger<UploadApartmentsJob> _logger;
        private readonly ICSVParser<ApartmentMappingResult> _csvParser;

        public UploadApartmentsJob(
            ISender sender, 
            ILogger<UploadApartmentsJob> logger,
            ICSVParser<ApartmentMappingResult> csvParser
            )
        {
            _sender = sender;
            _logger = logger;
            _csvParser = csvParser;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            //var query = new GetUnresolvedTasksQuery();
            //var unresolvedTasks = await _sender.Send(query, context.CancellationToken);

            //if (!unresolvedTasks.Value.Any())
            //    return; //Нет тасок в статусе неразрешённых
            
            //foreach (var task in unresolvedTasks.Value)
            //{
            //    var apartments = _csvParser.ParseCSV(new MemoryStream(task.FileData));

            //    //var insertCommand = new InsertApartmentsCommand(apartments);
            //    //await _sender.Send(insertCommand, context.CancellationToken);

            //    //var setResolvedStatusCommand = new SetResolvedStatusCommand(task.Id);
            //    //await _sender.Send(setResolvedStatusCommand, context.CancellationToken);
            //}
        }
    }
}
