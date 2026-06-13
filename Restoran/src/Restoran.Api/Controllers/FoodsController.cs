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
        [HttpGet("{id:long}")]
        public async Task<ActionResult<FoodResponseDto>> GetById(long id)
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
        [HttpPut("{id:long}")]
        public async Task<IActionResult> Update(long id, [FromBody] FoodUpdateDto dto)
        {
            var result = await _foodService.UpdateFoodAsync(id, dto);
            if (!result)
            {
                return NotFound($"Yangilash muvaffaqiyatsiz tugadi. Id si {id} bo'lgan taom topilmadi.");
            }
            return NoContent(); // Interfeys bool qaytargani uchun 204 No Content qaytaramiz
        }

        // DELETE /api/foods/{id}
        [HttpDelete("{id:long}")]
        public async Task<IActionResult> Delete(long id)
        {
            var result = await _foodService.DeleteFoodAsync(id);
            if (!result)
            {
                return NotFound($"O'chirish muvaffaqiyatsiz tugadi. Id si {id} bo'lgan taom topilmadi.");
            }
            return NoContent(); // 204 No Content
        }

        // =================================================================
        // WI14: Foodlarni kategoriya bo'yicha olish endpointi
        // GET /api/foods/category/{categoryId}
        // =================================================================
        [HttpGet("category/{categoryId:long}")]
        public async Task<ActionResult<IEnumerable<FoodResponseDto>>> GetByCategoryId(long categoryId)
        {
            var foods = await _foodService.GetFoodsByCategoryIdAsync(categoryId);
            return Ok(foods);
        }

        // =================================================================
        // WI15: Mavjud foodlarni va qidiruv endpointlari
        // =================================================================

        // GET /api/foods/available
        [HttpGet("available")]
        public async Task<ActionResult<IEnumerable<FoodResponseDto>>> GetAvailable()
        {
            var foods = await _foodService.GetAvailableFoodsAsync();
            return Ok(foods);
        }

        // GET /api/foods/search?name=pizza
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<FoodResponseDto>>> Search([FromQuery] string name)
        {
            var foods = await _foodService.SearchFoodsByNameAsync(name);
            return Ok(foods);
        }
    }
}