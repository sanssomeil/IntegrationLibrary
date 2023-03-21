using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Text.Json;
using System.Reflection;

namespace IntegrationLibrary
{
    public class Fetcher
    {
    public Fetcher()
        {
            Utils.getConfig();
        }

        public JsonDocument loadDataByCpd(DateTime? cpdDate)
        {
            var jsonString = this.loadJsonByCpd(cpdDate);

            if(jsonString.Length == 0)
            {
                throw new Exception("Не получены данные json");
            }
            return JsonDocument.Parse(jsonString);
        }

        private string loadJsonByCpd (DateTime? cpdDate)
        {
            string cpd = DateTime.Parse(cpdDate.ToString ()).ToString ("yyyy-MM-dd");
            string pathReq = Utils.config["url"] + cpd + "?mask=XXXX";
            string accept = Utils.config["accept"];
            string apikey = Utils.config["apikey"];
            string downloadPath = Utils.config["path_json_download"];
            string nameFile = "XXXX-" + cpd + ".json";
            string response = "";
            WebClient client = new WebClient ();
            bool fileExist = File.Exists(downloadPath + nameFile);
            if (fileExist) 
            {
                response = Encoding.UTF8.GetString (File.ReadAllBytes(downloadPath + nameFile));
            }
            else
            {
                try
                {
                    client.Headers.Add("accept", accept);
                    client.Headers.Add("api-key", apikey);
                    byte[] resp = client.DownloadData(pathReq);
                    response = Encoding.UTF8.GetString(resp);
                    using (StreamWriter swriter = new StreamWriter(downloadPath + nameFile, false, new UTF8Encoding(encoderShouldEmitUTF8Identifier: false)))
                    {
                        swriter.WriteLine (response);
                    }
                }
                catch(WebException e)
                {
                    throw new Exception("Ошибка получения данных: " + e.Message);
                }
            }
            return response;
        }
    }
}
