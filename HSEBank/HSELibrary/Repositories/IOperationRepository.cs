using HSEBank.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSEBank.Repositories
{
    /// <summary>
    /// Интерфейс для репозитория операций.
    /// </summary>
    public interface IOperationRepository
    {
        void Add(Operation operation);
        Operation GetById(Guid id);
        IEnumerable<Operation> GetAll();
        void Remove(Guid id);
    }
}
