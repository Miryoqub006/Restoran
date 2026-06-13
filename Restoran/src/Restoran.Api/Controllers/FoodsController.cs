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
        public async Task<ActionResult<IEnumerable<FoodResponseDto>>> GetAll()
        {
            var foods = await _foodService.GetAllFoodsAsync();
            return Ok(foods);
        }

        // GET /api/foods/{id}
        [HttpGet("{id:int}")]
        public async Task<ActionResult<FoodResponseDto>> GetById(int id)
        {
            var food = await _foodService.GetFoodByIdAsync(id);
            if (food == null)
            {
                return NotFound($"Id si {id} bo'lgan taom topilmadi.");
            }
            return Ok(food);
        }

        // POST /api/foods
        [HttpPost]
        public async Task<ActionResult<FoodResponseDto>> Create([FromBody] FoodCreateDto dto)
        {
            var createdFood = await _foodService.CreateFoodAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = createdFood.Id }, createdFood);
        }

        // PUT /api/foods/{id}
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] FoodUpdateDto dto)
        {
            var result = await _foodService.UpdateFoodAsync(id, dto);
            if (!result)
            {
                return NotFound($"Yangilash muvaffaqiyatsiz tugadi. Id si {id} bo'lgan taom topilmadi.");
            }
            return NoContent(); // 204 No Content - muvaffaqiyatli yangilanganligini bildiradi
        }

        // DELETE /api/foods/{id}
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _foodService.DeleteFoodAsync(id);
            if (!result)
            {
                return NotFound($"O'chirish muvaffaqiyatsiz tugadi. Id si {id} bo'lgan taom topilmadi.");
            }
            return NoContent();
        }
    }
}