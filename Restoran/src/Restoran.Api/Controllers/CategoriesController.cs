using Microsoft.AspNetCore.Mvc;
using Restaurant.Api.Dtos;
using Restaurant.Api.Services;

namespace Restaurant.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET /api/categories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryResponseDto>>> GetAll()
        {
            var categories = await _categoryService.GetAllAsync();
            return Ok(categories);
        }

        // GET /api/categories/{id}
        [HttpGet("{id:long}")]
        public async Task<ActionResult<CategoryResponseDto>> GetById(long id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound($"Id si {id} bo'lgan kategoriya topilmadi.");
            }
            return Ok(category);
        }

        // POST /api/categories
        [HttpPost]
        public async Task<ActionResult<CategoryResponseDto>> Create([FromBody] CategoryCreateDto dto)
        {
            var createdCategory = await _categoryService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = createdCategory.Id }, createdCategory);
        }

        // PUT /api/categories/{id}
        [HttpPut("{id:long}")]
        public async Task<IActionResult> Update(long id, [FromBody] CategoryUpdateDto dto)
        {
            var updatedCategory = await _categoryService.UpdateAsync(id, dto);
            if (updatedCategory == null)
            {
                return NotFound($"Yangilash muvaffaqiyatsiz tugadi. Id si {id} bo'lgan kategoriya topilmadi.");
            }
            return NoContent(); // 204 No Content
        }

        // DELETE /api/categories/{id}
        [HttpDelete("{id:long}")]
        public async Task<IActionResult> Delete(long id)
        {
            var result = await _categoryService.DeleteAsync(id);
            if (!result)
            {
                return NotFound($"O'chirish muvaffaqiyatsiz tugadi. Id si {id} bo'lgan kategoriya topilmadi.");
            }
            return NoContent(); // 204 No Content
        }
    }
}