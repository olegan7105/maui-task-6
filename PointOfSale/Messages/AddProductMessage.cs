using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.Messages
{
    public class AddProductMessage : ValueChangedMessage<bool>
    {
        public AddProductMessage(bool value) : base(value)
        {

        }
    }
}
