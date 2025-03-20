using HSEBank.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSEBank.Repositories
{
    /// <summary>
    /// Реализация репозитория категорий, хранящего данные в памяти.
    /// </summary>
    public class InMemoryCategoryRepository : ICategoryRepository
    {
        private readonly List<Category> _categories = new List<Category>();

        public void Add(Category category)
        {
            _categories.Add(category);
        }

        public Category GetById(Guid id)
        {
            return _categories.FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<Category> GetAll()
        {
            return _categories;
        }

        public void Update(Category category)
        {
            var existing = GetById(category.Id);
            if (existing != null)
            {
                existing.Name = category.Name;
                existing.Type = category.Type;
            }
        }

        public void Remove(Guid id)
        {
            var category = GetById(id);
            if (category != null)
                _categories.Remove(category);
        }
    }
}
