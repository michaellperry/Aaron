using System.Linq;
using System.Web.Http;
using Aaron.MVC.Models;
using Aaron.MVC.Services;

namespace Aaron.MVC.Controllers
{
    public class AuthorizationController : ApiController
    {
        public void Post([FromBody]AuthorizationRequest authorizationRequest)
        {
            using (var context = new CaregiverContext())
            {
                var caregiver = context.Caregivers.FirstOrDefault(
                    c => c.Phone == authorizationRequest.phone);

                if (caregiver == null)
                {
                    caregiver = context.Caregivers.Create();
                    caregiver.Phone = authorizationRequest.phone;
                    context.Caregivers.Add(caregiver);
                }
                if (!caregiver.AuthorizationRequested)
                {
                    caregiver.AuthorizationRequested = true;
                    SmsService.SendMessage(authorizationRequest.phone, "This is the Aaron app for Windows Phone. Reply with A to authorize text messages.");
                }
                context.SaveChanges();
            }
        }
    }
}