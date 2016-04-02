using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Sereal
{
    public class PerlObject
    {
        public string Name { get; private set; }
        public object Data { get; private set; }
        public PerlObject(string className, object obj)
        {
            Data = obj;
            Name = className;
        }

        public bool IsHash()
        {
            return Data is IDictionary;
        }

        public bool IsArray()
        {
            return Data is Array;
        }
        public bool IsReference()
        {
            return !IsHash() && !IsArray();
        }
    }
}
