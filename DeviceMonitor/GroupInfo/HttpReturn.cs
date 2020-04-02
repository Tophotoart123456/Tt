using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Helper;
namespace DeviceMonitor
{
    public class cla_httpReturn
    {
        public int returnCode { get; set; }
        public string message { get; set; }
        
        public List<TrainPlan> dataInfo { get; set; }
        
    }
    public class cla_Flightplan
    {
        public int returnCode { get; set; }
        public string message { get; set; }
        public List<flightPlan> dataInfo { get; set; }
    }

    public class cla_http
    {
        public static string GetHttpData(string url,string strparam)
        {
            string strtemp = "";
            if (url == "")
                return "";
            var vr= HttpRequestHelper.HttpPostRequest(url, strparam);
            try
            {
                JObject ob = (JObject)JsonConvert.DeserializeObject(vr);
                string strp = ob["returnCode"].ToString();
                //update on 20190325
                if (strp != "1000")
                    return "";
                strtemp = ob["dataInfo"].ToString();
            }
            catch(Exception err)
            {
                strtemp = err.Message;
            }
            return strtemp;
        }

        public static string SerialStringToJs(/*List<flightPlan>*/object fp)
        {
            string strTemp = "";
            if (/*fp.Count == 0*/fp==null)
                return "";
                
            //strTemp += "[";
            strTemp = JsonConvert.SerializeObject(fp);
            //strTemp += "]";
            return strTemp;
        }
        public static List<flightPlan> DerialString(string str)
        {
            
            if (str == "")
                return null;
            List<flightPlan> lst = JsonConvert.DeserializeObject<List<flightPlan>>(str);
            return lst;

        }
        
    }
    
}
