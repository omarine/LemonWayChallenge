using Microsoft.VisualStudio.TestTools.UnitTesting;
using LemonWayChallenge.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LemonWayChallenge.Services.Tests
{
    [TestClass()]
    public class XmlToJsonServiceTests
    {
        XmlToJsonService _xmlToJsonService = new XmlToJsonService();
        [TestMethod()]
        public void XmlToJsonTestWithNonValidXml()
        {
            var doc = "<foo>hello</boo>";
            var result = _xmlToJsonService.XmlToJson(doc);
            var expected = "Bad xml format";
            Assert.AreEqual(expected, result);


        }
        [TestMethod]
        public void XmlToJsonTestWithValidXml()
        {
            var doc = "<foo>hello</foo>";
            var result = _xmlToJsonService.XmlToJson(doc);
            var notexpected = "Bad xml format";
            Assert.AreNotEqual(notexpected, result);
        }

        [TestMethod]
        public void XmlToJsonTestWithMoreRealisticXml()
        {
            string doc = @"<?xml version='1.0' standalone='no'?>
 <root>
 <person id='1'>
 <name>Alan</name>
 <url>http://www.google.com</url>
 </person>
 <person id='2'>
 <name>Louis</name>
 <url>http://www.yahoo.com</url>
</person>
</root>";
            var result = _xmlToJsonService.XmlToJson(doc);
            var notexpected = "Bad xml format";
            Assert.AreNotEqual(notexpected, result);
        }
    }
}