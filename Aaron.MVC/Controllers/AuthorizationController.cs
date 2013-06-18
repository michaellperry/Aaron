using System.Web.Http;
using Aaron.MVC.Models;
using Aaron.MVC.Services;

namespace Aaron.MVC.Controllers
{
    public class AuthorizationController : ApiController
    {
        public void Post([FromBody]AuthorizationRequest authorizationRequest)
        {
            var phone = ApplicationService.NormalizePhone(authorizationRequest.phone);
            using (var context = new CaregiverContext())
            {
                ApplicationService.GetCaregiverAndRequestAuthorization(phone, context);
                context.SaveChanges();
            }
        }
    }
}