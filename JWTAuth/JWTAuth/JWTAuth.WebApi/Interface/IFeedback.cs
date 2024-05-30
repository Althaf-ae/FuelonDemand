using JWTAuth.WebApi.Models;

namespace JWTAuth.WebApi.Interface
{
    public interface IFeedback
    {
        public List<Feedback> GetFeedbackDetails();

        public Feedback GetFeedbackDetails(int id);
       
        public void AddFeedback(Feedback request);

        public void UpdateFeedback(Feedback request);

        public Feedback DeleteFeedback(int id);

        public bool CheckFeedback(int id);
        public List<FeedbackAdminView> GetAdminFeedbackDetailList();
        public void UpdateAdminFeedback(FeedbackAdmin request);

        
    }
}
