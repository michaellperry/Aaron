using System.Linq;
using System.Web.Http;
using Aaron.MVC.Models;
using Aaron.MVC.Services;

namespace Aaron.MVC.Controllers
{
    public class NotificationController : ApiController
    {
        public void Post([FromBody]Message message)
        {
            if (message == null)
                return;

            string phone = ApplicationService.NormalizePhone(message.phone);
            string body = message.body;

            using (var context = new CaregiverContext())
            {
                var caregiver = ApplicationService.GetCaregiverAndRequestAuthorization(phone, context);
                if (caregiver.Authorized)
                {
                    SmsService.SendMessage(phone, body);
                }
                context.SaveChanges();
            }
        }
    }
}