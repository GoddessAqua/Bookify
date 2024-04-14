using Bookify.Application.Abstraction.Messaging;
using Bookify.Domain.Abstractions;
using Bookify.Domain.Apartments;

namespace Bookify.Application.Apartments.UploadApartmentsJob.Commands
{
    internal class InsertApartmentsCommandHandler : ICommandHandler<InsertApartmentsCommand>
    {
        private readonly IApartmentRepository _apartmentRepository;
        private readonly IUnitOfWork _unitOfWork;

        public InsertApartmentsCommandHandler(
            IApartmentRepository apartmentRepository,
            IUnitOfWork unitOfWork)
        {
            _apartmentRepository = apartmentRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(InsertApartmentsCommand request, CancellationToken cancellationToken)
        {
            _apartmentRepository.AddRange(request.Apartments);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
    }
}
