
using Project_Skeleton.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Skeleton.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(UserDTO user);
    }
}
