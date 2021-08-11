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
    public partial class ReadOnlyText : ContentView
    {
        public static readonly BindableProperty TitleProperty = BindableProperty.Create(nameof(Title), typeof(string), typeof(ReadOnlyText), string.Empty);
        public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(ReadOnlyText), string.Empty);
        public static readonly BindableProperty TitleColorProperty = BindableProperty.Create(nameof(TitleColor), typeof(string), typeof(ReadOnlyText), "#7d7d7d");
        public static readonly BindableProperty TextColorProperty = BindableProperty.Create(nameof(TextColor), typeof(string), typeof(ReadOnlyText), "#000");
        
        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }
        public string TitleColor
        {
            get => (string)GetValue(TitleColorProperty);
            set => SetValue(TitleColorProperty, value);
        }

        public string TextColor
        {
            get => (string)GetValue(TextColorProperty);
            set => SetValue(TextColorProperty, value);
        }

        public ReadOnlyText()
        {
            InitializeComponent();
        }
    }
}