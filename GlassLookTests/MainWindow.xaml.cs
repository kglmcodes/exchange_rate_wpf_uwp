using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GlassLookTests
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //Setting up the windows control buttons
            btn_Exit.Click += (e, s) =>
            {
                this.Close();
            };
            btn_Minimize.Click += (e, s) =>
            {
                this.WindowState = WindowState.Minimized;
            };
            btn_Maximize.Click += (e, s) =>
            {
                this.WindowState = this.WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
            };
            DisplayData();
        }
        private async Task<LatestRatesModel.LatestRate> getDeserializedLatesRates()
        {
            if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable() == true)
            {
                using (HttpClient client = new HttpClient())
                using (HttpResponseMessage responseMessage = await client.GetAsync(App.latesRateURL))
                using (HttpContent content = responseMessage.Content)
                {
                    string result = await content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<LatestRatesModel.LatestRate>(result);
                }
            }
            else
            {
                MessageBox.Show("No Internet Connection");
                //throw new NotImplementedException();
                return new LatestRatesModel.LatestRate();
            }
        }

        private async void DisplayData()
        {
            App.latestRates = await getDeserializedLatesRates();
            uniformGrid.Children.Clear();
            foreach (var rate in App.latestRates.Rates)
            {
                uniformGrid.Children.Add(new CurrencyBlock()
                {
                    Name = $"uc_CB_{rate.Key}",
                    CountryName = App.currencies.CurrencyMeaning[rate.Key],
                    CurrencyRate = rate.Value.ToString()
                });
            }
        }
    }
}
