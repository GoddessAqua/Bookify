using Bookify.Application.Abstraction.CSVParser;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;

namespace Bookify.Infrastructure.CSVParser
{
    internal sealed class CSVParser<T> : ICSVParser<T>
        where T : CSVMappingModel
    {
        public List<T> ParseCSV(Stream stream)
        {
            using var reader = new StreamReader(stream);
            var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ",",
                HasHeaderRecord = true
            };
            using var csv = new CsvReader(reader, csvConfig);

            var records = csv.GetRecords<T>().ToList();
            return records;
        }
    }
}
