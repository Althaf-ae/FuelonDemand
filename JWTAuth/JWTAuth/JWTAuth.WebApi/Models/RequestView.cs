using System.ComponentModel.DataAnnotations;

namespace JWTAuth.WebApi.Models
{
    public class RequestView
    {     
        public int? RequestId { get; set; }
        public int UserId { get; set; }
        public string PlaceId { get; set; }
        public string FuelName { get; set; }
        public string Status { get; set; }
        public string Comment { get; set; }
        public DateTime? RequestDate { get; set; }
        public DateTime? AddedDate { get; set; }
        public int AddedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int UpdatedBy { get; set; }
    }

    public class RequestAdminView
    {
        public int? RequestId { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int PlaceId { get; set; }
        public string PlaceName { get; set; }
        public int FuelId { get; set; }
        public string Fuel { get; set; }

        public string Status { get; set; }
        public string Comment { get; set; }
        public DateTime? RequestDate { get; set; }
        public DateTime? AddedDate { get; set; }
        public int AddedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int UpdatedBy { get; set; }
    }
}
