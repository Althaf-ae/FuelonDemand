using JWTAuth.WebApi.Models;

namespace JWTAuth.WebApi.Interface
{
    public interface ISALES
    {
        public List<Sales> GetSalesDetails();

        public Sales GetSalesDetails(int id);
       
        public void AddSales(Sales request);

        public void UpdateSales(Sales request);

        public Sales DeleteSales(int id);

        public bool CheckSales(int id);
    }
}
