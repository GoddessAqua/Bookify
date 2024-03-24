using Bookify.Domain.ApartmentTask;

namespace Bookify.Infrastructure.Repositories
{
    internal class ApartmentTaskRepository : Repository<ApartmentTask>, IApartmentTaskRepository
    {
        public ApartmentTaskRepository(ApplicationDbContext dbContext) 
            : base(dbContext)
        {
        }
    }
}
