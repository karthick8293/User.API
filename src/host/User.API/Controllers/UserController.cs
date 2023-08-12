using Microsoft.AspNetCore.Mvc;
using User.Data.DTO;
using User.Service.IService;

namespace User.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private IUserService _UserService;
        public UserController(IUserService userService)
        {
            _UserService = userService;
        }
        [HttpGet("~/api/get-user-list", Name = "GetUserList")]
        public async Task<IEnumerable<UserDTO>> GetUserList()
        {
            var GetUser = await _UserService.GetAllUser();
            return (GetUser);
        }
        [HttpGet("~/api/get-user-Id/{id}", Name ="GetUserById")]
        public async Task<UserDTO> GetUserById(int id)
        {
            var GetUserById = await _UserService.GetUserById(id);
            return (GetUserById);
        }
        [HttpPost("~/api/save-user", Name = "SaveUserInfo")]
        public async Task<bool> SaveUserInfo(UserDTO objUser)
        {
            var SaveUser = await _UserService.SaveUser(objUser);
            return (SaveUser);
        }

        [HttpPut("~/api/update-user", Name = "UpdateUserInfo")]
        public async Task<bool> UpdateUserInfo(UserDTO objUser)
        {
            var UpdateUser = await _UserService.UpdateUser(objUser);
            return (UpdateUser);
        }
        [HttpDelete("~/api/delete-user-Id/{id}", Name = "DeleteUserById")]
        public async Task<bool> DeleteUserById(int id)
        {
            var DeteteUserById = await _UserService.DeleteUserById(id);
            return (DeteteUserById);
        }
    }
}
