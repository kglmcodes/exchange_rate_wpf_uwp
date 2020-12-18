using GlassLookTests;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ExchangeRateUWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private NavigationViewItem _lastItem;
        public MainPage()
        {
            this.InitializeComponent();
            
            mainPageNavigationView.Content = App.allCurrencies;
            mainPageNavigationView.ItemInvoked += MainPageNavigationView_ItemInvoked;
            //contentAGridView.Loaded += (s, e) => { DisplayData(); };
        }

        private void MainPageNavigationView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            var item = args.InvokedItemContainer as NavigationViewItem;
            if (item == null)
            {
                mainPageNavigationView.Content = null;
                return;
            }
            if (item==_lastItem)
            {
                //this will be where we check if the last item is the all currencies or not and try to add a refresh function
                return;
            }
            if (item.Tag.ToString() == "All_Currencies")
            {
                mainPageNavigationView.Content = App.allCurrencies;
            }
            _lastItem = item;
        }
        //private async Task<LatestRatesModel.LatestRate> getDeserializedLatesRates()
        //{
        //    if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable() == true)
        //    {
        //        using (HttpClient client = new HttpClient())
        //        using (HttpResponseMessage responseMessage = await client.GetAsync(App.latesRateURL))
        //        using (HttpContent content = responseMessage.Content)
        //        {
        //            string result = await content.ReadAsStringAsync();
        //            return JsonConvert.DeserializeObject<LatestRatesModel.LatestRate>(result);
        //        }
        //    }
        //    else
        //    {
        //        await new MessageDialog("No Connection.").ShowAsync();
        //        return new LatestRatesModel.LatestRate();
        //    }
        //}

        //private async void DisplayData()
        //{
        //    //contentAGridView.Items.Clear();
        //    try
        //    {
        //        //LoadingIndicator.Visibility = Visibility.Visible;
        //        //await LongOperationAsync();
        //        App.latestRates = await App.getDeserializedLatesRates;
        //    }
        //    finally
        //    {
        //        //LoadingIndicator.Visibility = Visibility.Collapsed;
        //    }
        //    //await Task.Delay(500);
        //    foreach (var rate in App.latestRates.Rates)
        //    {
        //    tryagain:
        //        try
        //        {
        //            contentAGridView.Items.Add(new CurrencyBlockPage(App.currencies.CurrencyMeaning[rate.Key], rate.Value.ToString())
        //            {
        //                Name = $"uc_CB_{rate.Key}"
        //            });
        //        }
        //        catch (Exception e)
        //        {
        //            Console.WriteLine(e.ToString());
        //            await Task.Delay(500);
        //            goto tryagain;
        //        }
        //    }
        //}
    }
}