using System.ComponentModel.DataAnnotations;

namespace JWTAuth.WebApi.Models
{
    public class Request
    {     
        public int? RequestId { get; set; }
        public int UserId { get; set; }
        public int PlaceId { get; set; }
        public int FuelId { get; set; }
        
        public char Status { get; set; }
        public string Comment { get; set; }
        public DateTime? RequestDate { get; set; }
        public DateTime? AddedDate { get; set; }
        public int AddedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int UpdatedBy { get; set; }
    }
}
