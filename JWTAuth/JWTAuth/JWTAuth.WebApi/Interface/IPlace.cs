using JWTAuth.WebApi.Models;

namespace JWTAuth.WebApi.Interface
{
    public interface IPlace
    {
        public List<PlaceMaster> GetPlaceDetails();

        public PlaceMaster GetPlaceDetails(int id);
       
        public void AddPlace(PlaceMaster request);

        public void UpdatePlace(PlaceMaster request);

        public PlaceMaster DeletePlace(int id);

        public bool CheckPlace(int id);
    }
}
