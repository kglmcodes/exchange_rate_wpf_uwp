using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Windows.Storage;

namespace ExchangeRateUWP
{
    static class PinnedList
    {
        static string fileName = "pinnedCurrencies";
        private static List<string> _abbList = new List<string>();
        public static List<string> AbbList
        {
            get { return _abbList; }
            set { _abbList = value; }
        }

        public static void AddCountry(string countryName)
        {
            if (AbbList == null || !AbbList.Contains(countryName))
            {
                AbbList.Add(countryName);
                SaveList();
            }
        }
        public static void RemoveCountry(string countryName)
        {
            AbbList.Remove(countryName);
            SaveList();
        }

        public static async void SaveList()
        {

            if (AbbList == null) { return; }

            //if (!File.Exists(fileName))
            //{
            //    File.Create(fileName);
            //}
            try
            {
                StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
                StorageFile sampleFile = await storageFolder.GetFileAsync(fileName);
                var data = JsonConvert.SerializeObject(AbbList);
                await FileIO.WriteTextAsync(sampleFile, data);
                //XmlDocument xmlDocument = new XmlDocument();
                //XmlSerializer serializer = new XmlSerializer(AbbList.GetType());
                //using (MemoryStream stream = new MemoryStream())
                //{
                //    serializer.Serialize(stream, AbbList);
                //    stream.Position = 0;
                //    xmlDocument.Load(stream);
                //    xmlDocument.Save(fileName);
                //}
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message.ToString());
                //Log exception here
            }
        }


        public async static Task<bool> LoadList()
        {
            //if (string.IsNullOrEmpty(fileName) || !File.Exists(fileName)) { return; }

            try
            {
                StorageFile sampleFile = await ApplicationData.Current.LocalFolder.CreateFileAsync(fileName, CreationCollisionOption.OpenIfExists);
                var data = await FileIO.ReadTextAsync(sampleFile);
                AbbList = JsonConvert.DeserializeObject<List<string>>(data);
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message.ToString());
                return false;
                //Log exception here
            }
        }
    }
}
