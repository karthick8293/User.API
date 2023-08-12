using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Data.DTO;
using User.Repository.IRepository;
using User.Service.IService;

namespace User.Service.Service
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        public UserService(IUserRepository userRepository) 
        {
            _userRepository=userRepository;
        }
        public async Task<List<UserDTO>> GetAllUser() 
        {
           return await _userRepository.GetAllUser();
        }
        public async Task<UserDTO> GetUserById(int UserId) 
        {
            return await _userRepository.GetUserById(UserId);
        }
        public async Task<bool> SaveUser(UserDTO objUser) 
        {
            return await _userRepository.SaveUser(objUser);
        }
        public async Task<bool> UpdateUser(UserDTO objUser) 
        {
            return await _userRepository.UpdateUser(objUser);
        }
        public async Task<bool> DeleteUserById(int UserId)
        {
            return await _userRepository.DeleteUserById(UserId);
        }
    }
}
