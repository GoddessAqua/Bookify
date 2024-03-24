using Bookify.Domain.ApartmentTask;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bookify.Infrastructure.Configurations
{
    internal sealed class ApartmentTaskConfiguration : IEntityTypeConfiguration<ApartmentTask>
    {
        public void Configure(EntityTypeBuilder<ApartmentTask> builder)
        {
            builder.ToTable("apartmentstasks");

            builder.HasKey(task => task.Id);
        }
    }
}
