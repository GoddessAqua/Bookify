using Bookify.Application.Abstraction.Clock;
using Bookify.Application.Abstraction.Messaging;
using Bookify.Domain.Abstractions;
using Bookify.Domain.ApartmentTask;

namespace Bookify.Application.Apartments.AssignApartmentsTask
{
    internal sealed class AssignApartmentsTaskCommandHandler : ICommandHandler<AssignApartmentsTaskCommand, Guid>
    {
        private readonly IApartmentTaskRepository _apartmentTaskRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDateTimeProvider _dateTimeProvider;

        public AssignApartmentsTaskCommandHandler(
            IApartmentTaskRepository apartmentTaskRepository,
            IUnitOfWork unitOfWork,
            IDateTimeProvider dateTimeProvider)
        {
            _apartmentTaskRepository = apartmentTaskRepository;
            _unitOfWork = unitOfWork;
            _dateTimeProvider = dateTimeProvider;
        }

        public async Task<Result<Guid>> Handle(AssignApartmentsTaskCommand request, CancellationToken cancellationToken)
        {
            var task = ApartmentTask.Create(
                _dateTimeProvider.UtcNow,
                request.FileName,
                request.FileContent);

            _apartmentTaskRepository.Add(task);

            await _unitOfWork.SaveChangesAsync();

            return task.Id;
        }
    }
}
