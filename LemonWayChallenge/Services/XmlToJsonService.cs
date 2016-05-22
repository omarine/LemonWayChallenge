using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Linq;

namespace LemonWayChallenge.Services
{
    public class XmlToJsonService
    {
        public XmlToJsonService()
        {

        }

        public string XmlToJson(string xml)
        {
            XmlDocument doc = new XmlDocument();
            try
            {
                doc.LoadXml(xml.ToString());
            }
            catch (Exception)
            {

                return "Bad xml format";
            }
            
            return JsonConvert.SerializeXmlNode(doc);


        }
    }
}