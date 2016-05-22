using log4net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services.Protocols;
using System.Xml;
using System.Xml.Linq;
[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace LemonWayChallenge.Extentions
{

    public class Log4NetSoapExtension : SoapExtension
    {
        //private static readonly ILog logger = LogManager.GetLogger("LemonWayChallenge");
        private static readonly ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private Stream oldStream;
        private Stream newStream;

        public XmlDocument XmlRequest { get; private set; }
        public XmlDocument XmlResponse { get; private set; }

        public override Stream ChainStream(Stream stream)
        {
            oldStream = stream;
            newStream = new MemoryStream();
            return newStream;
        }

        public override void ProcessMessage(SoapMessage soapMessage)
        {
            switch (soapMessage.Stage)
            {
                case SoapMessageStage.BeforeSerialize:
                    break;
                case SoapMessageStage.AfterSerialize:
                    XmlResponse = GetSoapEnvelope(newStream);
                    if (soapMessage.Exception != null)
                    {
                        var exception = soapMessage.Exception.GetBaseException();
                        exception.Data.Add("SoapRequest", XmlRequest.OuterXml);
                        exception.Data.Add("SoapResponse", XmlResponse.OuterXml);
                        logger.Error("error!", exception);
                    }
                    else
                    {
                        logger.Info("response start");
                        logger.Info(XmlResponse.OuterXml);
                        logger.Info("response end");
                    }
                    CopyStream(newStream, oldStream);
                    break;
                case SoapMessageStage.BeforeDeserialize:
                    CopyStream(oldStream, newStream);
                    XmlRequest = GetSoapEnvelope(newStream);
                    logger.Info("request start");
                    logger.Info(XmlRequest.OuterXml);
                    logger.Info("request end");
                    break;
                case SoapMessageStage.AfterDeserialize:
                    break;
            }
        }

        private static XmlDocument GetSoapEnvelope(Stream stream)
        {
            var xmlDocument = new XmlDocument();
            stream.Position = 0;
            var streamReader = new StreamReader(stream);
            xmlDocument.LoadXml(streamReader.ReadToEnd());
            stream.Position = 0;
            return xmlDocument;
        }

        private static void CopyStream(Stream streamFrom, Stream streamTo)
        {
            var textReader = new StreamReader(streamFrom);
            var textWriter = new StreamWriter(streamTo);
            textWriter.WriteLine(textReader.ReadToEnd());
            textWriter.Flush();
        }

        #region MyRegion
        public override object GetInitializer(LogicalMethodInfo methodInfo, SoapExtensionAttribute attribute)
        {
            return null;
        }
        public override object GetInitializer(Type WebServiceType)
        {
            return null;
        }
        public override void Initialize(object initializer)
        {
        }
        #endregion

        [AttributeUsage(AttributeTargets.Method)]
        public class Log4NetSoapExtensionAttribute : SoapExtensionAttribute
        {
            public override Type ExtensionType
            {
                get { return typeof(Log4NetSoapExtension); }
            }

            public override int Priority { get; set; }
        }
    }
}