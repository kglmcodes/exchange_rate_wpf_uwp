﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GlassLookTests
{
    /// <summary>
    /// Interaction logic for CurrencyBlock.xaml
    /// </summary>
    //public class RectConvertor : IMultiValueConverter
    //{
    //    #region IMultiValueConverter Members

    //    public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    //    {
    //        return new Rectangle();
    //    }

    //    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    #endregion
    //}
    public partial class CurrencyBlock : UserControl
    {
        string flagURL;


        BitmapImage bitmapImage = new BitmapImage();
        public CurrencyBlock()
        {
            InitializeComponent();
        }
        public CurrencyBlock(string CountryName, string Rate)
        {
            InitializeComponent();
            this.CountryName = CountryName;
            CurrencyRate = Rate;
            flagURL = $"https://www.countryflags.io/" + GenerateFlagURL() + "/shiny/64.png";
            bitmapImage.BeginInit();
            bitmapImage.UriSource = new Uri(flagURL, UriKind.RelativeOrAbsolute);
            bitmapImage.CacheOption = BitmapCacheOption.OnDemand;
            bitmapImage.EndInit();
            img_flag.Source = bitmapImage;
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

        public static readonly DependencyProperty CountryNameProperty =
            DependencyProperty.Register("CountryName", typeof(string), typeof(CurrencyBlock), new PropertyMetadata("", new PropertyChangedCallback(OnCountryNameChanged)));

        private static void OnCountryNameChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {

        }
        public string CountryName
        {
            get { return (string)GetValue(CountryNameProperty); }
            set { SetValue(CountryNameProperty, value); }
        }

        public static readonly DependencyProperty CurrencyRateProperty =
            DependencyProperty.Register("CurrencyRate", typeof(string), typeof(CurrencyBlock), new PropertyMetadata(""));

        public string CurrencyRate
        {
            get { return (string)GetValue(CurrencyRateProperty); }
            set { SetValue(CurrencyRateProperty, value); }
        }
    }
}
