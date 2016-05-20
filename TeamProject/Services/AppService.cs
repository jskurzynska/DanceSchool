using System;
using Windows.Storage;

namespace TeamProject.Services
{
    public static class AppService
    {
        public static ApplicationDataContainer LocalSettings =
            ApplicationData.Current.LocalSettings;

        public static StorageFolder LocalFolder =
            ApplicationData.Current.LocalFolder;

        public static async void SaveImageInAppSettings(string nameFile, byte[] buffer)
        {
            //TODO: WYWALA SIEEE 
            StorageFile sampleFile =
                await LocalFolder.CreateFileAsync(nameFile, CreationCollisionOption.ReplaceExisting);
           await FileIO.WriteBytesAsync(sampleFile, buffer);
  
        }

        public static void SaveTokenInAppSettings(string token)
        {
            LocalSettings.Values["loginToken"] = token;
        }

        public static void DeleteTokenFromAppSettings()
        {
            LocalSettings.Values["loginToken"] = null;
        }

    }
}
