using JWTAuth.WebApi.Interface;
using JWTAuth.WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace JWTAuth.WebApi.Repository
{
    public class FuelRepository : IFuel
    {
        readonly DatabaseContext _dbContext = new();

        public FuelRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<FuelMaster> GetFuelDetails()
        {
            try
            {
                return _dbContext.FuelMaster.ToList();
            }
            catch
            {
                throw;
            }
        } 
        public FuelMaster GetFuelDetails(int id)
        {
            try
            {
                FuelMaster? fuel = _dbContext.FuelMaster.Find(id);
                if (fuel != null)
                {
                    return fuel;
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
        public void AddPlace(FuelMaster fuel)
        {
            try
            {
                _dbContext.FuelMaster.Add(fuel);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }        
        public void UpdatePlace(FuelMaster fuel)
        {
            try
            {
                _dbContext.Entry(fuel).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public FuelMaster DeletePlace(int id)
        {
            try
            {
                FuelMaster? fuel = _dbContext.FuelMaster.Find(id);

                if (fuel != null)
                {
                    _dbContext.FuelMaster.Remove(fuel);
                    _dbContext.SaveChanges();
                    return fuel;
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
            return _dbContext.FuelMaster.Any(e => e.FuelId == id);
        }
    }
}
