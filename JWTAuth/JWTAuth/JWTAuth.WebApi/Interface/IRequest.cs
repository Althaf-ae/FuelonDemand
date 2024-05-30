using JWTAuth.WebApi.Models;

namespace JWTAuth.WebApi.Interface
{
    public interface IRequest
    {
        public List<Request> GetRequestDetails();

        public Request GetRequestDetails(int id);
       
        public void AddRequest(Request request);

        public void UpdateRequest(Request request);

        public Request DeleteRequest(int id);

        public bool CheckRequest(int id);
        public List<RequestView> GetRequestDetailList();
        public List<RequestAdminView> GetAdminRequestDetailList();
    }
}
