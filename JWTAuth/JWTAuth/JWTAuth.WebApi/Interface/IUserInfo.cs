using JWTAuth.WebApi.Models;

namespace JWTAuth.WebApi.Interface
{
    public interface IUserInfo
    {
        public List<UserInfo> GetUserDetails();

        public UserInfo GetUserDetails(int id);
       
        public void AddUser(UserInfo info);

        public void UpdateUser(UserInfo info);

        public UserInfo DeleteUser(int id);

        public bool CheckUser(int id);
       // List<UserInfo> GetRequestDetailList();
    }
}
