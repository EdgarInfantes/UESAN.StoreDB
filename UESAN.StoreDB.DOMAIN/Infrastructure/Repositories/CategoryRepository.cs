using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UESAN.StoreDB.DOMAIN.Core.Entities;
using UESAN.StoreDB.DOMAIN.Core.Interfaces;
using UESAN.StoreDB.DOMAIN.Infrastructure.Data;

namespace UESAN.StoreDB.DOMAIN.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly StoreDbContext _dbContext;
        public CategoryRepository(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public string obtenerApellido()
        {
            return "";
        }

        //Método Síncrono
        //public List<Category> GetCategories()
        //{
        //    var categories = _dbContext.Category.ToList();
        //    return categories;
        //}
        public async Task<List<Category>> GetCategories()
        {
            var categories = await _dbContext.Category.ToListAsync();
            return categories;
        }
        public async Task<Category> GetCategoriesByID(int ID)
        {
            var category = await _dbContext
                .Category.Where(c => c.Id == ID && c.IsActive == true)
                .FirstOrDefaultAsync();
            return category;
        }

        //Create Category
        public async Task<int> InsertCategory(Category category)
        {
            await _dbContext.Category.AddAsync(category); //Agrega la categoria
            await _dbContext.SaveChangesAsync(); // Confirma la transacción
            // int rows = _dbContext.SaveChanges();
            // return rows > 0 ? category.Id : -1;
            return category.Id;
        }

        //Update Category
        public async Task<bool> UpdateCategory(Category category)
        {
            _dbContext.Category.Update(category);
            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }

        // Delete Category
        public async Task<bool> DeleteCategory(int id)
        {
            var category = _dbContext.Category.FirstOrDefault(c => c.Id == id);
            if (category != null) return false;
            category.IsActive = false;
            int rows = await _dbContext.SaveChangesAsync();
            return (rows > 0);
        }

    }
}
