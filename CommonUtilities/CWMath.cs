using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonUtil {
    public static class CWMath {

        #region Conversions
        public static double MilesToMeters(int tiMiles) {
            return tiMiles / 0.0006213712;
        }
        #endregion (Conversions)

        #region GreaterOf
        public static Int16 GreaterOf(Int16 tiNum1, Int16 tiNum2) {
            if (tiNum2 > tiNum1) {
                tiNum1 = tiNum2;
            }
            return tiNum1;
        }
        public static Int32 GreaterOf(Int32 tiNum1, Int32 tiNum2) {
            if (tiNum2 > tiNum1) {
                tiNum1 = tiNum2;
            }
            return tiNum1;
        }
        public static Int64 GreaterOf(Int64 tiNum1, Int64 tiNum2) {
            if (tiNum2 > tiNum1) {
                tiNum1 = tiNum2;
            }
            return tiNum1;
        }
        public static double GreaterOf(double tiNum1, double tiNum2) {
            if (tiNum2 > tiNum1) {
                tiNum1 = tiNum2;
            }
            return tiNum1;
        }
        public static decimal GreaterOf(decimal tiNum1, decimal tiNum2) {
            if (tiNum2 > tiNum1) {
                tiNum1 = tiNum2;
            }
            return tiNum1;
        }
        public static float GreaterOf(float tiNum1, float tiNum2) {
            if (tiNum2 > tiNum1) {
                tiNum1 = tiNum2;
            }
            return tiNum1;
        }
        public static DateTime GreaterOf(DateTime tiDate1, DateTime tiDate2) {
            if (tiDate2 > tiDate1) {
                tiDate1 = tiDate2;
            }
            return tiDate1;
        }

        //********         Compare 3 Numbers      *********
        public static Int16 GreaterOf(Int16 tiNum1, Int16 tiNum2, Int16 tiNum3) {
            return GreaterOf(tiNum1, GreaterOf(tiNum2, tiNum3));
        }
        public static Int32 GreaterOf(Int32 tiNum1, Int32 tiNum2, Int32 tiNum3) {
            return GreaterOf(tiNum1, GreaterOf(tiNum2, tiNum3));
        }
        public static Int64 GreaterOf(Int64 tiNum1, Int64 tiNum2, Int64 tiNum3) {
            return GreaterOf(tiNum1, GreaterOf(tiNum2, tiNum3));
        }
        public static double GreaterOf(double tiNum1, double tiNum2, double tiNum3) {
            return GreaterOf(tiNum1, GreaterOf(tiNum2, tiNum3));
        }
        public static decimal GreaterOf(decimal tiNum1, decimal tiNum2, decimal tiNum3) {
            return GreaterOf(tiNum1, GreaterOf(tiNum2, tiNum3));
        }
        public static float GreaterOf(float tiNum1, float tiNum2, float tiNum3) {
            return GreaterOf(tiNum1, GreaterOf(tiNum2, tiNum3));
        }
        public static DateTime GreaterOf(DateTime tiDate1, DateTime tiDate2, DateTime tiDate3) {
            return GreaterOf(tiDate1, GreaterOf(tiDate2, tiDate3));
        }
        //********         Compare 4 Numbers      *********
        public static Int16 GreaterOf(Int16 tiNum1, Int16 tiNum2, Int16 tiNum3, Int16 tiNum4) {
            return GreaterOf(tiNum1, GreaterOf(tiNum2, GreaterOf(tiNum3, tiNum4)));
        }
        public static Int32 GreaterOf(Int32 tiNum1, Int32 tiNum2, Int32 tiNum3, Int32 tiNum4) {
            return GreaterOf(tiNum1, GreaterOf(tiNum2, GreaterOf(tiNum3, tiNum4)));
        }
        public static Int64 GreaterOf(Int64 tiNum1, Int64 tiNum2, Int64 tiNum3, Int64 tiNum4) {
            return GreaterOf(tiNum1, GreaterOf(tiNum2, GreaterOf(tiNum3, tiNum4)));
        }
        public static double GreaterOf(double tiNum1, double tiNum2, double tiNum3, double tiNum4) {
            return GreaterOf(tiNum1, GreaterOf(tiNum2, GreaterOf(tiNum3, tiNum4)));
        }
        public static decimal GreaterOf(decimal tiNum1, decimal tiNum2, decimal tiNum3, decimal tiNum4) {
            return GreaterOf(tiNum1, GreaterOf(tiNum2, GreaterOf(tiNum3, tiNum4)));
        }
        public static float GreaterOf(float tiNum1, float tiNum2, float tiNum3, float tiNum4) {
            return GreaterOf(tiNum1, GreaterOf(tiNum2, GreaterOf(tiNum3, tiNum4)));
        }
        public static DateTime GreaterOf(DateTime tiDate1, DateTime tiDate2, DateTime tiDate3, DateTime tiDate4) {
            return GreaterOf(tiDate1, GreaterOf(tiDate2, GreaterOf(tiDate3, tiDate4)));
        }
        #endregion (GreaterOf)

        #region LesserOf
        public static Int16 LesserOf(Int16 tiNum1, Int16 tiNum2) {
            if (tiNum2 < tiNum1) {
                tiNum1 = tiNum2;
            }
            return tiNum1;
        }
        public static Int32 LesserOf(Int32 tiNum1, Int32 tiNum2) {
            if (tiNum2 < tiNum1) {
                tiNum1 = tiNum2;
            }
            return tiNum1;
        }
        public static Int64 LesserOf(Int64 tiNum1, Int64 tiNum2) {
            if (tiNum2 < tiNum1) {
                tiNum1 = tiNum2;
            }
            return tiNum1;
        }
        public static double LesserOf(double tiNum1, double tiNum2) {
            if (tiNum2 < tiNum1) {
                tiNum1 = tiNum2;
            }
            return tiNum1;
        }
        public static decimal LesserOf(decimal tiNum1, decimal tiNum2) {
            if (tiNum2 < tiNum1) {
                tiNum1 = tiNum2;
            }
            return tiNum1;
        }
        public static float LesserOf(float tiNum1, float tiNum2) {
            if (tiNum2 < tiNum1) {
                tiNum1 = tiNum2;
            }
            return tiNum1;
        }
        public static DateTime LesserOf(DateTime tiDate1, DateTime tiDate2) {
            if (tiDate2 < tiDate1) {
                tiDate1 = tiDate2;
            }
            return tiDate1;
        }
        #endregion (LesserOf)

        #region Odd & Even
        public static bool IsEven(object tiNum) {
            return !IsOdd(tiNum);
        }
        public static bool IsOdd(object tiNum) {
            return (Math.Abs(TrueMod(tiNum, 2)) == 1);
        }
        #endregion (Odd & Even)

        #region Mod
        public static Int16 Mod(Int16 tiNum1, Int16 tiNum2) {
            return Convert.ToInt16(TrueMod(tiNum1, tiNum2));
        }
        public static Int32 Mod(Int32 tiNum1, Int32 tiNum2) {
            return Convert.ToInt32(TrueMod(tiNum1, tiNum2));
        }
        public static Int64 Mod(Int64 tiNum1, Int64 tiNum2) {
            return Convert.ToInt64(TrueMod(tiNum1, tiNum2));
        }
        public static double Mod(double d1, double d2) {
            return Math.IEEERemainder(d1, d2);
        }
        public static decimal Mod(decimal tiNum1, decimal tiNum2) {
            return Convert.ToDecimal(TrueMod(tiNum1, tiNum2));
        }
        private static double TrueMod(object toNum1, object toNum2) {
            double d1 = Convert.ToDouble(toNum1);
            double d2 = Convert.ToDouble(toNum2);
            return Math.IEEERemainder(d1, d2);
        }
        #endregion (Mod)

        #region Floor
        public static Int32 FloorToInt(object tiNum1) {
            return Convert.ToInt32(TrueFloor(tiNum1));
        }
        public static Int16 Floor(Int16 tiNum1) {
            return Convert.ToInt16(TrueFloor(tiNum1));
        }
        public static Int32 Floor(Int32 tiNum1) {
            return Convert.ToInt32(TrueFloor(tiNum1));
        }
        public static Int64 Floor(Int64 tiNum1) {
            return Convert.ToInt64(TrueFloor(tiNum1));
        }
        public static double Floor(double d1) {
            return Math.Floor(d1);
        }
        public static decimal Floor(decimal tiNum1) {
            return Convert.ToDecimal(TrueFloor(tiNum1));
        }
        public static double TrueFloor(object toNum1) {
            double d1 = Convert.ToDouble(toNum1);
            return Math.Floor(d1);
        }
        #endregion (Floor)

        #region Ceiling
        public static Int32 CeilingToInt(object tiNum1) {
            return Convert.ToInt32(TrueCeiling(tiNum1));
        }
        public static Int16 Ceiling(Int16 tiNum1) {
            return Convert.ToInt16(TrueCeiling(tiNum1));
        }
        public static Int32 Ceiling(Int32 tiNum1) {
            return Convert.ToInt32(TrueCeiling(tiNum1));
        }
        public static Int64 Ceiling(Int64 tiNum1) {
            return Convert.ToInt64(TrueCeiling(tiNum1));
        }
        public static double Ceiling(double d1) {
            return Math.Ceiling(d1);
        }
        public static decimal Ceiling(decimal tiNum1) {
            return Convert.ToDecimal(TrueCeiling(tiNum1));
        }
        public static double TrueCeiling(object toNum1) {
            double d1 = Convert.ToDouble(toNum1);
            return Math.Ceiling(d1);
        }
        #endregion (Ceiling)

        #region Between
        public static bool IsBetween<T>(this T targetValue, T lowerValue, T upperValue) where T : IComparable{
            //return Comparer<T>.Default.Compare(item, start) >= 0
            //    && Comparer<T>.Default.Compare(item, end) <= 0;
            return (lowerValue.CompareTo(targetValue) < 0) && (targetValue.CompareTo(upperValue) < 0);
        }
        #endregion (Between)


    }
}
