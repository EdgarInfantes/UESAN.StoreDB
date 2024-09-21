using UESAN.StoreDB.DOMAIN.Core.Entities;

namespace UESAN.StoreDB.DOMAIN.Core.Interfaces
{
    public interface ICategoryRepository
    {
        Task<bool> DeleteCategory(int id);
        Task<List<Category>> GetCategories();
        Task<Category> GetCategoriesByID(int ID);
        Task<int> InsertCategory(Category category);
        Task<bool> UpdateCategory(Category category);
    }
}