using Asp.Versioning;
using AutoMapper;
using MagicVilla_VillaAPI.Models;
using MagicVilla_VillaAPI.Models.DTO;
using MagicVilla_VillaAPI.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace MagicVilla_VillaAPI.Controllers
{
    [Route("api/v{version:apiVersion}/UserAuth")]
    [ApiController]
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    public class UserAPIController : Controller
    {
        private readonly IUserRepository dbUser;
        private readonly IMapper mapper;
        private APIResponse _APIResponse;

        public UserAPIController(IUserRepository dbUser, IMapper mapper)
        {
            this.dbUser = dbUser;
            this.mapper = mapper;
            _APIResponse = new();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO model)
        {
            var loginResponse = await dbUser.Login(model);
            if (loginResponse.User == null || string.IsNullOrEmpty(loginResponse.Token))
            {
                _APIResponse.ErrorMessage.Add("Invalid username or password");
                _APIResponse.IsSuccess = false;
                _APIResponse.StatusCode = System.Net.HttpStatusCode.BadRequest;
                return BadRequest(_APIResponse);
            }

            _APIResponse.Result = loginResponse;
            _APIResponse.IsSuccess = true;
            _APIResponse.StatusCode = System.Net.HttpStatusCode.OK;
            return Ok(_APIResponse);

        }


        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegistrationRequestDTO model)
        {
            bool isUnique = dbUser.IsUniqueUser(model.Username);
            if(!isUnique)
            {
                _APIResponse.ErrorMessage.Add("User already exists");
                _APIResponse.IsSuccess = false;
                _APIResponse.StatusCode = System.Net.HttpStatusCode.BadRequest;
                return BadRequest(_APIResponse);
            }

            var user = await dbUser.Register(model);
            if (user == null)
            {
                _APIResponse.ErrorMessage.Add("Error while registering");
                _APIResponse.IsSuccess = false;
                _APIResponse.StatusCode = System.Net.HttpStatusCode.BadRequest;
                return BadRequest(_APIResponse);
            }

            _APIResponse.Result = user;
            _APIResponse.IsSuccess = true;
            _APIResponse.StatusCode = System.Net.HttpStatusCode.OK;
            return Ok(_APIResponse);
        }
    }
}
