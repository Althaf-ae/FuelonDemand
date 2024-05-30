using JWTAuth.WebApi.Interface;
using JWTAuth.WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace JWTAuth.WebApi.Repository
{
    public class FeedbackRepository : IFeedback
    {
        readonly DatabaseContext _dbContext = new();

        public FeedbackRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Feedback> GetFeedbackDetails()
        {
            try
            {
                return _dbContext.Feedback.ToList();
            }
            catch
            {
                throw;
            }
        }
        public List<FeedbackAdminView> GetAdminFeedbackDetailList()
        {
            try
            {
                FeedbackAdminView requestView;

                List<Feedback> request = new List<Feedback>();
                List<FeedbackAdminView> requestList = new List<FeedbackAdminView>();
                List<UserInfo> userInfo = new List<UserInfo>();
                List<PlaceMaster> placeMaster = new List<PlaceMaster>();
                List<FuelMaster> fuelMaster = new List<FuelMaster>();
                placeMaster = _dbContext.PlaceMaster.ToList();
                fuelMaster = _dbContext.FuelMaster.ToList();
                userInfo = _dbContext.UserInfos.ToList();
                request = _dbContext.Feedback.ToList();
                foreach (var data in request)
                {
                    requestView = new FeedbackAdminView();
                    requestView.RequestId = data.RequestId;
                    requestView.FeedbackID = data.FeedbackID;
                    requestView.UserId = data.UserId;
                    requestView.FeedbackDate = data.FeedbackDate;
                    requestView.AdminComment = data.AdminComment;
                    requestView.Comment = data.Comment;
                    requestView.ModifiedDate = data.ModifiedDate;                    
                    
                    if (data.UserId != 0)
                    {
                        requestView.UserName = userInfo.Find(x => x.UserId == data.UserId).UserName.ToString();
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
        public Feedback GetFeedbackDetails(int id)
        {
            try
            {
                Feedback? feedback = _dbContext.Feedback.Find(id);
                if (feedback != null)
                {
                    return feedback;
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                throw;
            }
        }      
        public void AddFeedback(Feedback feedback)
        {
            try
            {
                feedback.FeedbackDate = DateTime.Now;
                feedback.ModifiedDate = DateTime.Now;
                _dbContext.Feedback.Add(feedback);
                _dbContext.SaveChanges();
            }
            catch(Exception ex)
            {
                throw;
            }
        }        
        public void UpdateFeedback(Feedback feedback)
        {
            try
            {
                _dbContext.Entry(feedback).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
        public void UpdateAdminFeedback(FeedbackAdmin request)
        {
            try
            {
                Feedback? feedback = _dbContext.Feedback.Find(request.FeedbackID);
                feedback.AdminComment = request.AdminComment;
                _dbContext.Entry(feedback).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
       
        public Feedback DeleteFeedback(int id)
        {
            try
            {
                Feedback? feedback = _dbContext.Feedback.Find(id);

                if (feedback != null)
                {
                    _dbContext.Feedback.Remove(feedback);
                    _dbContext.SaveChanges();
                    return feedback;
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                throw;
            }
        }

        public bool CheckFeedback(int id)
        {
            return _dbContext.Feedback.Any(e => e.FeedbackID == id);
        }
    }
}
