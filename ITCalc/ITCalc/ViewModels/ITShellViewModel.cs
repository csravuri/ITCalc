using ITCalc.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ITCalc.ViewModels
{
    public class ITShellViewModel : BaseViewModel
    {
        public ITShellViewModel(INavigation navigation) : base(navigation)
        {
            Routing.RegisterRoute(nameof(ITCreation), typeof(ITCreation));
            Routing.RegisterRoute(nameof(ITView), typeof(ITView));
        }
    }
}
