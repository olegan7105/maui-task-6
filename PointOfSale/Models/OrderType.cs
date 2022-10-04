using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.Models
{
    public enum OrderType
    {
        [Description("Dine In")]
        DineIn,
        [Description("Carry Out")]
        CarryOut,
        [Description("Delivery")]
        Delivery,

    }
}
