using JWTAuth.WebApi.Interface;
using JWTAuth.WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace JWTAuth.WebApi.Repository
{
    public class EmployeeRepository : IEmployee
    {
        readonly DatabaseContext _dbContext = new();

        public EmployeeRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Employee> GetEmployeeDetails()
        {
            try
            {
                return _dbContext.Employees.ToList();
            }
            catch(Exception ex)
            {
                throw;
            }
        }
       
        public Employee GetEmployeeDetails(int id)
        {
            try
            {
                Employee? employee = _dbContext.Employees.Find(id);
                if (employee != null)
                {
                    return employee;
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
       
        public void AddEmployee(Employee employee)
        {
            try
            {
                List<UserInfo> userInfo = new List<UserInfo>();
                UserInfo _userInfoDetails = new UserInfo();
                employee.AddedDate = DateTime.Now;
                employee.HireDate = DateTime.Now;
                employee.UpdatedDate = DateTime.Now;
                _dbContext.Employees.Add(employee);
                _dbContext.SaveChanges();

                _userInfoDetails.UserName = employee.EmployeeName;
                _userInfoDetails.IsLock = 0;
                _userInfoDetails.AddedBy = 1;
                _userInfoDetails.AddedDate = DateTime.Now;
                _userInfoDetails.DisplayName = employee.EmployeeName;
                _userInfoDetails.Email = employee.LoginID;
                _userInfoDetails.Password = "123456";
                _userInfoDetails.Phone = 987;
                _userInfoDetails.Status = "D";
                _userInfoDetails.UpdatedBy= 1;
                _userInfoDetails.UpdatedDate= DateTime.Now;
                _userInfoDetails.AddedDate= DateTime.Now;
                _userInfoDetails.AddedBy= 1;

                _dbContext.UserInfos.Add(_userInfoDetails);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
      
        public void UpdateEmployee(Employee employee)
        {
            try
            {
                _dbContext.Entry(employee).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
        public void BlockEmployee(Employee employee)
        {
            try
            {
                employee.Status = "B";
                _dbContext.Entry(employee).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
        public void UnBlockEmployee(Employee employee)
        {
            try
            {
                employee.Status = "A";
                _dbContext.Entry(employee).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
        public Employee DeleteEmployee(int id)
        {
            try
            {
                Employee? employee = _dbContext.Employees.Find(id);

                if (employee != null)
                {
                    _dbContext.Employees.Remove(employee);
                    _dbContext.SaveChanges();
                    return employee;
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

        public bool CheckEmployee(int id)
        {
            return _dbContext.Employees.Any(e => e.EmployeeID == id);
        }
    }
}
