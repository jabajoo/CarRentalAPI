using CarRental.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Core.Extenssions
{
    public static class PriceCalculator
    {
        public static decimal Calculate(this Car value, int days, decimal km)
        {
            switch (value.GetCategoryName())
            {
                case CarType.Small:
                    {
                        return value.BaseDayPrice * days;
                    }
                case CarType.Estate:
                    {
                        return value.BaseDayPrice * days* 1.3M + value.BaseKmPrice * km ;
                    }
                case CarType.Truck:
                    {
                        return value.BaseDayPrice * days * 1.5M + value.BaseKmPrice * km * 1.5M;
                    }
                default:
                    {
                        return 0;
                    }
            }
        }
    }
}
