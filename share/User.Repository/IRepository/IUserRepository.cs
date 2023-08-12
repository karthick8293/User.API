using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Data.DTO;

namespace User.Repository.IRepository
{
    public interface IUserRepository
    {
        Task<List<UserDTO>> GetAllUser();
        Task<UserDTO> GetUserById(int UserId);
        Task<bool> SaveUser(UserDTO objUser);
        Task<bool> UpdateUser(UserDTO objUser);
        Task<bool> DeleteUserById(int UserId);
    }
}
