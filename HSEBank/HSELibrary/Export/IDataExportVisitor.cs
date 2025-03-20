using HSEBank.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSEBank.Export
{
    /// <summary>
    /// Интерфейс посетителя для экспорта данных
    /// </summary>
    public interface IDataExporterVisitor
    {
        void Export(List<Operation> operations, string filePath);
    }
}
