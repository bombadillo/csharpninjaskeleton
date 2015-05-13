namespace LaserAndCrmAddressAnalysis.Interfaces
{
    using System.Collections.Generic;

    public interface IReadCsv
    {
        List<string[]> CsvList { get; }

        bool ReadFile(string fileName);
    }
}
