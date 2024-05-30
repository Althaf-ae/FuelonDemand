using JWTAuth.WebApi.Enum;
using JWTAuth.WebApi.Interface;
using JWTAuth.WebApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace JWTAuth.WebApi.Repository
{
    public class RequestRepository : IRequest
    {
        readonly DatabaseContext _dbContext = new();

        public RequestRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Request> GetRequestDetails()
        {
            try
            {
                

                return _dbContext.Request.ToList();
            }
            catch
            {
                throw;
            }
        }
        public List<RequestView> GetRequestDetailList()
        {
            try
            {
                RequestView requestView;
              
                List<Request> request = new List<Request>();
                List<RequestView> requestList = new List<RequestView>();
                List<PlaceMaster> placeMaster = new List<PlaceMaster>();
                List<FuelMaster> fuelMaster = new List<FuelMaster>();
                placeMaster=_dbContext.PlaceMaster.ToList();
                fuelMaster = _dbContext.FuelMaster.ToList();
                request = _dbContext.Request.ToList();
                foreach(var data in request)
                {
                    requestView = new RequestView();
                    requestView.RequestId = data.RequestId;
                    requestView.UserId = data.UserId;
                    requestView.AddedDate = data.AddedDate;
                    requestView.RequestDate = data.RequestDate;
                    requestView.Comment = data.Comment;
                    requestView.PlaceId = placeMaster.Find(x=>x.PlaceId==data.PlaceId).Name.ToString();
                    if (data.FuelId != 0)
                    {
                        requestView.FuelName = fuelMaster.Find(x => x.FuelId == data.FuelId).FuelName.ToString();
                    }
                    if (data.Status == 'R')
                    {
                        requestView.Status = "Open";
                    }
                    else if (data.Status == 'A')
                    {
                        requestView.Status = "Approved";
                    }
                    else
                    {
                        requestView.Status = "Rejected";
                    }
                    requestList.Add(requestView);
                }
                return requestList;
            }
            catch
            {
                throw;
            }
        }
        public List<RequestAdminView> GetAdminRequestDetailList()
        {
            try
            {
                RequestAdminView requestView;

                List<Request> request = new List<Request>();
                List<RequestAdminView> requestList = new List<RequestAdminView>();
                List<UserInfo> userInfo = new List<UserInfo>();
                List<PlaceMaster> placeMaster = new List<PlaceMaster>();
                List<FuelMaster> fuelMaster = new List<FuelMaster>();
                placeMaster = _dbContext.PlaceMaster.ToList();
                fuelMaster = _dbContext.FuelMaster.ToList();
                userInfo = _dbContext.UserInfos.ToList();
                request = _dbContext.Request.ToList();
                foreach (var data in request)
                {
                    requestView = new RequestAdminView();
                    requestView.RequestId = data.RequestId;
                    requestView.UserId = data.UserId;
                    requestView.AddedDate = data.AddedDate;
                    requestView.RequestDate = data.RequestDate;
                    requestView.Comment = data.Comment;
                    requestView.UpdatedDate = data.UpdatedDate;
                    requestView.PlaceName = placeMaster.Find(x => x.PlaceId == data.PlaceId).Name.ToString();
                    if (data.FuelId != 0)
                    {
                        requestView.Fuel = fuelMaster.Find(x => x.FuelId == data.FuelId).FuelName.ToString();
                    }
                    if (data.UserId != 0)
                    {
                        requestView.UserName = userInfo.Find(x => x.UserId == data.UserId).UserName.ToString();
                    }
                    if (data.Status == 'O')
                    {
                        requestView.Status = "O";
                    }
                    else if (data.Status == 'A')
                    {
                        requestView.Status = "A";
                    }
                    else if (data.Status == 'P')
                    {
                        requestView.Status = "P";
                    }
                    else
                    {
                        requestView.Status = "R";
                    }

                    requestList.Add(requestView);
                }
                return requestList;
            }
            catch
            {
                throw;
            }
        }
        public Request GetRequestDetails(int id)
        {
            try
            {             

                Request? request = _dbContext.Request.Find(id);
                if (request != null)
                {
                    return request;
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
        public void AddRequest(Request request)
        {
            try
            {
                request.RequestDate = DateTime.Now;
                request.Status ='O';
                request.AddedDate = DateTime.Now;
                request.AddedBy = 1;
                request.UpdatedBy = 1;
                request.UpdatedDate = DateTime.Now;
                _dbContext.Request.Add(request);
                _dbContext.SaveChanges();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }        
        public void UpdateRequest(Request request)
        {
            try
            {
             

                Request? requestDetails = _dbContext.Request.Find(request.RequestId);
                if (request.Status == '1')
                {
                    requestDetails.Status = 'A';
                }
                else if ( request.Status == '2')
                    {
                        requestDetails.Status = 'R';
                    }
                else
                {
                    requestDetails.Status = 'P';
                }
                requestDetails.UpdatedDate = DateTime.Now;
                requestDetails.Comment = request.Comment;
                _dbContext.Entry(requestDetails).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public Request DeleteRequest(int id)
        {
            try
            {
                Request? request = _dbContext.Request.Find(id);

                if (request != null)
                {
                    _dbContext.Request.Remove(request);
                    _dbContext.SaveChanges();
                    return request;
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

        public bool CheckRequest(int id)
        {
            return _dbContext.Request.Any(e => e.RequestId == id);
        }
    }
}
