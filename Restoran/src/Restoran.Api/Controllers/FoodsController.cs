using Microsoft.AspNetCore.Mvc;
using Restaurant.Api.Dtos;
using Restaurant.Api.Services;

namespace Restaurant.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FoodsController : ControllerBase
    {
        private readonly IFoodService _foodService;

        public FoodsController(IFoodService foodService)
        {
            _foodService = foodService;
        }

        // GET /api/foods
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FoodDto>>> GetAll()
        {
            var foods = await _foodService.GetAllAsync();
            return Ok(foods);
        }

        // GET /api/foods/{id}
        [HttpGet("{id:long}")]
        public async Task<ActionResult<FoodDto>> GetById(long id)
        {
            var food = await _foodService.GetByIdAsync(id);
            if (food == null)
            {
                return NotFound($"Id si {id} bo'lgan taom topilmadi.");
            }
            return Ok(food);
        }

        // POST /api/foods
        [HttpPost]
        public async Task<ActionResult<FoodDto>> Create([FromBody] FoodCreateDto dto)
        {
            var createdFood = await _foodService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = createdFood.Id }, createdFood);
        }

        // PUT /api/foods/{id}
        [HttpPut("{id:long}")]
        public async Task<ActionResult<FoodDto>> Update(long id, [FromBody] FoodUpdateDto dto)
        {
            var updatedFood = await _foodService.UpdateAsync(id, dto);
            if (updatedFood == null)
            {
                return NotFound($"Yangilash muvaffaqiyatsiz tugadi. Id si {id} bo'lgan taom topilmadi.");
            }
            return Ok(updatedFood); // Yoki interfeys qaytargan yangi obyektni qaytaramiz
        }

        // DELETE /api/foods/{id}
        [HttpDelete("{id:long}")]
        public async Task<IActionResult> Delete(long id)
        {
            var result = await _foodService.DeleteAsync(id);
            if (!result)
            {
                return NotFound($"O'chirish muvaffaqiyatsiz tugadi. Id si {id} bo'lgan taom topilmadi.");
            }
            return NoContent(); // 204 No Content
        }
    }
}