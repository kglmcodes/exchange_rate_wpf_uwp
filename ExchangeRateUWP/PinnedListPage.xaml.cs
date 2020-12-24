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
    public sealed partial class PinnedListPage : Page
    {
        public PinnedListPage()
        {
            this.InitializeComponent();
            contentGrid.Loaded += ContentGrid_Loaded;
        }

        private void ContentGrid_Loaded(object sender, RoutedEventArgs e)
        {
            ShowPinnedCurrencies();
        }

        private async void ShowPinnedCurrencies()
        {
            contentGrid.Items.Clear();
            foreach (var rate in App.latestRates.Rates)
            {
            tryagain:
                try
                {
                    var a = AllCurrencies.GenerateCountryAbbreviationFromCurrency(App.currencies.CurrencyMeaning[rate.Key]);
                    if (PinnedList.AbbList.Contains(a))
                    {
                        var cbp = new CurrencyBlockPage(App.currencies.CurrencyMeaning[rate.Key], rate.Value.ToString())
                        {
                            Name = $"uc_CB_{rate.Key}",
                            //IsPinned = (bool) PinnedList.AbbList?.Contains(GenerateCountryAbbreviationFromCurrency(App.currencies.CurrencyMeaning[rate.Key]))
                            IsPinned = PinnedList.AbbList == null ? false : PinnedList.AbbList.Contains(AllCurrencies.GenerateCountryAbbreviationFromCurrency(App.currencies.CurrencyMeaning[rate.Key]))
                        };
                        //cbp.PointerReleased += Cbp_PointerReleased;
                        contentGrid.Items.Add(cbp);
                    }
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
