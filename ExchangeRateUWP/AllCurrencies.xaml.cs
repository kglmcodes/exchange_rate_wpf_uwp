using System;
using System.Collections.Generic;
using System.Diagnostics;
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
                if (!await PinnedList.LoadList())
                {
                    Debug.WriteLine("Failed to load PinnedList");
                }
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
                    var cbp = new CurrencyBlockPage(App.currencies.CurrencyMeaning[rate.Key], rate.Value.ToString())
                    {
                        Name = $"uc_CB_{rate.Key}",
                        IsPinned = PinnedList.AbbList.Contains(GenerateCountryAbbreviationFromCurrency(App.currencies.CurrencyMeaning[rate.Key]))
                    };
                    cbp.PointerReleased += Cbp_PointerReleased;
                    contentAGridView.Items.Add(cbp);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    await Task.Delay(500);
                    goto tryagain;
                }
            }
        }

        private void Cbp_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            MainPage.ShowDetaildView(sender);
        }

        public static string GenerateCountryAbbreviationFromCurrency(string CountryName)
        {
            switch (CountryName)
            {
                case "United State Dollar":
                    return "US";

                case "Euro":
                    return "EU";

                case "Singapore Dollar":
                    return "SG";

                case "Pound Sterling":
                    return "GB";

                case "Swiss Franc":
                    return "CH";

                case "Japanese Yen":
                    return "JP";

                case "Australian Dollar":
                    return "AU";

                case "Bangladesh Taka":
                    return "BD";

                case "Brunei Dollar":
                    return "BN";

                case "Cambodian Riel":
                    return "KH";

                case "Canadian Dollar":
                    return "CA";

                case "Chinese Yuan":
                    return "CN";

                case "Hong Kong Dollar":
                    return "HK";

                case "Indian Rupee":
                    return "IN";

                case "Indonesian Rupiah":
                    return "ID";

                case "Korean Won":
                    return "KR";

                case "Lao Kip":
                    return "LA";

                case "Malaysian Ringgit":
                    return "MY";

                case "New Zealand Dollar":
                    return "NZ";

                case "Pakistani Rupee":
                    return "PK";

                case "Philippines Peso":
                    return "PH";

                case "Sri Lankan Rupee":
                    return "LK";

                case "Thai Baht":
                    return "TH";

                case "Vietnamese Dong":
                    return "VN";

                case "Brazilian Real":
                    return "BR";

                case "Czech Koruna":
                    return "CZ";

                case "Danish Krone":
                    return "DK";

                case "Egyptian Pound":
                    return "EG";

                case "Israeli Shekel":
                    return "IL";

                case "Kenya Shilling":
                    return "KE";

                case "Kuwaiti Dinar":
                    return "KW";

                case "Nepalese Rupee":
                    return "NP";

                case "Norwegian Kroner":
                    return "NO";

                case "Russian Rouble":
                    return "RU";

                case "Saudi Arabian Riyal":
                    return "SA";

                case "Serbian Dinar":
                    return "RS";

                case "South Africa Rand":
                    return "ZA";

                case "Swedish Krona":
                    return "SE";

                default:
                    return "";

            }
        }

    }
}