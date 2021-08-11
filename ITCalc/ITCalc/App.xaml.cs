using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ITCalc
{
    public partial class App : Application
    {
        private readonly string userNameKey = "UserName";
        public string UserName
        {
            get
            {
                if (Current.Properties.TryGetValue(userNameKey, out object userName))
                {
                    return userName as string;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if (Current.Properties.ContainsKey(userNameKey))
                {
                    Current.Properties[userNameKey] = value;
                }
                else
                {
                    Current.Properties.Add(userNameKey, value);
                }
            }
        }


        public App()
        {
            InitializeComponent();

            MainPage = new Views.LoadingView();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
