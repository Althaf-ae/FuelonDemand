namespace JWTAuth.WebApi.Models
{
    public class PlaceMaster
    {
        public int PlaceId { get; set; }
        public string? Name { get; set; }
        public string? Status { get; set; }
        public DateTime? AddedDate { get; set; }
        public int AddedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int UpdatedBy { get; set; }
    }
}
