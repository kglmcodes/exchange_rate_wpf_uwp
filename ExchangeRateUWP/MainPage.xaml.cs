using System.Diagnostics;
using Windows.UI.Xaml.Controls;

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
            if (item == _lastItem)
            {
                //this will be where we check if the last item is the all currencies or not and try to add a refresh function
                return;
            }

            switch (item.Content)
            {
                case "View All":
                    mainPageNavigationView.Content = App.allCurrencies;
                    break;
                case "Pinned Currencies":
                    mainPageNavigationView.Content = App.pinnedListPage;
                    break;
                case "Settings":
                    mainPageNavigationView.Content = new Page();
                    break;
                case "Last Week":
                    mainPageNavigationView.Content = App.historyPage;
                    break;
                default:
                    break;
            }

            //if (item.Content.ToString() == "All Currencies")
            //{
            //}
            //if (item.Tag.ToString() == "Pinned Currencies")
            //{
            //    mainPageNavigationView.Content = App.pinnedListPage;
            //    //mainPageNavigationView.Content = App.currencyDetailView;
            //}
            //if (item.)
            //{

            //}
            _lastItem = item;
        }
        public static void ShowDetaildView(object sender)
        {
            Debug.WriteLine(sender.GetType());
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