using AutoMapper;
using Blog.Models;
using Blog.Models.Dtos;
using Blog.Service.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }
        //[Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryService.GetAll();
            var categoriesDto = _mapper.Map<IEnumerable<CategoriesDto>>(categories);

            return Ok(categoriesDto);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await _categoryService.GetById(id);
            var categoryDto = _mapper.Map<CategoryDto>(category);

            return Ok(categoryDto);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CategoryDto categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);
            var newCategory = await _categoryService.Add(category);

            return Created(String.Empty, null); /*_mapper.Map<CategoryDto>(newCategory));*/
        }

        [HttpPatch]
        public async Task<IActionResult> Patch(/*int id,*/ CategoryDto categoryDto)
        {
            int id = categoryDto.Id;
            if (id==0)
                return BadRequest();

            var category = _mapper.Map<Category>(categoryDto);
            _categoryService.Update(category);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deletedCategory = _categoryService.Delete(id);

            return Ok();
        }
    }
}
