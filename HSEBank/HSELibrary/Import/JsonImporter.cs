using HSEBank.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSEBank.Import
{
    /// <summary>
    /// Извлечение данных из json-файла.
    /// </summary>
    public class JsonImporter : DataImporter
    {
        protected override string ReadFile(string filePath) => File.ReadAllText(filePath);
        protected override List<Operation> ParseData(string data) => JsonConvert.DeserializeObject<List<Operation>>(data);
    }
}
