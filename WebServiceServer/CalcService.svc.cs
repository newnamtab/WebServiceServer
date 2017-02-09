using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Activation;
using System.Web;

namespace WebServiceServer
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CalcService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select CalcService.svc or CalcService.svc.cs at the Solution Explorer and start debugging.

    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
    public class CalcService : ICalcService
    {
        private object _lock = new object();
        private List<Currency> CurrencyList
        {
            get
            {
                HttpContext.Current.Application.Lock();
                if (HttpContext.Current.Application["EntireApp"] == null)
                {
                    HttpContext.Current.Application["EntireApp"] = new List<Currency>();
                    FillList();
                }
                HttpContext.Current.Application.UnLock();
                return HttpContext.Current.Application["EntireApp"] as List<Currency>;

            }
            set { HttpContext.Current.Session["EntireApp"] = value; } //not nececary
        }
        private List<Session> mySessionList = new List<Session>();
        private Session mySession;

        public CalcService()
        {
            CurrencyList = new List<Currency>();
           
        }

        private void FillList()
        {

            CurrencyList.Add(new Currency("AMERIKA", "USD", 524.0200));
            CurrencyList.Add(new Currency("CANADA", "CAD", 492.2700));
            CurrencyList.Add(new Currency("EUROPA", "EUR", 745.9900));
            CurrencyList.Add(new Currency("NORGE", "NOK", 90.3400));
            CurrencyList.Add(new Currency("STORBRITTANIEN", "GBP", 947.5300));
            CurrencyList.Add(new Currency("SVERIGE", "SEK", 78.2100));
        }


        public int Add(int a, int b)
        {
            return a + b;
        }

        public double CalcCircum(double radius)
        {
            return Math.PI * 2 * radius;
        }

        public double CalcCirkelArea(double radius)
        {
            return Math.PI * Math.Pow(radius, 2);
        }

        public double CalcDia(double radius)
        {
            return radius * 2;
        }

        public int Div(int a, int b)
        {
            return a / b;
        }

        public void DoWork()
        {
            //WHOOOP WHOOP
        }

        public List<Currency> GetCurrencyList()
        {
            return this.CurrencyList;
        }

        public double GetExchangeRate(string iso)
        {
            double result = 0;
            foreach (var item in this.CurrencyList)
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

        public int Multi(int a, int b)
        {
            return a * b;
        }
        public double CalcEuros(double DanishKrone)
        {
            return DanishKrone / (GetExchangeRate("EUR") * 100);
        }
        public int Sub(int a, int b)
        {
            return a - b;
        }
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
        public List<Session> GetConvertionSessionList()
        {
            List<Session> returnList = new List<Session>();

            if (HttpContext.Current.Session["conversionList"] != null)
            {
                returnList = (List<Session>)HttpContext.Current.Session["conversionList"];
            }

            return returnList;
        }

        public void ChangeExchangeRate(string iso, double newExchangeRate)
        {
            for (int i = 0; i < CurrencyList.Count; i++)
            {
                if (CurrencyList[i].ISO == iso)
                {
                    CurrencyList[i].ExchangeRate = newExchangeRate;
                    break;
                }
            }

        }



    }
}

