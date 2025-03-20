using HSEBank.Domain;
using HSEBank.Facades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSEBank.Commands
{
    /// <summary>
    /// Команда для добавления операции.
    /// </summary>
    public class AddOperationCommand : ICommand
    {
        private readonly BankFacade _facade;
        private readonly OperationType _type;
        private readonly Guid _accountId;
        private readonly decimal _amount;
        private readonly DateTime _date;
        private readonly Guid _categoryId;
        private readonly string _description;

        public AddOperationCommand(BankFacade facade, OperationType type, Guid accountId, decimal amount, DateTime date, Guid categoryId, string description = "")
        {
            _facade = facade;
            _type = type;
            _accountId = accountId;
            _amount = amount;
            _date = date;
            _categoryId = categoryId;
            _description = description;
        }

        /// <summary>
        /// Выполняет команду: добавляет операцию.
        /// </summary>
        public void Execute()
        {
            _facade.AddOperation(_type, _accountId, _amount, _date, _categoryId, _description);
        }
    }
}
