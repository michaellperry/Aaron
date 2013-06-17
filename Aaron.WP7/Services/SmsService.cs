using System;
using System.IO;
using System.Net;

namespace Aaron.WP7.Services
{
    public class SmsService
    {
        private const string AuthorizationServiceUrl = "http://aaronsms.azurewebsites.net/api/authorization";
        private const string NotificationServiceUrl = "http://aaronsms.azurewebsites.net/api/notification";

        public static void SendMessage(string phone, string body)
        {
            var request = WebRequest.CreateHttp(NotificationServiceUrl);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.BeginGetRequestStream(requestStreamResult =>
            {
                var requestStream = request.EndGetRequestStream(requestStreamResult);
                using (var writer = new StreamWriter(requestStream))
                {
                    writer.Write(String.Format("phone={0}&body={1}",
                        HttpUtility.UrlEncode(phone),
                        HttpUtility.UrlEncode(body)));
                }
                request.BeginGetResponse(responseResult =>
                {
                    var response = request.EndGetResponse(responseResult);
                }, null);
            }, null);
        }

        public static void SendAuthorizationRequest(string phone)
        {
            var request = WebRequest.CreateHttp(AuthorizationServiceUrl);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.BeginGetRequestStream(requestStreamResult =>
            {
                var requestStream = request.EndGetRequestStream(requestStreamResult);
                using (var writer = new StreamWriter(requestStream))
                {
                    writer.Write(String.Format("phone={0}",
                        HttpUtility.UrlEncode(phone)));
                }
                request.BeginGetResponse(responseResult =>
                {
                    var response = request.EndGetResponse(responseResult);
                }, null);
            }, null);
        }
    }
}
