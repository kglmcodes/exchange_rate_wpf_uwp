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
    public sealed partial class AllCurrencies : Page
    {
        public AllCurrencies()
        {
            this.InitializeComponent();
            contentAGridView.Loaded += (s, e) => { DisplayData(); };
        }
        private async void DisplayData()
        {
            //contentAGridView.Items.Clear();
            try
            {
                //LoadingIndicator.Visibility = Visibility.Visible;
                //await LongOperationAsync();
                App.latestRates = await App.getDeserializedLatesRates;
            }
            finally
            {
                LoadingIndicator.Visibility = Visibility.Collapsed;
            }
            //await Task.Delay(500);
            foreach (var rate in App.latestRates.Rates)
            {
            tryagain:
                try
                {
                    contentAGridView.Items.Add(new CurrencyBlockPage(App.currencies.CurrencyMeaning[rate.Key], rate.Value.ToString())
                    {
                        Name = $"uc_CB_{rate.Key}"
                    });
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    await Task.Delay(500);
                    goto tryagain;
                }
            }
        }
    }
}