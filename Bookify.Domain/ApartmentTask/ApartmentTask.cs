using Bookify.Domain.Abstractions;

namespace Bookify.Domain.ApartmentTask
{
    public sealed class ApartmentTask : Entity
    {
        private ApartmentTask(
            Guid id,
            DateTime? createdOnUtc, 
            string fileName, byte[]? fileData, 
            ApartmentTaskStatus status)
            : base(id)
        {
            CreatedOnUtc = createdOnUtc;
            FileName = fileName;
            FileData = fileData;
            Status = status;
        }

        public ApartmentTask(){ }

        public DateTime? CreatedOnUtc { get; private set; }

        public string FileName { get; private set; }

        public byte[]? FileData { get; private set; }

        public ApartmentTaskStatus Status { get; private set; }

        public static ApartmentTask Create(
            DateTime utcNow,
            string fileName,
            byte[] fileContent)
        {
            var task = new ApartmentTask(
                Guid.NewGuid(),
                utcNow,
                fileName,
                fileContent,
                ApartmentTaskStatus.NotResilved
                );

            return task;
        }
    }
}
