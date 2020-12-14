using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlassLookTests
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public static class CurrenciesModel
    {

        //public class CurrencyMeaning
        //{
        //    [JsonProperty("USD")]
        //    public string USD { get; set; }

        //    [JsonProperty("EUR")]
        //    public string EUR { get; set; }

        //    [JsonProperty("SGD")]
        //    public string SGD { get; set; }

        //    [JsonProperty("GBP")]
        //    public string GBP { get; set; }

        //    [JsonProperty("CHF")]
        //    public string CHF { get; set; }

        //    [JsonProperty("JPY")]
        //    public string JPY { get; set; }

        //    [JsonProperty("AUD")]
        //    public string AUD { get; set; }

        //    [JsonProperty("BDT")]
        //    public string BDT { get; set; }

        //    [JsonProperty("BND")]
        //    public string BND { get; set; }

        //    [JsonProperty("KHR")]
        //    public string KHR { get; set; }

        //    [JsonProperty("CAD")]
        //    public string CAD { get; set; }

        //    [JsonProperty("CNY")]
        //    public string CNY { get; set; }

        //    [JsonProperty("HKD")]
        //    public string HKD { get; set; }

        //    [JsonProperty("INR")]
        //    public string INR { get; set; }

        //    [JsonProperty("IDR")]
        //    public string IDR { get; set; }

        //    [JsonProperty("KRW")]
        //    public string KRW { get; set; }

        //    [JsonProperty("LAK")]
        //    public string LAK { get; set; }

        //    [JsonProperty("MYR")]
        //    public string MYR { get; set; }

        //    [JsonProperty("NZD")]
        //    public string NZD { get; set; }

        //    [JsonProperty("PKR")]
        //    public string PKR { get; set; }

        //    [JsonProperty("PHP")]
        //    public string PHP { get; set; }

        //    [JsonProperty("LKR")]
        //    public string LKR { get; set; }

        //    [JsonProperty("THB")]
        //    public string THB { get; set; }

        //    [JsonProperty("VND")]
        //    public string VND { get; set; }

        //    [JsonProperty("BRL")]
        //    public string BRL { get; set; }

        //    [JsonProperty("CZK")]
        //    public string CZK { get; set; }

        //    [JsonProperty("DKK")]
        //    public string DKK { get; set; }

        //    [JsonProperty("EGP")]
        //    public string EGP { get; set; }

        //    [JsonProperty("ILS")]
        //    public string ILS { get; set; }

        //    [JsonProperty("KES")]
        //    public string KES { get; set; }

        //    [JsonProperty("KWD")]
        //    public string KWD { get; set; }

        //    [JsonProperty("NPR")]
        //    public string NPR { get; set; }

        //    [JsonProperty("NOK")]
        //    public string NOK { get; set; }

        //    [JsonProperty("RUB")]
        //    public string RUB { get; set; }

        //    [JsonProperty("SAR")]
        //    public string SAR { get; set; }

        //    [JsonProperty("RSD")]
        //    public string RSD { get; set; }

        //    [JsonProperty("ZAR")]
        //    public string ZAR { get; set; }

        //    [JsonProperty("SEK")]
        //    public string SEK { get; set; }
        //}

        public class Currencies
        {
            [JsonProperty("info")]
            public string Info { get; set; }

            [JsonProperty("description")]
            public string Description { get; set; }

            [JsonProperty("currencies")]
            public Dictionary<string,string> CurrencyMeaning { get; set; }
        }
    }
}
