using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebAPIServicesServer
{
    
    public class Currency
    {
      
        public string Name { get; set; }
       
        public string ISO { get; set; }
        
        public double ExchangeRate { get; set; }

        public Currency()
        {
            this.Name = null;
            this.ISO = null;
            this.ExchangeRate = 1;
        }
        public Currency(string name, string iso, double exrate)
        {
            this.Name = name;
            this.ISO = iso;
            this.ExchangeRate = exrate;
        }
        
    }
}