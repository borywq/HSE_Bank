using HSEBank.Export;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSEBank.Domain
{
    public enum OperationType
    {
        Income,
        Expense
    }

    /// <summary>
    /// Представляет финансовую операцию (доход или расход).
    /// </summary>
    public class Operation
    {
        public Guid Id { get; }
        public OperationType Type { get; }
        public Guid BankAccountId { get; }
        public decimal Amount { get; }
        public DateTime Date { get; }
        public string Description { get; set; }
        public Guid CategoryId { get; }

        public Operation(Guid id, OperationType type, Guid bankAccountId, decimal amount, DateTime date, Guid categoryId, string description = "")
        {
            if (amount < 0)
                throw new ArgumentException("Сумма операции не может быть отрицательной");

            Id = id;
            Type = type;
            BankAccountId = bankAccountId;
            Amount = amount;
            Date = date;
            CategoryId = categoryId;
            Description = description;
        }

        public void Accept(IDataExporterVisitor visitor, string filePath)
        {
            visitor.Export(new List<Operation> { this }, filePath);
        }
    }
}
