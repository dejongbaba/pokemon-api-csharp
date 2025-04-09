using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pokemon_Api.Models;
using Pokemon_Api.Dto;
using Pokemon_Api.Interfaces;

namespace Pokemon_Api.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ApiResponse<List<CategoryResponseDto>>))]
        [ProducesResponseType(typeof(ApiResponse<object>), 400)]
        public IActionResult GetCategories()
        {
            var categories = _mapper.Map<List<CategoryResponseDto>>(_categoryRepository.GetCategories());

            if (!ModelState.IsValid)
                return BadRequest(new ApiResponse<object>(400, ModelState));

            return Ok(new ApiResponse<List<CategoryResponseDto>>(200, categories));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ApiResponse<CategoryResponseDto>), 200)]
        [ProducesResponseType(typeof(ApiResponse<object>), 400)]
        [ProducesResponseType(typeof(ApiResponse<object>), 404)]
        public IActionResult GetCategory(int id)
        {
            if (!_categoryRepository.CategoryExists(id))
                return NotFound(new ApiResponse<object>(404, "Category not found"));

            var category = _mapper.Map<CategoryResponseDto>(_categoryRepository.GetCategory(id));

            if (!ModelState.IsValid)
                return BadRequest(new ApiResponse<object>(400, ModelState));

            return Ok(new ApiResponse<CategoryResponseDto>(200, category));
        }

        [HttpGet("pokemon/{id}")]
        [ProducesResponseType(typeof(ApiResponse<List<PokemonResponseDto>>), 200)]
        [ProducesResponseType(typeof(ApiResponse<object>), 400)]
        [ProducesResponseType(typeof(ApiResponse<object>), 404)]
        public IActionResult GetPokemonByCategory(int id)
        {
            if (!_categoryRepository.CategoryExists(id))
                return NotFound(new ApiResponse<object>(404, "Category not found"));

            var pokemons = _mapper.Map<List<PokemonResponseDto>>(_categoryRepository.GetPokemonByCategory(id));

            if (!ModelState.IsValid)
                return BadRequest(new ApiResponse<object>(400, ModelState));

            return Ok(new ApiResponse<List<PokemonResponseDto>>(200, pokemons));
        }

        [HttpPost]
        [ProducesResponseType(typeof(ApiResponse<CategoryResponseDto>), 201)]
        [ProducesResponseType(typeof(ApiResponse<object>), 400)]
        [ProducesResponseType(typeof(ApiResponse<object>), 422)]
        [ProducesResponseType(typeof(ApiResponse<object>), 500)]
        public IActionResult CreateCategory([FromBody] CategoryCreateRequestDto categoryCreate)
        {
            if (categoryCreate == null)
                return BadRequest(ModelState);

            var category = _categoryRepository.GetCategories()
                .Where(c => c.Name.Trim().ToUpper() == categoryCreate.Name.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (category != null)
            {
                ModelState.AddModelError("", "Category already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(new ApiResponse<object>(400, ModelState));

            var categoryMap = _mapper.Map<Category>(categoryCreate);

            if (!_categoryRepository.CreateCategory(categoryMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            var createdCategory = _mapper.Map<CategoryResponseDto>(categoryMap);
            return CreatedAtAction(
                nameof(GetCategory), 
                new { id = createdCategory.Id }, 
                new ApiResponse<CategoryResponseDto>(201, createdCategory)
            );
        }

        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult UpdateCategory(int id, [FromBody] CategoryUpdateRequestDto updatedCategory)
        {
            if (updatedCategory == null)
                return BadRequest(ModelState);

            if (id != updatedCategory.Id)
                return BadRequest(ModelState);

            if (!_categoryRepository.CategoryExists(id))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var categoryMap = _mapper.Map<Category>(updatedCategory);

            if (!_categoryRepository.UpdateCategory(categoryMap))
            {
                ModelState.AddModelError("", "Something went wrong updating category");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult DeleteCategory(int id)
        {
            if (!_categoryRepository.CategoryExists(id))
            {
                return NotFound();
            }

            var categoryToDelete = _categoryRepository.GetCategory(id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_categoryRepository.DeleteCategory(categoryToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting category");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
    }
}