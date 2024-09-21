using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UESAN.StoreDB.DOMAIN.Core.Entities;
using UESAN.StoreDB.DOMAIN.Core.Interfaces;

namespace UESAN.StoreDB.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await _categoryRepository.GetCategories();
            return Ok(categories);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCateriesByID(int id)
        {
            var catetory = await _categoryRepository.GetCategoriesByID(id);
            if (catetory == null) return NotFound();
            return Ok(catetory);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody]Category category)
        {
           int CategoryId = await _categoryRepository.InsertCategory(category);
            return Ok(CategoryId);
        }
        [HttpPut("{int id}")]
        public async Task<IActionResult> UpdateCategory(int id, [FromBody]Category category)
        {
            if(id !=  category.Id) return BadRequest();
            bool result = await _categoryRepository.UpdateCategory(category);
            if (result==false) return NotFound();
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var result = await _categoryRepository.DeleteCategory(id);
            if(result == false) return NotFound();
            return Ok(result);
        }
    }
}
