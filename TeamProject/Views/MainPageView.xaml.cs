using System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using TeamProject.ViewModels;

namespace TeamProject.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPageView : Page
    {
        private MainPageViewModel ViewModel => this.DataContext as MainPageViewModel;

        public MainPageView()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            ViewModel.UserNameSet();
            ViewModel.NearestGroupsSet();
        }
    }
}
