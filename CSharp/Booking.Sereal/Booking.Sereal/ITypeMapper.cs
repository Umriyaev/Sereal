using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Sereal
{
    public interface ITypeMapper
    {
        bool UseObjectArray();

        List<object> MakeArray(int size);

        Dictionary<string, object> MakeDictionary(int size);

        object MakeObject(string className, object data);
    }
}
