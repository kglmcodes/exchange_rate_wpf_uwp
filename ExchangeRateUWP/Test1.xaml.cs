using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ExchangeRateUWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Test1 : Page
    {
        public Test1()
        {
            this.InitializeComponent();
            this.Loaded += Test1_Loaded;
        }

        private async void Test1_Loaded(object sender, RoutedEventArgs e)
        {
            pr_progressRing.IsActive = true;
            pr_progressRing.Visibility = Visibility.Visible;
            //await Task.Delay(10000);
            //pr_progressRing.IsActive = false;
            //pr_progressRing.Visibility = Visibility.Collapsed;
        }
    }
}
