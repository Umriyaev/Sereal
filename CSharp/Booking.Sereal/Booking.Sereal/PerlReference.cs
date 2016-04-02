using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Sereal
{
    public class PerlReference
    {
        public object Value { get; set; }
        public PerlReference(object value)
        {
            Value = value;
        }

        public override string ToString()
        {
            return "Reference to: " + (Value == null ? "null" : Value.ToString());
        }
    }
}
