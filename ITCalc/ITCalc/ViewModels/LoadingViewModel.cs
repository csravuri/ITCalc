using ITCalc.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ITCalc.ViewModels
{
    public class LoadingViewModel : BaseViewModel
    {
        public LoadingViewModel(INavigation navigation) : base(navigation)
        {
        }

        internal void OnAppearing()
        {
            if (string.IsNullOrWhiteSpace(APP.UserName))
            {
                SetAsMainPage(new AddUser());
            }
            else
            {
                SetAsMainPage(new ITShell(), false);
            }
        }
    }
}
