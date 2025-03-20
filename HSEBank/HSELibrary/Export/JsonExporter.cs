using HSEBank.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSEBank.Export
{
    /// <summary>
    /// Реализация экспорта JSON.
    /// </summary>
    public class JsonExporter : IDataExporterVisitor
    {
        public void Export(List<Operation> operations, string filePath)
        {
            File.WriteAllText(filePath, JsonConvert.SerializeObject(operations, Formatting.Indented));
        }
    }
}
