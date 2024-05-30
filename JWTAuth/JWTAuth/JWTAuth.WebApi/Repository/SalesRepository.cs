using JWTAuth.WebApi.Interface;
using JWTAuth.WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace JWTAuth.WebApi.Repository
{
    public class SalesRepository : ISALES
    {
        readonly DatabaseContext _dbContext = new();

        public SalesRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Sales> GetSalesDetails()
        {
            try
            {
                return _dbContext.Sales.ToList();
            }
            catch
            {
                throw;
            }
        } 
        public Sales GetSalesDetails(int id)
        {
            try
            {
                Sales? sales = _dbContext.Sales.Find(id);
                if (sales != null)
                {
                    return sales;
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
        public void AddSales(Sales sales)
        {
            try
            {
                _dbContext.Sales.Add(sales);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }        
        public void UpdateSales(Sales sales)
        {
            try
            {
                _dbContext.Entry(sales).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public Sales DeleteSales(int id)
        {
            try
            {
                Sales? sales = _dbContext.Sales.Find(id);

                if (sales != null)
                {
                    _dbContext.Sales.Remove(sales);
                    _dbContext.SaveChanges();
                    return sales;
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

        public bool CheckSales(int id)
        {
            return _dbContext.Sales.Any(e => e.SalesId == id);
        }
    }
}
