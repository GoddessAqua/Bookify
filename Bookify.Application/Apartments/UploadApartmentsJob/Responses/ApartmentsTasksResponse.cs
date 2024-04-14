namespace Bookify.Application.Apartments.UploadApartmentsJob.Responses
{
    public sealed class ApartmentsTasksResponse
    {
        public Guid Id { get; init; }

        public DateTime CreatedOnUtc { get; init; }

        public string FileName { get; init; }

        public byte[] FileData { get; init; }
    }
}
