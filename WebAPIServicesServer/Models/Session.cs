using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Linq;
using System.Web;

namespace WebAPIServicesServer
{    
    public class Session
    {   
        private double result;
       
        private string fromISO;
       
        private string toISO;
        
        private double fromAmount;

        public Session(double Result,string FromIso, string ToIso, double FromAmount)
        {
            this.result = Result;
            this.fromISO = FromIso;
            this.toISO = ToIso;
            this.fromAmount = FromAmount;
        }
    }
}