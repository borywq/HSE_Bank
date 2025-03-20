using HSEBank.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSEBank.Repositories
{
    /// <summary>
    /// Реализация репозитория операций, хранящего данные в памяти.
    /// </summary>
    public class InMemoryOperationRepository : IOperationRepository
    {
        private readonly List<Operation> _operations = new List<Operation>();

        public void Add(Operation operation)
        {
            _operations.Add(operation);
        }

        public Operation GetById(Guid id)
        {
            return _operations.FirstOrDefault(o => o.Id == id);
        }

        public IEnumerable<Operation> GetAll()
        {
            return _operations;
        }

        public void Remove(Guid id)
        {
            var op = GetById(id);
            if (op != null)
                _operations.Remove(op);
        }
    }
}
