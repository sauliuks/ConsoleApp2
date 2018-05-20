using System.Configuration;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Linq;

namespace Physemp.Feed.Tools
{
    class ConfigReader
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static Dictionary<string, string> getConfigs()
        {
            Dictionary<string, string> res = new Dictionary<string, string>();
            log.Debug("Getting configs");
            foreach (string k in ConfigurationManager.AppSettings.AllKeys)
            {
                res.Add(k, ConfigurationManager.AppSettings.Get(k));
                log.Debug(k);
            }
            return res;
        }
        public static XElement getAccountConfigs( string name)
        {
            log.Debug("Getting account configs");
            XElement root = XElement.Load("accounts.xml");
            IEnumerable<XElement> c = from el in root.Elements("account") where (string)el.Attribute("id") == name select el;
            log.Debug(c);
            return c.First();
        }
    }
}