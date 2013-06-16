using System;
using System.Diagnostics;
using System.IO.IsolatedStorage;
using System.Text.RegularExpressions;
using Aaron.WP7.Models;

namespace Aaron.WP7.ViewModels
{
    public class SettingsViewModel
    {
        private readonly Settings _settings;

        public SettingsViewModel(Settings settings)
        {
            _settings = settings;
        }

        public string CaregiverPhone
        {
            get
            {
                return PunctuatePhone(DigitsOnly(_settings.CaregiverPhone));
            }
            set
            {
                _settings.CaregiverPhone = DigitsOnly(value);
                _settings.Save(IsolatedStorageSettings.ApplicationSettings);
            }
        }

        private string DigitsOnly(string phone)
        {
            if (phone == null)
                return null;

            Regex nonDigit = new Regex("[^0-9]");
            return nonDigit.Replace(phone, "");
        }

        private string PunctuatePhone(string phone)
        {
            if (phone == null)
                return null;

            if (phone.Length > 10)
                return AreaPlus(phone);
            else if (phone.Length == 10)
                return Area(phone);
            else if (phone.Length > 7)
                return LocalPlus(phone);
            else if (phone.Length == 7)
                return Local(phone);
            else
                return phone;
        }

        private string AreaPlus(string phone)
        {
            Debug.Assert(phone.Length > 10);
            int pre = phone.Length - 10;
            return String.Format("+{0} {1}",
                phone.Substring(0, pre),
                Area(phone.Substring(pre)));
        }

        private string Area(string phone)
        {
            Debug.Assert(phone.Length == 10);
            return String.Format("({0}) {1}",
                phone.Substring(0, 3),
                Local(phone.Substring(3)));
        }

        private string LocalPlus(string phone)
        {
            Debug.Assert(phone.Length > 7);
            int pre = phone.Length - 7;
            return String.Format("{0} {1}",
                phone.Substring(0, pre),
                Local(phone.Substring(pre)));
        }

        private string Local(string phone)
        {
            Debug.Assert(phone.Length == 7);
            return String.Format("{0}-{1}",
                phone.Substring(0, 3),
                phone.Substring(3));
        }
    }
}
