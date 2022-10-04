using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.Messages
{
    public class ClearSignatureMessage : ValueChangedMessage<bool>
    {
        public ClearSignatureMessage(bool value) : base(value)
        {

        }
    }
}
