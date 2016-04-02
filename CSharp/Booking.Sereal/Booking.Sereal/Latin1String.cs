using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Sereal
{
    public class Latin1String
    {
        private Encoding charset_latin = Encoding.GetEncoding("ISO-8859-1");
        public byte[] Bytes { get; private set; }

        public Latin1String(string s)
        {
            Encoding utf8 = Encoding.UTF8;
            byte[] utfBytes = utf8.GetBytes(s);
            this.Bytes = Encoding.Convert(utf8, charset_latin, utfBytes);
        }

        public Latin1String(byte[] bytes)
        {
            this.Bytes = bytes;
        }

        public override string ToString()
        {
            return this.charset_latin.GetString(this.Bytes);
        }

        public char CharAt(int index)
        {
            return (char)this.Bytes[index];
        }

        public int Length { get { return this.Bytes.Length; } }

        public string SubSequence(int start, int end)
        {
            return this.ToString().Substring(start, end - start);
        }

        public string GetString()
        {
            return this.ToString();
        }

        public override int GetHashCode()
        {
            return this.Bytes.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Latin1String))
                return false;
            if (this == obj)
                return true;

            int length = this.Length;
            if (((Latin1String)obj).Length != length)
                return false;

            Latin1String latObj = (Latin1String)obj;
            for (int i = 0; i < length; i++)
                if (this.Bytes[i] != latObj.Bytes[i])
                    return false;

            return true;
        }
    }
}
