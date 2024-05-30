using JWTAuth.WebApi.Interface;
using JWTAuth.WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace JWTAuth.WebApi.Repository
{
    public class UserInfoRepository : IUserInfo
    {
        readonly DatabaseContext _dbContext = new();

        public UserInfoRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<UserInfo> GetUserDetails()
        {
            try
            {
                return _dbContext.UserInfos.ToList();
            }
            catch
            {
                throw;
            }
        } 
        public UserInfo GetUserDetails(int id)
        {
            try
            {
                UserInfo? userInfo = _dbContext.UserInfos.Find(id);
                if (userInfo != null)
                {
                    return userInfo;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }      
        public void AddUser(UserInfo userInfo)
        {
            try
            {
                string[] dates = userInfo.Email.Split('@');
                userInfo.DisplayName= dates[0];
                userInfo.IsLock = 0;
                userInfo.UserType = "A";
                userInfo.Status = "A";
                userInfo.AddedBy = 1;
                userInfo.UpdatedBy = 1;
                userInfo.AddedDate = DateTime.Now;
                userInfo.UpdatedDate = DateTime.Now;
                _dbContext.UserInfos.Add(userInfo);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }        
        public void UpdateUser(UserInfo userInfo)
        {
            try
            {
                _dbContext.Entry(userInfo).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public UserInfo DeleteUser(int id)
        {
            try
            {
                UserInfo? userInfo = _dbContext.UserInfos.Find(id);

                if (userInfo != null)
                {
                    _dbContext.UserInfos.Remove(userInfo);
                    _dbContext.SaveChanges();
                    return userInfo;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }

        public bool CheckUser(int id)
        {
            return _dbContext.UserInfos.Any(e => e.UserId == id);
        }
    }
}
