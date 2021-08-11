using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ITCalc.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        protected readonly INavigation Navigation;

        public event PropertyChangedEventHandler PropertyChanged;

        public App APP { get; }

        public BaseViewModel(INavigation navigation)
        {
            Navigation = navigation;
            APP = Application.Current as App;
        }

        protected void SetAsMainPage(Page page, bool isNavigationRequired = true)
        {            
            APP.MainPage = isNavigationRequired ? new NavigationPage(page) : page;
            //await Shell.Current.GoToAsync($"//{nameof(page)}");
        }

        protected bool SetProperty<T>(ref T backingStore, T value, [CallerMemberName] string propertyName = "", Action onChange = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChange?.Invoke();
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            return true;
        }
    }
}