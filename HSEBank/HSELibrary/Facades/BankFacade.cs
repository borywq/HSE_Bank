using HSEBank.Domain;
using HSEBank.Factory;
using HSEBank.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSEBank.Facades
{
    /// <summary>
    /// Представляет финансовую операцию (доход или расход).
    /// </summary>
    public class BankFacade
    {
        private readonly IBankAccountRepository _accountRepo;
        private readonly ICategoryRepository _categoryRepo;
        private readonly IOperationRepository _operationRepo;

        public BankFacade(IBankAccountRepository accountRepo, ICategoryRepository categoryRepo, IOperationRepository operationRepo)
        {
            _accountRepo = accountRepo;
            _categoryRepo = categoryRepo;
            _operationRepo = operationRepo;
        }

        public BankAccount CreateAccount(string name, decimal initialBalance = 0)
        {
            var account = DomainFactory.CreateBankAccount(name, initialBalance);
            _accountRepo.Add(account);
            return account;
        }

        public Category CreateCategory(string name, CategoryType type)
        {
            var category = DomainFactory.CreateCategory(name, type);
            _categoryRepo.Add(category);
            return category;
        }

        public Operation AddOperation(OperationType type, Guid accountId, decimal amount, DateTime date, Guid categoryId, string description = "")
        {
            var operation = DomainFactory.CreateOperation(type, accountId, amount, date, categoryId, description);
            _operationRepo.Add(operation);

            var account = _accountRepo.GetById(accountId);
            if (account != null)
            {
                if (type == OperationType.Income)
                    account.Deposit(amount);
                else
                    account.Withdraw(amount);
            }

            return operation;
        }

        /// <summary>
        /// Пример аналитической функции – подсчёт разницы доходов и расходов за выбранный период
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public decimal CalculateDifference(DateTime start, DateTime end)
        {
            var ops = _operationRepo.GetAll().Where(o => o.Date >= start && o.Date <= end);
            decimal total = 0;
            foreach (var op in ops)
            {
                total += op.Type == OperationType.Income ? op.Amount : -op.Amount;
            }
            return total;
        }

        /// <summary>
        /// Методы для получения данных
        /// </summary>
        /// <returns></returns>
        public IEnumerable<BankAccount> GetAllAccounts() => _accountRepo.GetAll();
        public IEnumerable<Category> GetAllCategories() => _categoryRepo.GetAll();
        public IEnumerable<Operation> GetAllOperations() => _operationRepo.GetAll();
    }

}
