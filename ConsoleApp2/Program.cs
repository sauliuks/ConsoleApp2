using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.Configuration;
using System.Collections.Specialized;
using System.Threading.Tasks;
using System.IO;
using Physemp.Feed.Tools;
using System.Text.RegularExpressions;


namespace FeedProcessor
{
    class Program
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        static void Main(string[] args)
        {
            log.Debug("Hello logging world!");
            log.Debug( ConfigReader.getConfigs() );
            log.Debug(Directory.GetCurrentDirectory());
            string inputFolder;
            ConfigReader.getConfigs().TryGetValue("in", out inputFolder);
            string outputFolder;
            ConfigReader.getConfigs().TryGetValue("out", out outputFolder);
            log.Debug(inputFolder);
            if(!Directory.Exists(inputFolder))
            {
                Directory.CreateDirectory(inputFolder);
            }
            if (!Directory.Exists(outputFolder))
            {
                Directory.CreateDirectory(outputFolder);
            }
            foreach (String f in Directory.GetFiles(inputFolder))
            {
                log.Debug(f);
                String name = Path.GetFileNameWithoutExtension(f);
                log.Debug(name);
                XElement c = ConfigReader.getAccountConfigs(name);
                XDocument d = XMLReader.getDoc(f);
                log.Debug(d.Nodes());
                

            }
        }
    }
}
