using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Sereal
{
    public class ByteArray
    {
        public byte[] Array { get; set; }
        public int Length { get; set; }

        public ByteArray(byte[] array) : this(array, array.Length) { }

        public ByteArray(byte[] array, int length)
        {
            this.Array = array;
            this.Length = length;
        }

        public ByteArray(MemoryStream ms) : this(ms.ToArray(), ms.Capacity) { }

        public void Ensure(int size)
        {
            if (size > Array.Length)
            {
                byte[] newArray = new byte[size * 3 / 2];
                this.Array.CopyTo(newArray, 0);
                this.Array = newArray;
            }
        }

    }
}
