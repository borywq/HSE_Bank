using HSEBank.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSEBank.Repositories
{
    /// <summary>
    /// Интерфейс для репозитория категорий.
    /// </summary>
    public interface ICategoryRepository
    {
        void Add(Category category);
        Category GetById(Guid id);
        IEnumerable<Category> GetAll();
        void Update(Category category);
        void Remove(Guid id);
    }
}
