using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using WebAPIServicesServer;


namespace WebAPIServicesServer.Controllers
{
    public class CurrencyController : ApiController
    {
        private object _lock = new object();
        private List<Currency> CurrencyList
        {
            get
            {
                if (HttpContext.Current.Application["EntireApp"] == null)
                {
                    HttpContext.Current.Application["EntireApp"] = new List<Currency>();
                    FillList();
                }
                return HttpContext.Current.Application["EntireApp"] as List<Currency>;

            }
            set { HttpContext.Current.Session["EntireApp"] = value; }
        }
        private List<Session> mySessionList = new List<Session>();
        private Session mySession;
        

        public CurrencyController()
        {
            CurrencyList = new List<Currency>();
           
        }

        private void FillList()
        {

            this.CurrencyList.Add(new Currency("AMERIKA", "USD", 524.0200));
            this.CurrencyList.Add(new Currency("CANADA", "CAD", 492.2700));
            this.CurrencyList.Add(new Currency("EUROPA", "EUR", 745.9900));
            this.CurrencyList.Add(new Currency("NORGE", "NOK", 90.3400));
            this.CurrencyList.Add(new Currency("STORBRITTANIEN", "GBP", 947.5300));
            this.CurrencyList.Add(new Currency("SVERIGE", "SEK", 78.2100));
        }

        [HttpGet]
        [ActionName("GetCurrencyList")]
        public Currency[] GetCurrencyList()
        {
            return this.CurrencyList.ToArray();
        }

        [HttpGet]
        public double GetExchangeRate(string iso)
        {
            double result = 0;
            foreach (var item in GetCurrencyList())
            {
                if (item.ISO == iso)
                {
                    result = item.ExchangeRate;
                }
            }
            return result;
        }
        private double convertToUSD(string fromISO, double amount)
        {
            double result;

            switch (fromISO.ToUpper())
            {

                //case "USD":
                //    result = 524.0200;
                //    break;
                case "CAD":

                    result = amount / GetExchangeRate("CAD") * GetExchangeRate("USD");

                    break;
                case "EUR":
                    result = amount / GetExchangeRate("EUR") * GetExchangeRate("USD");
                    break;
                case "NOK":
                    result = amount / GetExchangeRate("NOK") * GetExchangeRate("USD");

                    break;
                case "GBP":
                    result = amount / GetExchangeRate("GBP") * GetExchangeRate("USD");
                    break;
                case "SEK":
                    result = amount / GetExchangeRate("GBP") * GetExchangeRate("USD");
                    break;
                default:
                    result = 100;
                    break;
            }
            return result;
        }
        private double convertToCAD(string fromISO, double amount)
        {
            double result;

            switch (fromISO.ToUpper())
            {

                case "USD":
                    result = amount / GetExchangeRate("USD") * GetExchangeRate("CAD");

                    break;
                case "EUR":
                    result = amount / GetExchangeRate("EUR") * GetExchangeRate("CAD");
                    break;
                case "NOK":
                    result = amount / GetExchangeRate("NOK") * GetExchangeRate("CAD");

                    break;
                case "GBP":
                    result = amount / GetExchangeRate("GBP") * GetExchangeRate("CAD");
                    break;
                case "SEK":
                    result = amount / GetExchangeRate("SEK") * GetExchangeRate("CAD");
                    break;
                default:
                    result = 100;
                    break;
            }
            return result;

        }
        private double convertToEUR(string fromISO, double amount)
        {
            double result;

            switch (fromISO.ToUpper())
            {

                case "USD":
                    result = amount / GetExchangeRate("USD") * GetExchangeRate("EUR");

                    break;
                case "CAD":
                    result = amount / GetExchangeRate("CAD") * GetExchangeRate("EUR");
                    break;
                case "NOK":
                    result = amount / GetExchangeRate("NOK") * GetExchangeRate("EUR");
                    break;
                case "GBP":
                    result = amount / GetExchangeRate("GBP") * GetExchangeRate("EUR");
                    break;
                case "SEK":
                    result = amount / GetExchangeRate("SEK") * GetExchangeRate("EUR");
                    break;
                default:
                    result = 100;
                    break;
            }
            return result;

        }
        private double convertToNOK(string fromISO, double amount)
        {
            double result;

            switch (fromISO.ToUpper())
            {


                case "USD":
                    result = amount / GetExchangeRate("USD") * GetExchangeRate("NOK");

                    break;
                case "EUR":
                    result = amount / GetExchangeRate("EUR") * GetExchangeRate("NOK");
                    break;
                case "CAD":
                    result = amount / GetExchangeRate("CAD") * GetExchangeRate("NOK");
                    break;
                case "GBP":
                    result = amount / GetExchangeRate("GBP") * GetExchangeRate("NOK");
                    break;
                case "SEK":
                    result = amount / GetExchangeRate("SEK") * GetExchangeRate("NOK");
                    break;
                default:
                    result = 100;
                    break;
            }
            return result;

        }
        private double convertToGPB(string fromISO, double amount)
        {
            double result;

            switch (fromISO.ToUpper())
            {


                case "USD":
                    result = amount / GetExchangeRate("USD") * GetExchangeRate("GBP");

                    break;
                case "EUR":
                    result = amount / GetExchangeRate("EUR") * GetExchangeRate("GBP");
                    break;
                case "NOK":
                    result = amount / GetExchangeRate("NOK") * GetExchangeRate("GBP");

                    break;
                case "CAD":
                    result = amount / GetExchangeRate("CAD") * GetExchangeRate("GBP");
                    break;
                case "SEK":
                    result = amount / GetExchangeRate("SEK") * GetExchangeRate("GBP");
                    break;
                default:
                    result = 100;
                    break;
            }
            return result;

        }
        private double convertToSEK(string fromISO, double amount)
        {
            double result;

            switch (fromISO.ToUpper())
            {

                case "USD":
                    result = amount / GetExchangeRate("USD") * GetExchangeRate("SEK");

                    break;
                case "EUR":
                    result = amount / GetExchangeRate("EUR") * GetExchangeRate("SEK");
                    break;
                case "NOK":
                    result = amount / GetExchangeRate("NOK") * GetExchangeRate("SEK");

                    break;
                case "GBP":
                    result = amount / GetExchangeRate("GBP") * GetExchangeRate("SEK");
                    break;
                case "CAD":
                    result = amount / GetExchangeRate("CAD") * GetExchangeRate("SEK");
                    break;
                default:
                    result = 100;
                    break;
            }
            return result;

        }

        [HttpGet]
        public double CalcEuros(double DanishKrone)
        {
            return DanishKrone / (GetExchangeRate("EUR") * 100);
        }
        
        [HttpGet]
        public double ConvertFromTo(string fromISO, string toISO, double amount)
        {
            double returnConvertion;
            switch (toISO.ToUpper())
            {
                case "USD":
                    returnConvertion = convertToUSD(fromISO, amount);
                    break;
                case "CAD":
                    returnConvertion = convertToCAD(fromISO, amount);
                    break;
                case "EUR":
                    returnConvertion = convertToEUR(fromISO, amount);
                    break;
                case "NOK":
                    returnConvertion = convertToNOK(fromISO, amount);
                    break;
                case "SEK":
                    returnConvertion = convertToSEK(fromISO, amount);
                    break;
                case "GBP":
                    returnConvertion = convertToGPB(fromISO, amount);
                    break;
                default:
                    returnConvertion = 100;
                    break;
            }
            return returnConvertion;
        }

        [HttpGet]
        public double ConvertCurrency(string fromISO, string toISO, double fromAmount)
        {
            double result = ConvertFromTo(fromISO, toISO, fromAmount);
            mySession = new Session(result, fromISO, toISO, fromAmount);

            if (HttpContext.Current.Session["conversionList"] != null)
            {
                mySessionList = (List<Session>)HttpContext.Current.Session["conversionList"];
            }
            mySessionList.Add(mySession);
            HttpContext.Current.Session["conversionList"] = mySessionList;
            return result;

        }

        [HttpGet]
        [ActionName("GetSessionList")]
        public Session[] GetConvertionSessionList()
        {
            List<Session> returnList = new List<Session>();

            if (HttpContext.Current.Session["conversionList"] != null)
            {
                returnList = (List<Session>)HttpContext.Current.Session["conversionList"];
            }

            return returnList.ToArray();
        }

        [HttpPut]
        [ActionName("ChangeExchangeRate")]
        public void ChangeExchangeRate(string iso, double newExchangeRate)
        {   
            for (int i = 0; i < CurrencyList.Count; i++)
            {
                if (CurrencyList[i].ISO == iso)
                {
                    CurrencyList[i].ExchangeRate = newExchangeRate;
                }
            }

        }
    }
}
