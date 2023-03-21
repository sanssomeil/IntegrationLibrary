using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IntegrationLibrary
{
    public class Participant
    {
        public string mainId;
        public string id1;
        public string name;
        public string id2;
        public string id3;
        public List<string> listIds0 = new List<string>();
        public List<string> listIds1 = new List<string>();
        public List<string> listIds2 = new List<string>();
        public List<string> xxInfo1 = new List<string>();
        public List<string> xxInfo2 = new List<string>();
        public List<string> xxInfo3 = new List<string>();
        public Dictionary<string, List<string>> yyInfo1 = new Dictionary<string, List<string>>();
        public Dictionary<string, List<string>> yyInfo2 = new Dictionary<string, List<string>>();
        public Dictionary<string, List<string>> yyInfo3 = new Dictionary<string, List<string>>();

        public List<string> getKeysOfyyInfos ()
        {
            return new List<string> (this.yyInfo1.Keys.Concat(yyInfo2.Keys.Concat(yyInfo3.Keys))).Distinct().ToList();
        }
    }
}
