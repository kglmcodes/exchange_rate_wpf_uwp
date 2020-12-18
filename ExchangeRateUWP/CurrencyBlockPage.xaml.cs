using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ExchangeRateUWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    /// 
    public sealed partial class CurrencyBlockPage : Page
    {
        string flagURL;

        public static readonly DependencyProperty CountryNameProperty =
               DependencyProperty.Register("CountryName", typeof(string), typeof(CurrencyBlockPage), new PropertyMetadata("", new PropertyChangedCallback(OnCountryNameChanged)));

        private static void OnCountryNameChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {

        }
        public string CountryName
        {
            get { return (string)GetValue(CountryNameProperty); }
            set { SetValue(CountryNameProperty, value); }
        }

        public static readonly DependencyProperty CurrencyRateProperty =
            DependencyProperty.Register("CurrencyRate", typeof(string), typeof(CurrencyBlockPage), new PropertyMetadata(""));

        public string CurrencyRate
        {
            get { return (string)GetValue(CurrencyRateProperty); }
            set { SetValue(CurrencyRateProperty, value); }
        }

        public static readonly DependencyProperty IsPinnedProperty =
            DependencyProperty.Register("IsPinned", typeof(bool), typeof(CurrencyBlockPage), new PropertyMetadata(false, new PropertyChangedCallback(OnIsPinnedChanged)));

        public bool IsPinned
        {
            get { return (bool)GetValue(IsPinnedProperty); }
            set { SetValue(IsPinnedProperty, value); }
        }
        private static void OnIsPinnedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
        }

        public CurrencyBlockPage()
        {
            this.InitializeComponent();
        }

        public CurrencyBlockPage(string CountryName, string Rate)
        {
            InitializeComponent();
            IsPinned = true;
            this.CountryName = CountryName;
            CurrencyRate = Rate;
            flagURL = $"https://www.countryflags.io/" + GenerateFlagURL() + "/shiny/64.png";
            img_flag.Source = new BitmapImage(new Uri(flagURL));
        }

        public string GenerateFlagURL()
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
