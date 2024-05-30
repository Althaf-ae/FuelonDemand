using JWTAuth.WebApi.Models;

namespace JWTAuth.WebApi.Interface
{
    public interface IFuel
    {
        public List<FuelMaster> GetFuelDetails();

        public FuelMaster GetFuelDetails(int id);
       
        public void AddPlace(FuelMaster fuel);

        public void UpdatePlace(FuelMaster fuel);

        public FuelMaster DeletePlace(int id);

        public bool CheckPlace(int id);
    }
}
