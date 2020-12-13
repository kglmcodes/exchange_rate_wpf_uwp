using Newtonsoft.Json;
using System.Net.Http;
using System.Windows;

namespace GlassLookTests
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public const string latesRateURL = "http://forex.cbm.gov.mm/api/latest";
        public const string currenciesURL = "http://forex.cbm.gov.mm/api/currencies";

        public static LatestRatesModel.LatestRate latestRates;
        public static CurrenciesModel.Currencies currencies;

        private async void Application_Startup(object sender, StartupEventArgs e)
        {
            if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable() == true)
            {
                using (HttpClient client = new HttpClient())
                using (HttpResponseMessage responseMessage = await client.GetAsync(currenciesURL))
                using (HttpContent content = responseMessage.Content)
                {
                    string result = await content.ReadAsStringAsync();
                    currencies = JsonConvert.DeserializeObject<CurrenciesModel.Currencies>(result);
                }
            }
        }
    }
}
