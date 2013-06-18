using System.Web.Configuration;
using Twilio;

namespace Aaron.MVC.Services
{
    public static class SmsService
    {
        public static void SendMessage(string phone, string body)
        {
            if (phone == null || phone.Length < 7)
                return;
            if (phone.Length > 10)
                phone = "+" + phone;

            string twilioPhone = WebConfigurationManager.AppSettings["TwilioPhone"];
            string accountSid = WebConfigurationManager.AppSettings["TwilioAccountSid"];
            string authToken = WebConfigurationManager.AppSettings["TwilioAuthToken"];

            if (authToken == "secret")
                return;

            var twilio = new TwilioRestClient(accountSid, authToken);
            twilio.SendSmsMessage(twilioPhone, phone, body, MessageSent);
        }

        private static void MessageSent(SMSMessage e)
        {
        }
    }
}
