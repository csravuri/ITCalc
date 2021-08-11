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
    public partial class SuffixTextBox : ContentView
    {
        public static readonly BindableProperty TitleProperty = BindableProperty.Create(nameof(Title), typeof(string), typeof(SuffixTextBox), string.Empty);
        public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(SuffixTextBox), string.Empty, BindingMode.TwoWay);
        public static readonly BindableProperty SuffixProperty = BindableProperty.Create(nameof(Suffix), typeof(string), typeof(SuffixTextBox), string.Empty);
        public static readonly BindableProperty SpecialIconSourceProperty = BindableProperty.Create(nameof(SpecialIconSource), typeof(ImageSource), typeof(SuffixTextBox), null);
        public static readonly BindableProperty HelpIconSourceProperty = BindableProperty.Create(nameof(HelpIconSource), typeof(ImageSource), typeof(SuffixTextBox), null);
        public static readonly BindableProperty ControlNameProperty = BindableProperty.Create(nameof(ControlName), typeof(string), typeof(SuffixTextBox), string.Empty);
        public static readonly BindableProperty HelpTextProperty = BindableProperty.Create(nameof(HelpText), typeof(string), typeof(SuffixTextBox), string.Empty);
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

        public string Suffix
        {
            get => (string)GetValue(SuffixProperty);
            set => SetValue(SuffixProperty, value);
        }

        public ImageSource SpecialIconSource
        {
            get => (ImageSource)GetValue(SpecialIconSourceProperty);
            set => SetValue(SpecialIconSourceProperty, value);
        }

        public ImageSource HelpIconSource
        {
            get => (ImageSource)GetValue(HelpIconSourceProperty);
            set => SetValue(HelpIconSourceProperty, value);
        }

        public string ControlName
        {
            get => (string)GetValue(ControlNameProperty);
            set => SetValue(ControlNameProperty, value);
        }

        public string HelpText
        {
            get => (string)GetValue(HelpTextProperty);
            set => SetValue(HelpTextProperty, value);
        }

        public event EventHandler TextCompleted;
        public event EventHandler TextChanged;
        public event EventHandler<HelpTextEvenArgs> HelpIconClicked;
        public event EventHandler<SpecialActionEventArgs> SpecialIconClicked;

        public SuffixTextBox()
        {
            InitializeComponent();
        }

        private void Text_Completed(object sender, EventArgs e)
        {
            TextCompleted?.Invoke(sender, e);
        }

        private void HelpIcon_Clicked(object sender, EventArgs e)
        {
            HelpIconClicked?.Invoke(this, new HelpTextEvenArgs(HelpText));
        }

        private void SpecialIcon_Clicked(object sender, EventArgs e)
        {
            SpecialIconClicked?.Invoke(this, new SpecialActionEventArgs(ControlName));
        }

        private void Text_Focused(object sender, FocusEventArgs e)
        {
            Entry entry = sender as Entry;

            if (entry != null)
            {
                if (Text == "0")
                {
                    entry.SelectionLength = Text.Length;
                }
            }
        }

        private void Text_Changed(object sender, TextChangedEventArgs e)
        {
            TextChanged?.Invoke(this, e);
        }
    }
}