using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Project_Skeleton.Controllers;
using Project_Skeleton.Data;
using Project_Skeleton.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MontrealDatingApp.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : BaseController
    {
        // private readonly IUserRepository userRepository;
        // private readonly IMapper _mapper;
        private readonly DataContext _dataContext;
        private readonly ILogger<UsersController> _logger;

        public UsersController(DataContext dataContext, ILogger<UsersController> logger)
        {
            _dataContext = dataContext;
            _logger = logger;
            // Try to automap instead of using data _dataContext
            // this._mapper = _mapper;
            // this.userRepository = userRepository;
        }


        // Asynchronous HTTP GET api/users
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsers()
        {
            return await _dataContext.Users.ToListAsync();
        }


        // Asynchronous HTTP GET api/users/{id}
        [Authorize]
        [HttpGet("{id}")]
        public UserDTO GetUser(int id)
        {
            // await _dataContext.Users.Where(x => x.Id == Id).ToListAsync();
            // await _dataContext.Users.Where(x => x.Username == Username).ToListAsync();
            // return await _dataContext.Users.FindAsync(id);
            using (_dataContext)
            {
                var usersList = _dataContext.Users.FromSqlRaw(
                    "SELECT * FROM Users WHERE UserId=@userId",
                    new SqlParameter("@userId", id)
                    ).FirstOrDefault();
                return usersList;
            }

        }


        [Authorize]
        [HttpPut]
        public ActionResult<UserDTO> PutUser(UserDTO user)
        {
            _dataContext.Users.Update(user);
            return user;
        }


    }
}
