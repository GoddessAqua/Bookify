namespace Bookify.Domain.ApartmentTask
{
    public interface IApartmentTaskRepository
    {
        Task<ApartmentTask?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

        void Add(ApartmentTask task);
        
        void Update(ApartmentTask task);
    }
}
