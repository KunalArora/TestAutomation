using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Brother.Tests.Selenium.Lib.Support.MPS
{
    public class JsonReader
    {
        private static readonly WebClient N = new WebClient();

        
        public static string GetPageResponse(string type)
        {
            var sofaType = String.Format("url/{0}", type);
            return N.DownloadString(sofaType);
        }
        
        public static List<string> RangeNameList(string type)
        {
            var rangeNameContainer = new List<string>();

            var json = GetPageResponse(type);

            dynamic jsonObj = JsonConvert.DeserializeObject(json);

            foreach (var obj in jsonObj)
            {
                rangeNameContainer.Add(obj.rangeName.ToString());
            }

            return rangeNameContainer;
        }

        

}
    
}
