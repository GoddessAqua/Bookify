using Bookify.Application.Abstraction.Messaging;
using Bookify.Domain.Abstractions;
using Bookify.Domain.ApartmentTask;

namespace Bookify.Application.Apartments.UploadApartmentsJob.Commands
{
    internal class SetResolvedStatusCommandHandler : ICommandHandler<SetResolvedStatusCommand>
    {
        private readonly IApartmentTaskRepository _apartmentTaskRepository;
        private readonly IUnitOfWork _unitOfWork;

        public SetResolvedStatusCommandHandler(
           IApartmentTaskRepository apartmentTaskRepository,
           IUnitOfWork unitOfWork)
        {
            _apartmentTaskRepository = apartmentTaskRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(SetResolvedStatusCommand request, CancellationToken cancellationToken)
        {
            var task = await _apartmentTaskRepository.GetByIdAsync(request.Id);

            if (task == null)
                return Result.Success();

            task.SetResolvedStatus();
            
            _apartmentTaskRepository.Update(task);
            
            await _unitOfWork.SaveChangesAsync();

            return Result.Success();
        }
    }
}
