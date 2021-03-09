using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ThemeWrap1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            
        }

        private async void CB1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ApplyTheme != null && ApplyTheme.IsLoaded)
            {
                var selection = CB1.SelectedIndex;
                switch (selection)
                {
                    case 0:
                        await SetRequestedThemeAsync("Default", ApplyTheme);
                        await SetRequestedThemeAsync("Default", ApplyTheme2);
                        break;
                    case 1:
                        await SetRequestedThemeAsync("Light", ApplyTheme);
                        await SetRequestedThemeAsync("Light", ApplyTheme2);
                        break;
                    case 2:
                        await SetRequestedThemeAsync("Dark", ApplyTheme);
                        await SetRequestedThemeAsync("Dark", ApplyTheme2);
                        break;
                }
            }
        }

        public static async Task SetRequestedThemeAsync(string themename, FrameworkElement fe)
        {
            ElementTheme Theme = ElementTheme.Default;
            switch (themename)
            {
                case "Light":
                    Theme = ElementTheme.Light;
                    break;
                case "Dark":
                    Theme = ElementTheme.Dark;
                    break;
                case "Default":
                    Theme = ElementTheme.Default;
                    break;

            }
            await fe.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                fe.RequestedTheme = Theme;
            });
        }

        private void AddBTN_Click(object sender, RoutedEventArgs e)
        {
            var time = DateTimeOffset.Now;
            var tb = new TextBlock()
            {
                Text = $"Added at {time}",
                Margin = new Thickness(12),
            };

            StackP.Children.Add(tb);

            tb = new TextBlock()
            {
                Text = $"Added at {time}",
                Margin = new Thickness(12),
            };

            StackP2.Children.Add(tb);

        }

        private void CB2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (MainGrid != null && MainGrid.IsLoaded)
            {
                var selection = CB2.SelectedIndex;
                var brsh = (SolidColorBrush)this.Resources[(string)CB2.SelectedItem];
                MainGrid.Background = brsh;

            }
        }
    }
}
