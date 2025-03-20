using HSEBank.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSEBank.Repositories
{
    /// <summary>
    /// Интерфейс для репозитория банковских аккаунтов.
    /// </summary>
    public interface IBankAccountRepository
    {
        void Add(BankAccount account);
        BankAccount GetById(Guid id);
        IEnumerable<BankAccount> GetAll();
        void Update(BankAccount account);
        void Remove(Guid id);
    }
}
