using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
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
using static GlassLookTests.LatestRatesModel;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ExchangeRateUWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HistoryPage : Page
    {
        public List<LatestRate> LastWeekData = new List<LatestRate>();
        private List<DateTime> dates = new List<DateTime>();
        private List<string> results = new List<string>();

        public HistoryPage()
        {
            this.InitializeComponent();
            contentGrid.Loaded += ContentGrid_Loaded;
        }

        private async void ContentGrid_Loaded(object sender, RoutedEventArgs e)
        {
            var temp = "";
            foreach (var item in GetLast7DaysFrom(DateTime.Now))
            {
                results.Add(await GetLatestRatesString(item.ToString()));
                temp += await GetLatestRatesString(item.ToString());
            }
            var a = JsonConvert.DeserializeObject<List<LatestRate>>(temp);
        }
        static IEnumerable GetLast7DaysFrom(DateTime start)
        {
            DateTime end = start.Subtract(TimeSpan.FromDays(7));

            while (end < start)
            {
                string day = start.ToString("dd-MM-yyyy");

                start = start.Subtract(TimeSpan.FromDays(1));

                yield return day;
            }
        }
        static async Task<LatestRate> GetLatestRates(string input)
        {
            var URL = $"http://forex.cbm.gov.mm/api/history/" + input;

            if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable() == true)
            {
                using (HttpClient client = new HttpClient())
                using (HttpResponseMessage responseMessage = await client.GetAsync(URL))
                using (HttpContent content = responseMessage.Content)
                {
                    string result = await content.ReadAsStringAsync();
                    var a = JsonConvert.DeserializeObject<LatestRate>(result);
                    return a;
                    //return JsonConvert.DeserializeObject<LatestRate>(result);
                }
            }
            else
            {
                await new MessageDialog("No Connection.").ShowAsync();
                return new LatestRate();
            }
        }
        static async Task<String> GetLatestRatesString(string input)
        {
            var URL = $"http://forex.cbm.gov.mm/api/history/" + input;

            if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable() == true)
            {
                using (HttpClient client = new HttpClient())
                using (HttpResponseMessage responseMessage = await client.GetAsync(URL))
                using (HttpContent content = responseMessage.Content)
                {
                    string result = await content.ReadAsStringAsync();
                    //var a = JsonConvert.DeserializeObject<LatestRate>(result);
                    return result;
                    //return JsonConvert.DeserializeObject<LatestRate>(result);
                }
            }
            else
            {
                await new MessageDialog("No Connection.").ShowAsync();
                return "";
            }
        }
    }
}
