using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Aaron.MVC.Models;
using Aaron.MVC.Services;

namespace Aaron.MVC.Controllers
{
    public class ConfirmationController : ApiController
    {
        public HttpResponseMessage Post([FromBody]IncomingMessage message)
        {
            if (message == null)
                return PlainText("");

            string phone = ApplicationService.NormalizePhone(message.From);
            string body = message.Body.ToLower();

            string response = "Please text A to authorize text messages, or D to deauthorize.";
            using (var context = new CaregiverContext())
            {
                var caregiver = context.Caregivers.FirstOrDefault(
                    c => c.Phone == phone);

                if (caregiver == null)
                {
                    caregiver = context.Caregivers.Create();
                    caregiver.Phone = phone;
                    context.Caregivers.Add(caregiver);
                }
                if (body == "a")
                {
                    caregiver.Authorized = true;
                    response = "Thank you. Text messages are authorized. Text D at any time to deauthorize.";
                }
                else if (body == "d")
                {
                    caregiver.Authorized = false;
                    response = "Sorry to bother you. Text A at any time if you change your mind.";
                }
                context.SaveChanges();
            }
            
            return PlainText(response);
        }

        private static HttpResponseMessage PlainText(string value)
        {
            var httpResponse = new HttpResponseMessage();
            httpResponse.Content = new StringContent(value);
            return httpResponse;
        }
    }
}