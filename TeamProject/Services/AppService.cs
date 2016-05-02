using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject.Services
{
    public static class AppService
    {
        public static Windows.Storage.ApplicationDataContainer LocalSettings =
            Windows.Storage.ApplicationData.Current.LocalSettings;
    
        public static void SaveTokenInAppSettings(string token)
        {
            LocalSettings.Values["loginToken"] = token;
        }

    }
}
