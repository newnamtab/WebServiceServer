using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WebServiceServer
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICalcService" in both code and config file together.
    [ServiceContract]
    public interface ICalcService
    {
        [OperationContract]
        void DoWork();

        [OperationContract]
        int Add(int a, int b);

        [OperationContract]
        int Sub(int a, int b);

        [OperationContract]
        int Div(int a, int b);

        [OperationContract]
        int Multi(int a, int b);

        [OperationContract]
        double CalcDia(double radius);

        [OperationContract]
        double CalcCircum(double radius);

        [OperationContract]
        double CalcCirkelArea(double radius);

        [OperationContract]
        double CalcEuros(double DanishKrone);

        [OperationContract]
        double GetExchangeRate(string ISO);

        [OperationContract]
        List<Currency> GetCurrencyList();

        [OperationContract]
        double ConvertCurrency(string fromISO, string toISO, double fromAmount);

        [OperationContract]
        List<Session> GetConvertionSessionList();

        [OperationContract]
        void ChangeExchangeRate(string ISO, double newExchangeRate);
        
    }
}
