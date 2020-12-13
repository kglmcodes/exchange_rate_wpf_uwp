using System;
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

        BitmapImage bitmapImage = new BitmapImage();
        public CurrencyBlock()
        {
            InitializeComponent();
            string text = "https://www.countryflags.io/be/shiny/64.png";
            bitmapImage.BeginInit();
            bitmapImage.UriSource = new Uri(text, UriKind.RelativeOrAbsolute);
            bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
            bitmapImage.EndInit();
            img_flag.Source = bitmapImage;
        }
        public static readonly DependencyProperty CountryNameProperty =
            DependencyProperty.Register("CountryName", typeof(string), typeof(CurrencyBlock), new PropertyMetadata(""));

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
