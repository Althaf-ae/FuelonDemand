namespace JWTAuth.WebApi.Models
{
    public class FuelMaster
    {
        public int FuelId { get; set; }
        public string? FuelName { get; set; }
        public string? FuelType { get; set; }
        public int FuelBasePrice { get; set; }
        public string Status { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int UpdatedBy { get; set; }
    }
}
