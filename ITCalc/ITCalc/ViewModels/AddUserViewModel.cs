using ITCalc.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ITCalc.ViewModels
{
    public class AddUserViewModel : BaseViewModel
    {
        private string userName;

        public string UserName
        {
            get => userName;
            set => SetProperty(ref userName, value);
        }


        public ICommand UserNameCompletedCommand { get; }
        public AddUserViewModel(INavigation navigation) : base(navigation)
        {
            UserNameCompletedCommand = new Command(() => ExecuteUserNameCompletedCommand());
        }

        private void ExecuteUserNameCompletedCommand()
        {
            if (!string.IsNullOrWhiteSpace(UserName))
            {
                APP.UserName = UserName;
                SetAsMainPage(new ITShell(), false);
            }
        }
    }
}
