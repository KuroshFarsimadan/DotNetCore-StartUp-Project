
using Project_Skeleton.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Skeleton.Interfaces
{
    public interface IUserRepository
    {
        Task<UserDTO> GetUserById(int id);
        Task<UserDTO> GetUserByUsername(string username);
        Task<UserDTO> GetUserPublicByUsername(string username);
        Task<IEnumerable<UserDTO>> GetUsers();
        Task<IEnumerable<UserDTO>> GetUsersPublic();
        Task<bool> PostAll();
        void Update(UserDTO user);
    }
}
