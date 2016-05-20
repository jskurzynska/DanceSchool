using System;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using TeamProject.Views;

namespace TeamProject.ViewModels
{
    public class BaseViewModelLocator
    {

        /*
        The ServiceLocator is responsible for retrieving the ViewModel instances, 
        using the SimpleIoc.Default implementation provided by MVVM Light. By registering them via the SimpleIoc.Default instance in the constructor, we can retrieve those 
        instances from the Views via the public properties defined in the locator class.
    */
        public BaseViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            var navigationService = CreateNavigationService();
            SimpleIoc.Default.Register<INavigationService>(() => navigationService);
            SimpleIoc.Default.Register<MainPageViewModel>(true);
            SimpleIoc.Default.Register<GroupsViewModel>(false);
            SimpleIoc.Default.Register<PresenceViewModel>(true);
            SimpleIoc.Default.Register<LoggingViewModel>(false);
        }

        public LoggingViewModel LoggingPage => ServiceLocator.Current.GetInstance<LoggingViewModel>();

        public MainPageViewModel MainPage => ServiceLocator.Current.GetInstance<MainPageViewModel>();

        public GroupsViewModel GroupsPage => ServiceLocator.Current.GetInstance<GroupsViewModel>();

        public PresenceViewModel PresencePage => ServiceLocator.Current.GetInstance<PresenceViewModel>();

        private INavigationService CreateNavigationService()
        {
            var navigationService = new NavigationService();
            //navigationservice zostanie zapytany o mainpage ktory zawola tego mainpage i on zwroci instancje (powyzej) 
            // tego naszego chcianego widoku
            navigationService.Configure("LoggingPage", typeof(LoggingPageView));
            navigationService.Configure("MainPage", typeof(MainPageView));
            navigationService.Configure("GroupsPage", typeof(GroupsPageView));
            navigationService.Configure("PresencePage", typeof(PresencePageView));

            return navigationService;
        }
    }
}
