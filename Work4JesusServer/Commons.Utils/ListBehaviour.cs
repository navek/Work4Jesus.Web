using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commons.Utils
{
   public static class ListExtension
    {
       public static IList<T> CloneT<T>(this IList<T> list)
       {
           return list.Where((a) => true).ToList();
       }

        public static IList CloneO(this IList list)
        {
            List<object> objects = new List<object>();
            foreach (var o in list)
            {
                objects.Add(o);
            }
            return objects;
        }

        public static bool OwnEqual(this Object a, Object b)
        {
            var aList = a as IList;
            var bList = b as IList;
            if ((aList != null) && (bList != null))
            {
                return aList.CompareEquality(bList);
            }
            return Equals(a, b);
        }
        public static bool CompareEquality(this IList source, IList toCompare)
       {
           if (source.Count != toCompare.Count)
               return false;
           for (int i = 0; i < source.Count; i++)
           {
               if (source[i] != toCompare[i])
                   return false;
           }
           return true;
       }
    }
}
