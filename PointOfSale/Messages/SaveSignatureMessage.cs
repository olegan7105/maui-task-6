using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.Messages
{
    public class SaveSignatureMessage : ValueChangedMessage<int>
    {
        public SaveSignatureMessage(int value) : base(value)
        {

        }
    }
}
