using AutoMapper;
using Blog.Models.Dtos;
using Blog.Service.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UsersController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Authenticate(UserDto userDto)
        {
            var user = _userService.Authenticate(userDto.UserName, userDto.Password);

            if (user == null)
                return BadRequest(new {message= "Kullanıcı adı veya parola hatalı"});

            return Ok(user);
        }
    }
}
