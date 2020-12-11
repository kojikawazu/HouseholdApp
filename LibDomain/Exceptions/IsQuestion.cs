using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibDomain.Exceptions
{
    public static class IsQuestion
    {
        public static void IsNull(object o, string message)
        {
            // TODO nullチェック
            if (o == null)
            {
                throw new InputException(message);
            }
        }

        public static void IsString(string ms, string message) {
            if (ms == null || ms.Length == 0) {
                throw new InputException(message);
            }
        }

        public static void IsNullString(object o, string message)
        {
            if (o == null)
            {
                throw new InputException(message);
            }
            string ms = Convert.ToString(o);
            if (ms.Length == 0)
            {
                throw new InputException(message);
            }
        }

        public static bool IsNullString_returnBool(object o)
        {
            if (o == null)
            {
                return false;
            }
            string ms = Convert.ToString(o);
            if (ms.Length == 0)
            {
                return false;
            }
            return true;
        }

        public static void IsMinus(int value, string message) {
            if (value < 0) {
                throw new InputException(message);
            }
        }

        public static void IsZero(int data, string message) {
            if (data == 0) {
                throw new InputException(message);
            }
        }

        public static void IsCount(int data, int count, string message) { 
            if(data == count)
            {
                throw new InputException(message);
            }
        }

        public static void IsNotCount(int data, int count, string message)
        {
            if (data != count)
            {
                throw new InputException(message);
            }
        }

    }
}
