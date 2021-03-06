﻿using System.Linq;
using System.Text.RegularExpressions;
using Aaron.MVC.Models;

namespace Aaron.MVC.Services
{
    public static class ApplicationService
    {
        private static Regex NonDigit = new Regex("[^0-9]");

        public static string NormalizePhone(string phone)
        {
            if (phone == null)
                return null;

            phone = NonDigit.Replace(phone, "");
            if (phone.Length == 10)
                return "1" + phone;
            else
                return phone;
        }

        public static Caregiver GetCaregiverAndRequestAuthorization(string phone, CaregiverContext context)
        {
            var caregiver = context.Caregivers.FirstOrDefault(c =>
                c.Phone == phone);
            if (caregiver == null)
            {
                caregiver = context.Caregivers.Create();
                caregiver.Phone = phone;
                context.Caregivers.Add(caregiver);
            }
            if (!caregiver.AuthorizationRequested)
            {
                caregiver.AuthorizationRequested = true;
                SmsService.SendMessage(phone, "This is the Aaron app for Windows Phone. Reply with A to authorize text messages.");
            }
            return caregiver;
        }
    }
}