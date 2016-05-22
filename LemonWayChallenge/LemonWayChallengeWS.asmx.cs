using LemonWayChallenge.Services;
using System;
using System.Web.Script.Services;
using System.Web.Services;

namespace LemonWayChallenge
{
    /// <summary>
    /// Summary description for LemonWayChallengeWS
    /// </summary>
    [WebService(Namespace = "LemonWayChallengeWS")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [ScriptService]   
    public class LemonWayChallengeWS : WebService
    {

       
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public int Fibonacci(int n)
        {

            FibonacciService FibonacciSequenceCalculator = new FibonacciService();
            return FibonacciSequenceCalculator.Fibonacci(n);
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string XmlToJson(string xml)
        {
            XmlToJsonService _xmlToJsonConverter = new XmlToJsonService();
            return _xmlToJsonConverter.XmlToJson(xml);
        }
    }
}
