using System.ComponentModel.DataAnnotations;

namespace JWTAuth.WebApi.Models
{
    public class Sales
    {
       
        public int? SalesId { get; set; }
        public int RequestID { get; set; }
        public int EmployeeID { get; set; }
        public int PlaceId { get; set; }
        public char Status { get; set; }
        public DateTime AddedDate { get; set; }
        public string Remark { get; set; }
        public DateTime? RequestedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
