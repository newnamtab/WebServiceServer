using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Linq;
using System.Web;

namespace WebServiceServer
{    [DataContract]
    public class Session
    {   [DataMember]
        private double result;
        [DataMember]
        private string fromISO;
        [DataMember]
        private string toISO;
        [DataMember]
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