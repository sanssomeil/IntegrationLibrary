using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Xml;

namespace IntegrationLibrary
{
    public class Utils
    {
        public static Dictionary<string, string> config = null;

        public static void getConfig()
		    {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"C:\ConfigDirectory\file_conf.config");
            var elem = doc.DocumentElement;
            config = new Dictionary<string, string>();
            foreach (XmlNode element in elem)
            {
                config.Add(element.Attributes.GetNamedItem("Name").Value, element.Attributes.GetNamedItem("Value").Value);
            }
        }

    		public static void processException(Exception ex)
    		{
            string pathLog = @"C:LogsDirectory\log.txt";
            using (StreamWriter logfile = new StreamWriter (pathLog, true, System.Text.Encoding.UTF8))
            {
                logfile.WriteLine("ERROR | " + DateTime.Now.ToString () + " | " + ex.Message + "\n" + ex.StackTrace + "\n");
            }
            throw ex;
	    	}
    }
}
