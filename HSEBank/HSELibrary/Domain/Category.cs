using HSEBank.Export;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSEBank.Domain
{
    public enum CategoryType
    {
        Income,
        Expense
    }

    /// <summary>
    /// Представляет категорию операции (доход или расход).
    /// </summary>
    public class Category
    {
        public Guid Id { get; }
        public string Name { get; set; }
        public CategoryType Type { get; set; }

        public Category(Guid id, string name, CategoryType type)
        {
            Id = id;
            Name = name;
            Type = type;
        }
    }
}
