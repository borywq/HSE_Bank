using HSEBank.Domain;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSEBank.Import
{
    /// <summary>
    /// Извлечение данных из csv-файла.
    /// </summary>
    public class CsvImporter : DataImporter
    {
        protected override string ReadFile(string filePath) => File.ReadAllText(filePath);
        protected override List<Operation> ParseData(string data)
        {
            using var reader = new StringReader(data);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            return csv.GetRecords<Operation>().ToList();
        }
    }
}
