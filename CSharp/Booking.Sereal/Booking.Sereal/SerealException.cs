using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Sereal
{
    public class SerealException : Exception
    {
        public SerealException(string message) : base(message) { }
        public SerealException(string message, Exception innerException) : base(message, innerException) { }
    }
}
