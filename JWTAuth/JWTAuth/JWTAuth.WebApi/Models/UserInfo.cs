using System.ComponentModel.DataAnnotations;

namespace JWTAuth.WebApi.Models
{
    public class UserInfo
    {
        [Key]
        public int? UserId { get; set; }
        public string? DisplayName { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Remark { get; set; }
        public string? UserType { get; set; }
        public int Phone { get; set; }
        public int? IsLock { get; set; }
        public string? Status { get; set; }
        public DateTime? AddedDate { get; set; }
        public int AddedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }

    }
}
