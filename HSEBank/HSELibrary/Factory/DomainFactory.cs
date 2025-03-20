using HSEBank.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSEBank.Factory
{
    /// <summary>
    /// Фабрика, для того чтобы создавать все объекты в одном месте.
    /// </summary>
    public static class DomainFactory
    {
        public static BankAccount CreateBankAccount(string name, decimal initialBalance = 0)
        {
            return new BankAccount(Guid.NewGuid(), name, initialBalance);
        }

        public static Category CreateCategory(string name, CategoryType type)
        {
            return new Category(Guid.NewGuid(), name, type);
        }

        public static Operation CreateOperation(OperationType type, Guid bankAccountId, decimal amount, DateTime date, Guid categoryId, string description = "")
        {
            return new Operation(Guid.NewGuid(), type, bankAccountId, amount, date, categoryId, description);
        }
    }
}
