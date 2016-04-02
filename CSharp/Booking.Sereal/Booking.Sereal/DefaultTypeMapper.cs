using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Sereal
{
    public class DefaultTypeMapper : ITypeMapper
    {
        public List<object> MakeArray(int size)
        {
            return new List<object>(size);
        }

        public Dictionary<string, object> MakeDictionary(int size)
        {
            return new Dictionary<string, object>(size);
        }

        public object MakeObject(string className, object data)
        {
            return new PerlObject(className, data);
        }

        public bool UseObjectArray()
        {
            return false;
        }
    }
}
