using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSEBank.Domain
{
    /// <summary>
    /// Представляет банковский счет.
    /// </summary>
    public class BankAccount
    {
        public Guid Id { get; }
        public string Name { get; set; }
        public decimal Balance { get; private set; }

        public BankAccount(Guid id, string name, decimal initialBalance = 0)
        {
            Id = id;
            Name = name;
            Balance = initialBalance;
        }

        /// <summary>
        /// Внести деньги.
        /// </summary>
        /// <param name="amount"></param>
        public void Deposit(decimal amount)
        {
            Balance += amount;
        }

        /// <summary>
        /// Снять деньги.
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        public bool Withdraw(decimal amount)
        {
            if (amount > Balance)
                return false;
            Balance -= amount;
            return true;
        }
    }
}
