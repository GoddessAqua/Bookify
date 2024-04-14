using Microsoft.Extensions.Options;
using Quartz;

namespace Bookify.Infrastructure.Jobs
{
    internal sealed class UploadApartmentsJobSetup : IConfigureOptions<QuartzOptions>
    {
        public void Configure(QuartzOptions options)
        {
            const string jobName = nameof(UploadApartmentsJob);

            const int IntervalInSeconds = 5;

            options
                .AddJob<UploadApartmentsJob>(jobBuilder => jobBuilder.WithIdentity(jobName))
                .AddTrigger(trigger =>
                    trigger
                        .ForJob(jobName)
                        .WithSimpleSchedule(schedule =>
                            schedule.WithIntervalInSeconds(IntervalInSeconds).RepeatForever()));
        }
    }
}
