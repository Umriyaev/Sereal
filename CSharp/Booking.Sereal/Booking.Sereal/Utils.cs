using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Booking.Sereal
{
    public class Utils
    {
        private static char[] hexDigits =
        {
            '0', '1', '2', '3', '4',
            '5', '6', '7', '8', '9',
            'a', 'b', 'c', 'd', 'e', 'f'
        };

        public static string Join(string[] parts, string separator)
        {
            return Join(parts.ToList(), separator);
        }

        public static string Join<T>(List<T> things, string separator) where T : class
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < things.Count; i++)
            {
                sb.Append(things[i].ToString());
                if (i < things.Count - 1)
                {
                    sb.Append(separator);
                }
            }
            return sb.ToString();
        }

        public static string Dump(object obj)
        {
            string d = Dump(obj, 0);
            alreadyOutput.Clear();
            return d;
        }

        private static HashSet<int> alreadyOutput = new HashSet<int>();

        private static string Dump(object obj, int indent)
        {
            if (obj != null && alreadyOutput.Contains(obj.GetHashCode())){
                return "@" + obj.GetHashCode();
            }
            else if (obj != null)
            {
                alreadyOutput.Add(obj.GetHashCode());
            }

            string ind = "";
            for (int i = 0; i < indent; i++)
            {
                ind += "\t";
            }

            if (obj == null)
            {
                return "(NULL)";
            }
            else if (obj is IDictionary)
            {
                StringBuilder sb = new StringBuilder(ind + "Dictionary@" + obj.GetHashCode() + "{\n"); //in Java implementation Map is used instead of Dictionary
                Dictionary<object, object> dictionary = (Dictionary<object, object>)obj;
                object[] array = dictionary.Keys.ToArray();
                try
                {
                    Array.Sort(array);
                }
                catch (InvalidCastException e)
                {
                    //in case where the array can't be sorted (if the keys
                    // don't implement IComparable
                }

                foreach (var key in array)
                {
                    sb.Append(ind + Dump(key, indent + 1));
                    sb.Append(" => ");
                    sb.Append(Dump(dictionary[key], indent + 1));
                    sb.Append("\n");
                }

                sb.Append(ind).Append("}");
                return sb.ToString();
            }
            else if (obj is IList)
            {
                List<object> list = (List<object>)obj;
                string type = list.Count == 0 ? "" : list[0].GetType().Name;
                StringBuilder sb = new StringBuilder(ind + "List<" + type + ">{\n");
                foreach (var item in list)
                {
                    sb.Append(Dump(item, indent + 1));
                    sb.Append("\n");
                }
                sb.Append(ind).Append("}");
                return sb.ToString();
            }
            else if (obj is Array)
            {
                StringBuilder sb = new StringBuilder(ind + "Array@" + obj.GetHashCode() + " [\n");
                Array arr = (Array)obj;
                for (int i = 0; i < arr.Length; i++)
                {
                    sb.Append(Dump(arr.GetValue(i), indent + 1));
                    sb.Append("\n");
                }
                sb.Append(ind).Append("]");
                return sb.ToString();
            }
            else if (obj is Regex)
            {
                Regex regex = (Regex)obj;
                return "/" + regex.ToString() + "/"
                    + (((regex.Options & RegexOptions.IgnoreCase) > 0) ? "i" : "")
                    + (((regex.Options & RegexOptions.Multiline) > 0) ? "m" : "")
                    + "@" + obj.GetHashCode();
            }
            else if (obj is PerlAlias)
            {
                return ind + "Alias: " + Dump(((PerlAlias)obj).Value, indent);
            }
            else if (obj is PerlReference)
            {
                return ind + ("Perlref@" + obj.GetHashCode() + ": " + Dump(((PerlReference)obj).Value, indent));
            }
            else if (obj is WeakReference)
            {
                return ind + "(weakref@" + obj.GetHashCode() + ") " + Dump(((WeakReference)obj).Target, 0);
            }
            else if (obj is PerlObject)
            {
                PerlObject po = (PerlObject)obj;
                return ind + "Object(" + (po.IsHash() ? "hash" : (po.IsArray() ? "array)" : "reference")) + "):" + po.Name + "= " + Dump(po.Data, 0);
            }
            else
            {
                return ind + obj.GetType().Name + "@" + obj.GetHashCode() + ": " + obj.ToString();
            }

        }

        public static string HexStringFromByteArray(byte[] input)
        {
            return HexStringFromByteArray(input, -1);
        }
        public static string HexStringFromByteArray(byte[] input, int group)
        {
            StringBuilder output = new StringBuilder(

                2 +
                input.Length * 2 +
                (group != -1 ? (input.Length / group + 1) : 0));
            output.Append("0x");
            int count = 0;
            foreach(var item in input)
            {
                output.Append(hexDigits[(item >> 4) & 0xf]);
                output.Append(hexDigits[item & 0xf]);

                if(group>0 && (++count== group))
                {
                    output.Append(' ');
                    count = 0;
                }
            }
            return output.ToString();
        }

        

    }
}
