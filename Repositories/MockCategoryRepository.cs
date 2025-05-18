using System.Collections.Generic;
using BeeFC.Models;

namespace BeeFC.Repositories
{
    public class MockCategoryRepository : ICategoryRepository
    {
        private List<Category> _categoryList;

        public MockCategoryRepository()
        {
            _categoryList = new List<Category>
            {
                new Category { Id = 1, Name = "Gà Rán" },
                new Category { Id = 2, Name = "Burger" },
                new Category { Id = 3, Name = "Mì Ý" },
                new Category { Id = 4, Name = "Tráng miệng" },
                new Category { Id = 5, Name = "Đồ Uống" }
            };
        }

        public IEnumerable<Category> GetAllCategories() => _categoryList;
    }
}
