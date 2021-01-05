using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace CooperativeSystem.Service.Utilities.ConfigurationUtilities
{
    public static class ConfigurationHelper
    {
        public static bool ApplyBusinessRules
        {
            get { return bool.Parse(ConfigurationManager.AppSettings["applyBusinessRules"]); }
        }
    }
}
