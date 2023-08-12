using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Data;
using User.Data.DBModel;
using User.Data.DTO;
using User.Repository.IRepository;

namespace User.Repository.Repository
{
    public class UserRepository: IUserRepository
    {
        private AppDbContext _dbContext;
        public UserRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<UserDTO>> GetAllUser()
        {

            var GetAllUser =await _dbContext.UserInformations.Where(x=>x.IsActive == true).ToListAsync();

            return GetAllUser.Select(x=> new UserDTO { 
                userId = x.UserId,
                userName =x.UserName,
                userAge =x.UserAge, 
                userGender= x.UserGender,
                eMailId =x.EMailId,
                country =x.Country,
                states = x.States,
                isActive = x.IsActive,
                phoneNumber = x.PhoneNumber
            }).ToList();
        }
        public async Task<UserDTO> GetUserById(int UserId)
        {
            UserDTO objUser = new UserDTO();
            var GetAllUser = await _dbContext.UserInformations.Where(x=>x.UserId == UserId && x.IsActive == true).FirstOrDefaultAsync();
            if (GetAllUser != null) 
            {
                objUser.userId = GetAllUser.UserId;
                objUser.userName = GetAllUser.UserName;
                objUser.userAge = GetAllUser.UserAge;
                objUser.userGender = GetAllUser.UserGender;
                objUser.eMailId = GetAllUser.EMailId;
                objUser.country = GetAllUser.Country;
                objUser.states = GetAllUser.States;
                objUser.isActive = GetAllUser.IsActive;
                objUser.phoneNumber = GetAllUser.PhoneNumber;
            }

            return objUser;
        }
        public async Task<bool> SaveUser(UserDTO objUser)
        {
            bool boolUser = false;
            UserInformations DBUser = new UserInformations();
            DBUser.UserName = objUser.userName;
            DBUser.UserAge = objUser.userAge;
            DBUser.UserGender = objUser.userGender;
            DBUser.EMailId = objUser.eMailId;
            DBUser.Country = objUser.country;
            DBUser.States = objUser.states;
            DBUser.IsActive = true;
            DBUser.PhoneNumber = objUser.phoneNumber;
            DBUser.CreatedOn = 1;
            DBUser.CreatedDate = DateTime.UtcNow;
            _dbContext.UserInformations.Add(DBUser);
            await _dbContext.SaveChangesAsync();
            boolUser = true;
            return boolUser;
        }
        public async Task<bool> UpdateUser(UserDTO objUser)
        {
            bool boolUser = false;
            var GetUserById = await _dbContext.UserInformations.Where(x=>x.UserId == objUser.userId && x.IsActive == true).FirstOrDefaultAsync();
            if (GetUserById != null)
            {
                GetUserById.UserId = objUser.userId;
                GetUserById.UserName = objUser.userName;
                GetUserById.UserAge = objUser.userAge;
                GetUserById.UserGender = objUser.userGender;
                GetUserById.EMailId = objUser.eMailId;
                GetUserById.Country = objUser.country;
                GetUserById.States = objUser.states;
                GetUserById.IsActive = true;
                GetUserById.PhoneNumber = objUser.phoneNumber;
                GetUserById.UpdatedOn = objUser.userId;
                GetUserById.UpdatedDate = DateTime.UtcNow;
                await _dbContext.SaveChangesAsync();
                boolUser = true;
            }
            return boolUser;
        }
        public async Task<bool> DeleteUserById(int UserId)
        {
            bool boolUser = false;
            var GetUserById = await _dbContext.UserInformations.Where(x => x.UserId == UserId && x.IsActive == true).FirstOrDefaultAsync();
            if (GetUserById != null)
            {
                GetUserById.IsActive = false;
                GetUserById.DeletedOn = UserId;
                GetUserById.DeletedDate = DateTime.UtcNow;
                await _dbContext.SaveChangesAsync();
                boolUser = true;
            }
            return boolUser;
        }
    }
}
