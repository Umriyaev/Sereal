using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Sereal
{
    public class PerlUndef
    {
        public static PerlUndef CANONICAL { get;} = new PerlUndef();

        public override string ToString()
        {
            return "Undef";
        }
    }
}
