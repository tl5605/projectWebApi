using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Text.Json;
using DTOs;
using AutoMapper;


namespace projectWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserServiec _UserServiec;
        private IMapper _mapper;
        private readonly ILogger<UsersController> _logger;
        public UsersController(IUserServiec UserServiec, IMapper mapper, ILogger<UsersController> logger)
        {
            _UserServiec = UserServiec;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            User user = await _UserServiec.GetUserById(id);
            if (user==null)

                return NotFound();
            return Ok(user);
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<User>> Login([FromBody] UserLoginDto userLoginDto)
        {
            User user = _mapper.Map<UserLoginDto, User>(userLoginDto);
            User NewUser = await _UserServiec.Login(user);
            if (NewUser != null)
            {
                return Ok(NewUser);
            }
            return Unauthorized();
        }


        [HttpPost]
        public async Task<ActionResult> Register([FromBody] User user)
        {
            int score = _UserServiec.StrongPassword(user.Password);
            if (score < 2)
                return BadRequest();

            User newUser = await _UserServiec.Register(user);
            if(newUser==null)
            {
                return ValidationProblem();
            }
            return CreatedAtAction(nameof(GetUserById), new { id = user.UserId }, user);
            
        }
        [HttpPost]
        [Route("checkPassword")]
        public ActionResult<int> checkPassword([FromBody] string password)
        {
            return _UserServiec.StrongPassword(password);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<User>> UpdateUser(int id, [FromBody] User userToUpdate)
        {

            User updateUser = await _UserServiec.UpdateUser(id, userToUpdate);
            if(updateUser==null)
            {
                return ValidationProblem();
            }
            return updateUser;
        }

        // DELETE api/<UsersController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
