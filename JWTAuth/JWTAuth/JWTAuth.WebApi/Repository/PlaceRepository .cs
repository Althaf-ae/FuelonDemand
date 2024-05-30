using JWTAuth.WebApi.Interface;
using JWTAuth.WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace JWTAuth.WebApi.Repository
{
    public class PlaceRepository : IPlace
    {
        readonly DatabaseContext _dbContext = new();

        public PlaceRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<PlaceMaster> GetPlaceDetails()
        {
            try
            {
                return _dbContext.PlaceMaster.ToList();
            }
            catch
            {
                throw;
            }
        } 
        public PlaceMaster GetPlaceDetails(int id)
        {
            try
            {
                PlaceMaster? place = _dbContext.PlaceMaster.Find(id);
                if (place != null)
                {
                    return place;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }      
        public void AddPlace(PlaceMaster place)
        {
            try
            {
                _dbContext.PlaceMaster.Add(place);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }        
        public void UpdatePlace(PlaceMaster place)
        {
            try
            {
                _dbContext.Entry(place).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public PlaceMaster DeletePlace(int id)
        {
            try
            {
                PlaceMaster? place = _dbContext.PlaceMaster.Find(id);

                if (place != null)
                {
                    _dbContext.PlaceMaster.Remove(place);
                    _dbContext.SaveChanges();
                    return place;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }

        public bool CheckPlace(int id)
        {
            return _dbContext.PlaceMaster.Any(e => e.PlaceId == id);
        }
    }
}
