using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project_Skeleton.Entities;
using Project_Skeleton.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Skeleton.Controllers
{
    [ApiController]
    [Route("api/v2/[controller]")]
    public class UsersV2Controller : BaseController
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UsersV2Controller(IUserRepository userRepository, IMapper mapper)
        {

            // Try to automap instead of using data context
            this._userRepository = userRepository;
            this._mapper = mapper;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsers()
        {
            var users = await _userRepository.GetUsersPublic();
            return Ok(users);
        }

        [Authorize]
        [HttpGet("{username}")]
        public async Task<ActionResult<UserDTO>> GetUser(string username)
        {
            return await _userRepository.GetUserPublicByUsername(username);
        }

        /*
        // Asynchronous HTTP GET api/users
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserPublicDto>>> GetUsers()
        {
            var returnable = await userRepository.GetUsersPublic();
            return Ok(returnable);
        }

        // Asynchronous HTTP GET api/users/{id}
        [Authorize]
        [HttpGet("{username}")]
        public async Task<ActionResult<UserPublicDto>> GetUser(string username)
        {
            return await userRepository.GetUserPublicByUsername(username);
        }
         */

        //// BAD PRACTISE Synchronous HTTP GET api/users
        //[HttpGet]
        //public ActionResult<IEnumerable<User>> GetUsers()
        //{
        //    // Blocking thread
        //    var users = _context.Users.ToList();
        //    return users;
        //}

        //// BAD PRACTISE Synchronous HTTP GET api/users/{id}
        //[HttpGet("{id}")]
        //public ActionResult<User> GetUser(int id)
        //{
        //    // Blocking thread
        //    return _context.Users.Find(id);
        //}

    }
}
