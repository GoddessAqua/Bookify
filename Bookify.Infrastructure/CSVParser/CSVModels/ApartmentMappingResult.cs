using Bookify.Application.Abstraction.CSVParser;
using CsvHelper.Configuration.Attributes;

namespace Bookify.Infrastructure.CSVParser.CSVModels
{
    public sealed class ApartmentMappingResult : CSVMappingModel
    {
        [Name("Id")]
        public string Id { get; set; }
        
        [Name("Name")]
        public string Name { get; set; }

        [Name("Description")]
        public string Description { get; set; }

        [Name("Country")]
        public string Country { get; set; }

        [Name("State")]
        public string State { get; set; }

        [Name("ZipCode")]
        public string ZipCode { get; set; }

        [Name("City")]
        public string City { get; set; }

        [Name("Street")]
        public string Street { get; set; }

        [Name("PriceAmount")]
        public decimal PriceAmount { get; set; }

        [Name("PriceCurrency")]
        public string PriceCurrency { get; set; }

        [Name("CleaningFeeAmount")]
        public decimal CleaningFeeAmount { get; set; }

        [Name("CleaningFeeCurrency")]
        public string CleaningFeeCurrency { get; set; }

        [Name("LastBookedOnUtc")]
        public DateTime? LastBookedOnUtc { get; set; }

        [Name("Amenities")]
        public string Amenities { get; set; }
    }
}
