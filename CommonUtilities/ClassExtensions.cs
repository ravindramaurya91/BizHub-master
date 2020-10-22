using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace CommonUtil {

    public static class ClassExtension {

        #region DateTime
        // Return a string formatted the way a SQL insert will accept it
        public static string ToSqlString(this DateTime toDate) {
            return toDate.Year.ToString() + "-" + toDate.Month.ToString() + "-" + toDate.Day.ToString();
        }

        // Get a DateTime 1 milisecond into the new day to overcome the SQL query problem of Dates at midnight 00:00:00
        public static DateTime StartOfDay(this DateTime toDate) {
            return new DateTime(toDate.Year, toDate.Month, toDate.Day, 0, 0, 01);
        }
        public static Int64 ToEpochTime(this DateTime toDate) {
            return ToEpochTime_Seconds(toDate);
        }
        public static Int64 ToEpochTime_Seconds(this DateTime toDate) {
            DateTimeOffset oReturn = new DateTimeOffset(toDate.Year, toDate.Month, toDate.Day, toDate.Hour, toDate.Minute, toDate.Millisecond, TimeSpan.Zero);
            return oReturn.ToUnixTimeSeconds();
        }
        public static Int64 ToEpochTime_Milliseconds(this DateTime toDate) {
            DateTimeOffset oReturn = new DateTimeOffset(toDate.Year, toDate.Month, toDate.Day, toDate.Hour, toDate.Minute, toDate.Millisecond, TimeSpan.Zero);
            return oReturn.ToUnixTimeMilliseconds();
        }
        // Get a DateTime 1 milisecond before the end of day to overcome the SQL query problem of Dates at midnight 00:00:00
        public static DateTime EndOfDay(this DateTime toDate) {
            return new DateTime(toDate.Year, toDate.Month, toDate.Day, 23, 59, 59);
        }

        // Return a date in the same month with the day set at 1
        public static DateTime FirstDayOfMonth(this DateTime toDateTime) {
            return new DateTime(toDateTime.Year, toDateTime.Month, 1, 0, 0, 1);
        }
        // Return a date in the same month with the day set to the last day of the month
        public static DateTime LastDayOfMonth(this DateTime toDateTime) {
            return new DateTime(toDateTime.Year, toDateTime.Month + 1, 1).AddDays(-1);
        }
        //Return an integer of the days left in the month from the current date value
        public static int DaysLeftInMonth(this DateTime toDateTime) {
            return DateFunction.GetDaysInMonth(toDateTime) - toDateTime.Day;
        }
        // Return the next occurrence of a specific day of the week  (the next Monday or Tuesday, etc)
        public static DateTime NextDOW(this DateTime toDateTime, DayOfWeek teDayOfWeek) {
            return DateFunction.GetNextDOW(toDateTime, Convert.ToInt32(teDayOfWeek));
        }
        // Return an integer indicating which Day Of the Week a date represents
        public static int DOW(this DateTime toDateTime) {
            return Convert.ToInt32(toDateTime.DayOfWeek);
        }
        //Character Day Of Week: Return an string indicating which Day Of the Week a date represents (Sunday, Monday, etc)
        public static string CDOW(this DateTime toDateTime) {
            return DateFunction.CDOW(toDateTime);
        }
        // Return an abbreviation of the Day Of the Week a date represents (Sun. Mon. Tues. etc)
        public static string CDOW_Abbreviation(this DateTime toDateTime) {
            return DateFunction.CDOW_Abbreviation(toDateTime);
        }
        // Character Month: Return the string representing the current month.  (January, February, etc).
        public static string CMonth(this DateTime toDateTime) {
            return DateFunction.CMonth(toDateTime.Month);
        }
        // Return the (nth) (DOW) for the month of the Date past in
        public static DateTime GetSequentialDOW(this DateTime toDateTime, string tsSequence, string tsTargetDay) {
            // Acceptable values for tsSequence (First, Second, Third, Fourth, Last, 1st, 2nd, 3rd, 4th);
            // Acceptable values for tsTargetDay Sunday", Monday", "Teusday", etc. 
            return DateFunction.GetSequentialDate(DateFunction.GetSequenceFromString(tsSequence), DateFunction.GetDowFromString(tsTargetDay), toDateTime);
        }
        public static DateTime GetSequentialDOW(this DateTime toDateTime, string tsSequence, DayOfWeek teDayOfWeek) {
            return DateFunction.GetSequentialDate(DateFunction.GetSequenceFromString(tsSequence), Convert.ToInt32(teDayOfWeek), toDateTime);
        }
        public static DateTime GetSequentialDOW(this DateTime toDateTime, int tiSequence, DayOfWeek teDayOfWeek) {
            return DateFunction.GetSequentialDate(tiSequence, Convert.ToInt32(teDayOfWeek), toDateTime);
        }

        #endregion (DateTime)

        #region Dictionary

        //public static Dictionary<K, V> DictionaryMergeLeft<K, V>(this Dictionary<K, V> toSource, params IDictionary<K, V>[] others) {
        //    // Merge two Dictionaries together
        //    // Example
        //    //        Dictionary<string, string> t1 = new Dictionary<string, string>();
        //    //        t1.Add("a", "aaa");
        //    //Dictionary<string, string> t2 = new Dictionary<string, string>();
        //    //        t2.Add("b", "bee");
        //    //Dictionary<string, string> t3 = new Dictionary<string, string>();
        //    //        t3.Add("c", "cee");
        //    //t3.Add("d", "dee");
        //    //t3.Add("b", "bee");
        //    //Dictionary<string, string> merged = t1.MergeLeft(t2, t2, t3);

        //    var newMap = new Dictionary<K, V>(toSource, toSource.Comparer);
        //    foreach (IDictionary<K, V> src in
        //        (new List<IDictionary<K, V>> { toSource }).Concat<K,V>(others)) {
        //        // ^-- echk. Not quite there type-system.
        //        foreach (KeyValuePair<K, V> p in src) {
        //            newMap[p.Key] = p.Value;
        //        }
        //    }
        //    return newMap;
        //}
        public static Dictionary<K, V> AddRange<K, V>(this Dictionary<K, V> one, Dictionary<K, V> two) {
            foreach (var kvp in two) {
                if (one.ContainsKey(kvp.Key))
                    one[kvp.Key] = two[kvp.Key];
                else
                    one.Add(kvp.Key, kvp.Value);
            }
            return one;
        }

        #endregion (Dictionary)

        #region int
        public static bool IsGreaterThan(this int i, int value) {
            return i > value;
        }
        #endregion (int)

        #region Object
        public static T DeepClone<T>(this object objSource) {

            using (MemoryStream stream = new MemoryStream()) {

                BinaryFormatter formatter = new BinaryFormatter();

                formatter.Serialize(stream, objSource);

                stream.Position = 0;

                return (T)formatter.Deserialize(stream);
            }
        }
        #endregion (Object)


    #region String
    public static int IndexOfNthOccurrence(this string str, string value, int nth = 0) {
            if (nth < 0)
                throw new ArgumentException("Can not find a negative index of substring in string. Must start with 0");

            int offset = str.IndexOf(value);
            for (int i = 0; i < nth; i++) {
                if (offset == -1) return -1;
                offset = str.IndexOf(value, offset + 1);
            }

            return offset;
        }
        #endregion (String)

    }
}
