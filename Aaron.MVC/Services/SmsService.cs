using System.Web.Configuration;
using Twilio;

namespace Aaron.MVC.Services
{
    public class SmsService
    {
        public static void SendMessage(string phone, string body)
        {
            if (phone == null || phone.Length < 7)
                return;
            if (phone.Length > 10)
                phone = "+" + phone;

            string TwilioPhone = WebConfigurationManager.AppSettings["TwilioPhone"];
            string AccountSid = WebConfigurationManager.AppSettings["TwilioAccountSid"];
            string AuthToken = WebConfigurationManager.AppSettings["TwilioAuthToken"];

            var twilio = new TwilioRestClient(AccountSid, AuthToken);
            twilio.SendSmsMessage(TwilioPhone, phone, body, MessageSent);
        }

        private static void MessageSent(SMSMessage e)
        {
        }
    }
}
