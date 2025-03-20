using HSEBank.Domain;
using HSEBank.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSEBank.Import
{
    /// <summary>
    /// Абстрактный класс для импорта данных.
    /// </summary>
    public abstract class DataImporter
    {
        public void Import(string filePath, IOperationRepository operationRepo)
        {
            var data = ReadFile(filePath);
            var operations = ParseData(data);
            SaveOperations(operations, operationRepo);
        }

        protected abstract string ReadFile(string filePath);
        protected abstract List<Operation> ParseData(string data);

        private void SaveOperations(List<Operation> operations, IOperationRepository operationRepo)
        {
            foreach (var op in operations)
            {
                operationRepo.Add(op);
            }
        }
    }
}
