namespace JWTAuth.WebApi.Models
{
    public class vendor
    {
        public int VendorId { get; set; }
        public string? VendorName { get; set; }
        public string? VendorType { get; set; }
        public int VendorStatus { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTill { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
