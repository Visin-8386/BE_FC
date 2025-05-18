using System.Collections.Generic;
using BeeFC.Models;

namespace BeeFC.Repositories
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAllCategories();
    }
}
