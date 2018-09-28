using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class SumModel
    {
       public int Id { get; set; }
       public double costPrice { get; set; }
       public double viewYear { get; set; }
       public double truckAge { get; set; }
       public double salvageValue { get; set; }
       public double totalDep { get; set; }

        public double CalSalvageValue()
        {
            double pow = Math.Pow(1 - 15.60 / 100, truckAge);
            salvageValue = costPrice * pow;
            return salvageValue;
        }

        public double CalDepreciation()
        {
            
            totalDep = (costPrice - salvageValue)/ viewYear;
            return totalDep;
        }
    }
}