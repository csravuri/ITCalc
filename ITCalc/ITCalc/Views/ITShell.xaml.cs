using System;
using ITCalc.ViewModels;

namespace ITCalc.Views
{
    public partial class ITShell : Xamarin.Forms.Shell
    {
        private readonly ITShellViewModel viewModels;

        public ITShell()
        {
            InitializeComponent();
            BindingContext = viewModels = new ITShellViewModel(Navigation);
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            //await Shell.Current.GoToAsync("//LoginPage");
        }        
    }
}
