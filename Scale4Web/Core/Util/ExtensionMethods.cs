using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scale4Web.Util
{
    public static class ExtensionMethods
    {
        public static void AddRange<T>(this ICollection<T> list, IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                list.Add(item);
            }
        }

        public static Guid ToGuid(this int value)
        {
            byte[] bytes = new byte[16];
            BitConverter.GetBytes(value).CopyTo(bytes, 0);
            return new Guid(bytes);
        }

        public static T GetAttribute<T>(this object type)
        {
            T attrib = (T)Attribute.GetCustomAttributes(type.GetType()).OfType<T>().FirstOrDefault();
            return attrib;
        }
    }
}
