namespace JWTAuth.WebApi.Models
{
    public class Feedback
    {
        public int FeedbackID  { get; set; }
        public int UserId { get; set; }
        public int RequestId { get; set; }       
        public DateTime FeedbackDate { get; set; }
        public char Status { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string AdminComment { get; set; }
        public string Comment { get; set; }

    }

    public class FeedbackAdmin
    {
        public int FeedbackID { get; set; }
        public string AdminComment { get; set; }

    }

    public class FeedbackAdminView
    {
        public int FeedbackID { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int RequestId { get; set; }
        public DateTime FeedbackDate { get; set; }
        public char Status { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string AdminComment { get; set; }
        public string Comment { get; set; }

    }
}
