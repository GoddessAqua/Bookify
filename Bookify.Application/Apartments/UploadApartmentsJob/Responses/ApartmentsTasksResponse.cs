namespace Bookify.Application.Apartments.UploadApartmentsJob.Responses
{
    public sealed class ApartmentsTasksResponse
    {
        public DateTime CreatedOnUtc { get; init; }

        public string FileName { get; init; }

        public byte[] FileData { get; init; }
    }
}
