using System;
using System.Linq;
using System.Web.Http;
using Aaron.MVC.Models;
using Aaron.MVC.Services;
using System.Web.Configuration;

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
                    DateTime today = DateTime.Today;
                    if (caregiver.LastMessageDate == null ||
                        caregiver.LastMessageDate.Value < today)
                    {
                        caregiver.MessagesToday = 1;
                    }
                    else
                    {
                        caregiver.MessagesToday++;
                    }
                    caregiver.LastMessageDate = today;

                    int maxMessagesPerDay;
                    if (!int.TryParse(WebConfigurationManager.AppSettings["MaxMessagesPerDay"], out maxMessagesPerDay))
                        maxMessagesPerDay = 10;
                    if (maxMessagesPerDay > 50)
                        maxMessagesPerDay = 50;
                    if (caregiver.MessagesToday <= maxMessagesPerDay)
                        SmsService.SendMessage(phone, body);
                }
                context.SaveChanges();
            }
        }
    }
}