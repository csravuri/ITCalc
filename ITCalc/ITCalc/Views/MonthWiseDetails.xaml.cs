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
    public partial class MonthWiseDetails : ContentPage
    {
        private MonthWiseDetailsViewModel viewModel;

        public MonthWiseDetails(MonthWiseDetailsViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = this.viewModel = viewModel;
        }

        private void Text_Completed(object sender, EventArgs e)
        {

        }

        private void Help_Clicked(object sender, HelpTextEvenArgs e)
        {

        }
    }
}