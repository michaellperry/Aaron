using System;
using System.Collections.Generic;
using UpdateControls.Fields;

namespace Aaron.WP7.Models
{
    public class Settings
    {
        private Independent<string> _caregiverPhone = new Independent<string>();

        public string CaregiverPhone
        {
            get { return _caregiverPhone; }
            set { _caregiverPhone.Value = value; }
        }

        public void Load(IDictionary<string, object> applicationSettings)
        {
            object value;
            if (applicationSettings.TryGetValue("CaregiverPhone", out value))
                _caregiverPhone.Value = value as String;
        }

        public void Save(IDictionary<string, object> applicationSettings)
        {
            applicationSettings["CaregiverPhone"] = _caregiverPhone.Value;
        }

        public void LoadDesignData()
        {
            _caregiverPhone.Value = "9725551212";
        }
    }
}
