using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CommonUtil {
    public class TypeConverter {

        public static T ChangeType<T>(object value) {
            return (T)ChangeType(typeof(T), value);
        }

        private static object ChangeType(Type t, object value) {
            return TypeDescriptor.GetConverter(t).ConvertFrom(value);
        }


    }
}
