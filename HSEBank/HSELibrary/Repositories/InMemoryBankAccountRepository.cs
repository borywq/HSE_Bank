using HSEBank.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSEBank.Repositories
{
    /// <summary>
    /// Реализация репозитория банковских аккаунтов, хранящего данные в памяти.
    /// </summary>
    public class InMemoryBankAccountRepository : IBankAccountRepository
    {
        private readonly List<BankAccount> _accounts = new List<BankAccount>();

        public void Add(BankAccount account)
        {
            _accounts.Add(account);
        }

        public BankAccount GetById(Guid id)
        {
            return _accounts.FirstOrDefault(a => a.Id == id);
        }

        public IEnumerable<BankAccount> GetAll()
        {
            return _accounts;
        }

        public void Update(BankAccount account)
        {
            var existing = GetById(account.Id);
            if (existing != null)
            {
                existing.Name = account.Name;
                // Обновление баланса производится через методы Deposit/Withdraw
            }
        }

        public void Remove(Guid id)
        {
            var account = GetById(id);
            if (account != null)
                _accounts.Remove(account);
        }
    }
}
