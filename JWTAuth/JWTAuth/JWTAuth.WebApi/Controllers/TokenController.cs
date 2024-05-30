using JWTAuth.WebApi.Interface;
using JWTAuth.WebApi.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JWTAuth.WebApi.Controllers
{
    [Route("api/token")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        public IConfiguration _configuration;
        public IUserInfo _iUser;
        private readonly DatabaseContext _context;

        public TokenController(IConfiguration config, DatabaseContext context, IUserInfo iuser)
        {
            _configuration = config;
            _context = context;
            _iUser = iuser;
        }

        [HttpPost]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> Post(UserInfo _userData)
        {
            try
            {
                if (_userData != null && _userData.Password != null)
                {
                    var user = await GetUser(_userData.UserName, _userData.Password);

                    if (user != null)
                    {
                        UserInfoView userView = new UserInfoView();
                        //create claims details based on the user information
                        var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("UserId", user.UserId.ToString()),
                        new Claim("DisplayName", user.DisplayName),
                        new Claim("UserName", user.UserName),
                        new Claim("Email", user.Email)
                    };
                        var sa = _configuration["ConnectionStrings:dbConnection"];
                        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                        var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                        var token = new JwtSecurityToken(
                            _configuration["Jwt:Issuer"],
                            _configuration["Jwt:Audience"],
                            claims,
                            expires: DateTime.UtcNow.AddMinutes(10),
                            signingCredentials: signIn);

                        userView.Tocken = new JwtSecurityTokenHandler().WriteToken(token);
                        userView.UserId = user.UserId;
                        userView.UserName = user.UserName;
                        userView.Email = user.Email;
                        userView.AddedDate = user.AddedDate;
                        userView.UserType = user.UserType.Trim('"');
                        userView.Status = user.Status;

                        return Ok(userView);
                    }
                    else
                    {
                        return Ok();
                    }
                }
                else
                {
                    return BadRequest();
                }
            }
            catch(Exception ex)
            {
                return BadRequest();
            }
        }

        private async Task<UserInfo> GetUser(string email, string password)
        {try
            {
                return await _context.UserInfos.FirstOrDefaultAsync(u => u.Email == email && u.Password == password && u.Status=="A" && u.IsLock==0);
            }
            catch (Exception ex)
            {
                UserInfo userInfo = new UserInfo();
                return userInfo;
            }
        }





        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Request>>> Get()
        //{
        //    var request = await Task.FromResult(_IUserInfo.GetUserDetails());
        //    if (request == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(request);

        //}

        //// GET api/employee/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<UserInfo>> Get(int id)
        //{
        //    var request = await Task.FromResult(_IUserInfo.GetUserDetails(id));
        //    if (request == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(request);
        //}

        // POST api/employee
        [HttpPost]
        [Route("SaveUser")]
        public async Task<ActionResult<UserInfo>> SaveUser(UserInfo userInfo)
        {          

            _iUser.AddUser(userInfo);
            return await Task.FromResult(userInfo);
        }


        //// PUT api/employee/5
        //[HttpPut("{id}")]
        //public async Task<ActionResult<UserInfo>> Put(int id, UserInfo userInfo)
        //{
        //    if (id != userInfo.UserId)
        //    {
        //        return BadRequest();
        //    }
        //    try
        //    {
        //        _IUserInfo.UpdateUser(userInfo);
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!RequestExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }
        //    return await Task.FromResult(userInfo);
        //}

        //// DELETE api/employee/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<UserInfo>> Delete(int id)
        //{
        //    var userInfo = _IUserInfo.DeleteUser(id);
        //    return await Task.FromResult(userInfo);
        //}

        //private bool RequestExists(int id)
        //{
        //    return _IUserInfo.CheckUser(id);
        //}
    }
}
