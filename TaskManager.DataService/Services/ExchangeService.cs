using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Xml;
using TaskManager.DataService.Models;

namespace TaskManager.DataService.Services
{
    public class ExchangeService : IExchangeService
    {
        readonly string _url = "http://www.nbrb.by/Services/ExRates.asmx";

        public IEnumerable<ExchangeRate> GetExchangeRatesByDate(DateTime date)
        {
            XmlDocument soapEnvelopeXml = CreateSoapEnvelope(date);
            HttpWebRequest webRequest = CreateWebRequest(_url);
            InsertSoapEnvelopeIntoWebRequest(soapEnvelopeXml, webRequest);

            // begin async call to web request.
            IAsyncResult asyncResult = webRequest.BeginGetResponse(null, null);

            // suspend this thread until call is complete. You might want to
            // do something usefull here like update your UI.
            asyncResult.AsyncWaitHandle.WaitOne();

            // get the response from the completed web request.
            using (WebResponse webResponse = webRequest.EndGetResponse(asyncResult))
            {
                string soapResult;
                Stream responseStream = webResponse.GetResponseStream();
                if(responseStream == null) return null;
                using (StreamReader rd = new StreamReader(responseStream))
                {
                    soapResult = rd.ReadToEnd();
                }
                return ParseResponse(soapResult);
            }
        }

        private static HttpWebRequest CreateWebRequest(string url)
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
            webRequest.ContentType = "application/soap+xml; charset=utf-8";
            webRequest.Method = "POST";
            return webRequest;
        }

        private static XmlDocument CreateSoapEnvelope(DateTime date)
        {
            XmlDocument soapEnvelop = new XmlDocument();
            soapEnvelop.LoadXml(
                $@"<soap12:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:soap12=""http://www.w3.org/2003/05/soap-envelope"">
                <soap12:Body>
                    <ExRatesDaily2 xmlns=""http://www.nbrb.by/"">
                        <onDate>{date.ToString("yyyy-MM-dd")}</onDate>
                    </ExRatesDaily2>
                </soap12:Body>
                </soap12:Envelope>");
            return soapEnvelop;
        }

        private static void InsertSoapEnvelopeIntoWebRequest(XmlDocument soapEnvelopeXml, HttpWebRequest webRequest)
        {
            using (Stream stream = webRequest.GetRequestStream())
            {
                soapEnvelopeXml.Save(stream);
            }
        }

        private IEnumerable<ExchangeRate> ParseResponse(string soap)
        {
            XmlDocument document = new XmlDocument();
            document.LoadXml(soap);  //loading soap message as string 
            XmlNamespaceManager manager = new XmlNamespaceManager(document.NameTable);

            //manager.AddNamespace("diffgr", "urn:schemas-microsoft-com:xml-diffgram-v1");
            //manager.AddNamespace("msdata", "urn:schemas-microsoft-com:xml-msdata");

            XmlNodeList xnList = document.SelectNodes("//DailyExRatesOnDate", manager);
            int nodes = xnList.Count;

            List<ExchangeRate> exchangeRates = new List<ExchangeRate>();

            foreach (XmlNode xn in xnList)
            {
                var rate = new ExchangeRate();
                if (xn["Cur_Name"] != null)
                {
                    rate.CurrencyName = xn["Cur_Name"].InnerText;
                }
                if (xn["Cur_Scale"] != null)
                {
                    rate.Scale = xn["Cur_Scale"].InnerText;
                }
                if (xn["Cur_OfficialRate"] != null)
                {
                    rate.Rate = xn["Cur_OfficialRate"].InnerText;
                }
                if (xn["Cur_Code"] != null)
                {
                    rate.CurrencyCode = xn["Cur_Code"].InnerText;
                }
                if (xn["Cur_Abbreviation"] != null)
                {
                    rate.CurrencyAbbreviation = xn["Cur_Abbreviation"].InnerText;
                }
                exchangeRates.Add(rate);
            }
            return exchangeRates;
        }
    }
}