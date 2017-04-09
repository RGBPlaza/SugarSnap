using Plugin.Settings;
using Plugin.Settings.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SugarSnap.Models
{
    public static class Settings
    {
        private const string AllergenKey = "UserAllergens";
        private static readonly string DefaultUserAllergens = string.Empty;

        public static string UserAllergens
        {
            get { return AppSettings.GetValueOrDefault(AllergenKey, DefaultUserAllergens); }
            set { AppSettings.AddOrUpdateValue(AllergenKey, value); }
        }

        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }
    }
}
