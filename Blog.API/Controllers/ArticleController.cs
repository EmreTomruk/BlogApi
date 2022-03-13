using AutoMapper;
using Blog.Models.Dtos;
using Blog.Models.Entities;
using Blog.Service.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleService _articleService;
        private readonly IMapper _mapper;

        public ArticleController(IArticleService articleService, IMapper mapper)
        {
            _articleService = articleService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var articles = await _articleService.GetAll();
            var articleDtoDto = _mapper.Map<IEnumerable<ArticleDto>>(articles);

            return Ok(articleDtoDto);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var article = await _articleService.GetById(id);
            var articleDto = _mapper.Map<ArticleDto>(article);

            return Ok(articleDto);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ArticleDto articleDto)
        {
            var article = _mapper.Map<Article>(articleDto);
            var newArticle = await _articleService.Add(article);

            return Created(String.Empty, null); /*_mapper.Map<CategoryDto>(newCategory));*/
        }

        [HttpPatch]
        public async Task<IActionResult> Patch(/*int id,*/ ArticleDto articleDto)
        {
            int id = articleDto.Id;
            if (id == 0)
                return BadRequest();

            var article = _mapper.Map<Article>(articleDto);
            _articleService.Update(article);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deletedArticle = _articleService.Delete(id);

            return Ok();
        }
    }
}
