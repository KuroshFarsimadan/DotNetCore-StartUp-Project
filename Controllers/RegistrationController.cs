using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Project_Skeleton.Controllers;
using Project_Skeleton.Data;
using Project_Skeleton.Entities;
using Project_Skeleton.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Project_Skeleton.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegistrationController : BaseController
    {
        private readonly DataContext _context;
        private readonly ITokenService _tokenService;
        private readonly ILogger<RegistrationController> _logger;

        public RegistrationController(DataContext context, ITokenService tokenService, ILogger<RegistrationController> logger)
        {
            _context = context;
            _tokenService = tokenService;
            _logger = logger;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDTO>> Register(UserDTO userDto)
        {
            try
            {
                var user = new UserDTO();
                if (await UserAlreadyExists(userDto.UserName))
                {
                    // Later, we might use enums and specific classes for request and return.
                    // Never return a hard coded string. Use localization in the frontend.
                    // We don't use the annotation based validation as we want a simple and systematic
                    // structure of the returned error. 
                    userDto.Errors = "Error.UserAlreadyTaken";
                }
                else
                {
                    // Use enums instead of string for returning error messages
                    if (string.IsNullOrEmpty(userDto.Password))
                    {
                        userDto.Errors = "Error.PasswordMissing";
                    }
                    else if (string.IsNullOrEmpty(userDto.UserName))
                    {
                        userDto.Errors = "Error.UsernameInvalid";
                    }
                    else
                    {
                        // Hash-based Message Authentication Code (HMAC) initialization with randomly generated key
                        var passwordHash = new HMACSHA512();
                        user = new UserDTO
                        {
                            UserName = userDto.UserName,
                            PasswordHash = passwordHash.ComputeHash(Encoding.UTF8.GetBytes(userDto.Password)),
                            PasswordSalt = passwordHash.Key
                        };
                        _context.Users.Add(user);
                        await _context.SaveChangesAsync();

                    }
                }
                if (user != null)
                {
                    userDto.Token = _tokenService.GenerateToken(user);
                }

                return userDto;
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to register: " + userDto + " " + ex);
                return BadRequest("Failed to register user");
            }
        }

        // Instead of using below, make a general method to check all the passed user parameters with the user data validation
        private async Task<bool> UserAlreadyExists(string userName)
        {
            return await _context.Users.AnyAsync(
                x => x.UserName == userName.ToLower()
            );
        }

    }
}
