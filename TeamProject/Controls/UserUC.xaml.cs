using System;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;


// The UserName Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace TeamProject.Controls
{
    public sealed partial class UserUC : UserControl
    {
        public UserUC()
        {
            this.InitializeComponent();
        }

        
        private async Task LoadImage()
        {
            string fileName = "userPhoto.png";
            StorageFolder myfolder = ApplicationData.Current.LocalFolder;
            StorageFile file = await myfolder.GetFileAsync(fileName);
            await Windows.Storage.FileIO.ReadBufferAsync(file);
            BitmapImage img = new BitmapImage(new Uri(file.Path));
            Image.Source = img;
        }

        private async void Image_OnLoading(FrameworkElement sender, object args)
        {
            await LoadImage();
        }
    }
}
