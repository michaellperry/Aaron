using System.Web.Http;
using Aaron.MVC.Models;
using Aaron.MVC.Services;

namespace Aaron.MVC.Controllers
{
    public class NotificationController : ApiController
    {
        // POST api/notification
        public void Post([FromBody]Message message)
        {
            SmsService.SendMessage(message.phone, message.body);
        }
    }
}