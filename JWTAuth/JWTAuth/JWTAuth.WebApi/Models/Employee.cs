namespace JWTAuth.WebApi.Models
{
    public class Employee
    {
        public int? EmployeeID { get; set; }
       
        public string? EmployeeName { get; set; }
        public string? LoginID { get; set; }
        public string? Designation { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? MaritalStatus { get; set; }
        public string? Gender { get; set; }
        public DateTime? HireDate { get; set; }
        public string? Password { get; set; }       
        public string? Status { get; set; }
        public DateTime? AddedDate { get; set; }
        public int AddedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int UpdatedBy { get; set; }
    }
}
