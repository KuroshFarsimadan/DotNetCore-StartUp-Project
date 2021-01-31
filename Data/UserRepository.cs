using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Project_Skeleton.Data;
using Project_Skeleton.Entities;
using Project_Skeleton.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MontrealDatingApp.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;
        private readonly ILogger<DataContext> _logger;

        public UserRepository(DataContext dataContext, IMapper mapper, ILogger<DataContext> logger)
        {
            _dataContext = dataContext;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<UserDTO> GetUserById(int id)
        {
            this._logger.LogInformation("GetUserById " + id);
            return await _dataContext.Users.FindAsync(id);
        }

        public async Task<UserDTO> GetUserByUsername(string username)
        {
            this._logger.LogInformation("GetUserByUsername " + username);
            return await _dataContext.Users
                .SingleOrDefaultAsync(
                x => x.UserName == username
            );
        }

        public async Task<UserDTO> GetUserPublicByUsername(string username)
        {
            this._logger.LogInformation("GetUserPublicByUsername " + username);
            return await _dataContext.Users.Where(
                x => x.UserName == username
                ).ProjectTo<UserDTO>(
                    _mapper.ConfigurationProvider
                ).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<UserDTO>> GetUsers()
        {
            this._logger.LogInformation("GetUsers");
            return await _dataContext.Users.ToListAsync();
        }

        public async Task<IEnumerable<UserDTO>> GetUsersPublic()
        {
            this._logger.LogInformation("GetUsersPublic");
            return await _dataContext.Users.ProjectTo<UserDTO>(
                _mapper.ConfigurationProvider
                ).ToListAsync();
        }

        public async Task<bool> PostAll()
        {
            // If changed, we will return a larger value than 0
            return await _dataContext.SaveChangesAsync() > 0;
        }

        public void Update(UserDTO user)
        {
            _dataContext.Entry(user).State = EntityState.Modified;
        }
    }
}
