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
    public partial class ITCreation : ContentPage
    {
        private readonly ITCreationViewModel viewModel;

        public ITCreation()
        {
            InitializeComponent();
            BindingContext = viewModel = new ITCreationViewModel(Navigation);
        }

        private void Text_Completed(object sender, EventArgs e)
        {
            viewModel.TextEnteredCommand.Execute(null);
        }

        private async void Help_Clicked(object sender, HelpTextEvenArgs e)
        {
            await DisplayAlert("Help!", e.HelpText, "OK");
        }

        private void Calender_Clicked(object sender, SpecialActionEventArgs e)
        {
            viewModel.CalenderClickedCommand.Execute(e.ControlName);
        }
    }
}