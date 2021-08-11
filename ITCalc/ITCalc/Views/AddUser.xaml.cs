using ITCalc.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ITCalc.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddUser : ContentPage
    {
        private readonly AddUserViewModel viewModel;

        public AddUser()
        {
            InitializeComponent();
            BindingContext = viewModel = new AddUserViewModel(Navigation);
        }

        private void UserName_Completed(object sender, EventArgs e)
        {
            viewModel.UserNameCompletedCommand.Execute(null);
        }
    }
}