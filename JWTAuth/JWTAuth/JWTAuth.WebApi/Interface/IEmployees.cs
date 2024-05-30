using JWTAuth.WebApi.Models;

namespace JWTAuth.WebApi.Interface
{
    public interface IEmployee
    {
        public List<Employee> GetEmployeeDetails();
     
        public Employee GetEmployeeDetails(int id);
        
        
        public void AddEmployee(Employee employee);
      

        public void UpdateEmployee(Employee employee);
        public void BlockEmployee(Employee employee);
        public void UnBlockEmployee(Employee employee);

        public Employee DeleteEmployee(int id);

        public bool CheckEmployee(int id);
    }
}
