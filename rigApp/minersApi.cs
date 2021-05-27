using Newtonsoft.Json;
using rigApp.api;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace rigApp
{
    class minersApi
    {
        public int walletCount = 0;
        public string workerName1 = string.Empty;
        public string workerName2 = string.Empty;
        public string workerName3 = string.Empty;
        public float currentHashrate1 = 0;
        public float currentHashrate2 = 0;
        public float currentHashrate3 = 0;
        public float avarageHashrate1 = 0;
        public float avarageHashrate2 = 0;
        public float avarageHashrate3 = 0;
        public float unpaid1 = 0;
        public float unpaid2 = 0;
        public float unpaid3 = 0;
        public float unconf1 = 0;
        public float unconf2 = 0;
        public float unconf3 = 0;




        private string walletFile = "config.txt";
        private string[] walletID;
        private string url = "https://eth.2miners.com/api/accounts/";
        private WebClient webClient;
        private string incomingJsonData;
        private string readingName;
        Root datas;
        public void start()
        {
            readWalletID();
            webClient = new WebClient();
        }

        public void update()
        {
            for (int i = 0; i < walletID.Length; i++)
            {
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                
                incomingJsonData = webClient.DownloadString(url + walletID[i]);
                datas = JsonConvert.DeserializeObject<Root>(incomingJsonData);

                try
                {
                    readingName = incomingJsonData.Substring(incomingJsonData.IndexOf("workers\":"), incomingJsonData.IndexOf("lastBeat") - incomingJsonData.IndexOf("workers\":"));
                    readingName = readingName.Replace("workers", string.Empty);
                    readingName = removeChar(readingName, "\"");
                    readingName = removeChar(readingName, ":");
                    readingName = removeChar(readingName, "{");
                }
                catch 
                {
                    readingName = "offline";
                }
                

                switch (i)
                {
                    case 0:
                        workerName1 = readingName;
                        currentHashrate1 = datas.currentHashrate / 1000000f;
                        avarageHashrate1 = datas.hashrate / 1000000f;
                        unpaid1 = datas.stats.balance / 1000000000f;
                        unconf1 = datas.stats.immature / 1000000000f;
                        break;
                    case 1:
                        workerName2 = readingName;
                        currentHashrate2 = datas.currentHashrate / 1000000f;
                        avarageHashrate2 = datas.hashrate / 1000000f;
                        unpaid2 = datas.stats.balance / 1000000000f;
                        unconf2 = datas.stats.immature / 1000000000f;
                        break;
                    case 2:
                        workerName3 = readingName;
                        currentHashrate3 = datas.currentHashrate / 1000000f;
                        avarageHashrate3 = datas.hashrate / 1000000f;
                        unpaid3 = datas.stats.balance / 1000000000f;
                        unconf3 = datas.stats.immature / 1000000000f;
                        break;

                }
                
            }
            try
            {
                webClient.Dispose();

            }
            catch (Exception ex)
            {

            }

        }

        private string removeChar(string text,string key)
        {
         
            for (int i = 0; i < text.Length; i++)
            {
                if(text[i] == key[0])
                {
                    text=text.Remove(i, 1);
                }

            }
            return text;
        }

        
        private void readWalletID()
        {
            walletID = File.ReadAllLines(walletFile);
            walletCount = walletID.Length;
        }

        

    }
}
