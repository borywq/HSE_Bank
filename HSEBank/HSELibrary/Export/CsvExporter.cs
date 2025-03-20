using CsvHelper;
using HSEBank.Domain;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSEBank.Export
{
    /// <summary>
    /// Реализация экспорта CSV
    /// </summary>
    public class CsvExporter : IDataExporterVisitor
    {
        public void Export(List<Operation> operations, string filePath)
        {
            using var writer = new StreamWriter(filePath);
            using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
            csv.WriteRecords(operations);
        }
    }
}
