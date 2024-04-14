namespace Bookify.Application.Abstraction.CSVParser
{
    public interface ICSVParser<T>
    {
        List<T> ParseCSV(Stream stream);
    }
}
