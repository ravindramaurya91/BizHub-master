using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CommonUtil {
    public class DateFunction {


        //public static string DateToSqlString(DateTime toDate) {
        //    return toDate.Year.ToString() + "-" + toDate.Month.ToString() + "-" + toDate.Day.ToString();
        //}
        //public static DateTime GetStartOfDay(DateTime toDate) {
        //    return new DateTime(toDate.Year, toDate.Month, toDate.Day, 0, 0, 01);
        //}
        //public static DateTime GetEndOfDay(DateTime toDate) {
        //    return new DateTime(toDate.Year, toDate.Month, toDate.Day, 23, 59, 59);
        //}
        public static DateTime? EpochToDate(string tsEpochDateAsString) {
            DateTime? oReturn = null;
            if (!string.IsNullOrEmpty(tsEpochDateAsString)) {
                oReturn = EpochToDate(Convert.ToInt64(tsEpochDateAsString));
            }
            return oReturn;
        }
        public static DateTime EpochToDate(Int64 tiEpochTime) {
            DateTime oEpochStartingDate = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return oEpochStartingDate.AddSeconds(tiEpochTime);
        }
        public static string ToSqlDateString(DateTime toDate) {
            return "'" + toDate.Year.ToString() + "-" + toDate.Month.ToString() + "-" + toDate.Day.ToString() + "'";
        }

        public static DateTime GetMostRecentDOW(DateTime toDate, System.DayOfWeek toDayOfWeek) {
            int i = Convert.ToInt32(toDate.DayOfWeek);
            return GetMostRecentDOW(toDate, i);
        }
        public static DateTime GetMostRecentDOW(DateTime toDate, int toTargetDOW) {
            DateTime oReturn = toDate;
            int i = Convert.ToInt32(toDate.DayOfWeek); 

            if (i != toTargetDOW) {
                if (toTargetDOW < i) {
                    oReturn = toDate.AddDays(i - toTargetDOW);
                } else {
                    oReturn = toDate.AddDays(((i + toTargetDOW) - 1) * -1);
                }
            }
            return oReturn;
        }
        public static DateTime GetFirstDayOfWeek(DateTime toDateTime) {
            return GetFirstDayOfFutureWeek(toDateTime, 0);
        }
        //public static DateTime GetFirstDayOfMonth(DateTime toDateTime) {
        //    return new DateTime(toDateTime.Year, toDateTime.Month, 1, 0, 0, 1);
        //}
        //public static DateTime GetLastDayOfMonth(DateTime toDateTime) {
        //    return new DateTime(toDateTime.Year, toDateTime.Month, toDateTime.Day + GetDaysLeftInMonth(toDateTime), 23, 59, 59);
        //}
        public static DateTime GetFirstDayOfFutureWeek(DateTime toDateTime, int tiWeeksForward) {
            toDateTime += new TimeSpan((tiWeeksForward * 7), 0, 0, 0);
            int iDOW = Convert.ToInt32(toDateTime.DayOfWeek);
            return toDateTime + new TimeSpan((iDOW * -1), toDateTime.Hour * -1, toDateTime.Minute * -1, (toDateTime.Second * -1) + 1);
        }
        public static int GetDaysLeftInMonth(DateTime toDateTime) {
            return GetDaysInMonth(toDateTime) - toDateTime.Day;
        }
        public static int GetDaysInMonth(DateTime toDateTime) {
            int iDaysInMonth = 31;

            switch (toDateTime.Month) {
                case 2:
                    iDaysInMonth = 28;
                    break;
                case 4:
                case 6:
                case 9:
                case 11:
                    iDaysInMonth = 30;
                    break;
            }
            return iDaysInMonth;
        }

        //public static DateTime GetNextDOW(DateTime toDateTime, DayOfWeek teDayOfWeek) {
        //    // Returns the next "Day" (Tuesday, Friday, etc.) going forward
        //    // If the day DOW we call in with (Date Parm) == the target day of week we will go forward 
        //    // to the next week then pick the traget Day
        //    return GetNextDay(toDateTime, Convert.ToInt32(teDayOfWeek));
        //}
        public static DateTime GetNextDOW(DateTime toDateTime, int tiDayOfWeek) {
            // Returns the next "Day" (Tuesday, Friday, etc.) going forward
            // If the day DOW we call in with (Date Parm) == the target day of week we will go forward 
            // to the next week then pick the traget Day
            DateTime oReturn;
            int iDOW = Convert.ToInt32(toDateTime.DayOfWeek);
            int iDiff = tiDayOfWeek - iDOW;
            if (iDOW < tiDayOfWeek) {
                iDiff = tiDayOfWeek - iDOW;
                oReturn = toDateTime + new TimeSpan((iDiff), 0, 0, 0);
            } else {
                oReturn = GetFirstDayOfFutureWeek(toDateTime, 1) + new TimeSpan(tiDayOfWeek, 0, 0, 0);
            }
            return oReturn;
        }

        //public static int DOW(DateTime toDateTime) {
        //    return Convert.ToInt32(toDateTime.DayOfWeek);
        //}
        public static string CDOW(DateTime toDateTime) {
            int i = Convert.ToInt32(toDateTime.DayOfWeek);
            string s = "";
            switch (i) {
                case 0:
                    s = "Sunday";
                    break;
                case 1:
                    s = "Monday";
                    break;
                case 2:
                    s = "Tuesday";
                    break;
                case 3:
                    s = "Wednesday";
                    break;
                case 4:
                    s = "Thursday";
                    break;
                case 5:
                    s = "Friday";
                    break;
                case 6:
                    s = "Saturday";
                    break;

            }
            return s;
        }
        public static string CDOW_Abbreviation(DateTime toDateTime) {
            int i = Convert.ToInt32(toDateTime.DayOfWeek);
            string s = "";
            switch (i) {
                case 0:
                    s = "Sun.";
                    break;
                case 1:
                    s = "Mon.";
                    break;
                case 2:
                    s = "Tues.";
                    break;
                case 3:
                    s = "Wed.";
                    break;
                case 4:
                    s = "Thurs.";
                    break;
                case 5:
                    s = "Fri.";
                    break;
                case 6:
                    s = "Sat.";
                    break;

            }
            return s;
        }
        public static string CMonth(DateTime toDateTime) {
            int i = toDateTime.Month;
            return CMonth(i);
        }
        public static string CMonth(int tiMonth) {
                string s = "";
            switch (tiMonth) {
                case 1:
                    s = "January";
                    break;
                case 2:
                    s = "February";
                    break;
                case 3:
                    s = "March";
                    break;
                case 4:
                    s = "April";
                    break;
                case 5:
                    s = "May";
                    break;
                case 6:
                    s = "June";
                    break;
                case 7:
                    s = "July";
                    break;
                case 8:
                    s = "August";
                    break;
                case 9:
                    s = "September";
                    break;
                case 10:
                    s = "October";
                    break;
                case 11:
                    s = "November";
                    break;
                case 12:
                    s = "December";
                    break;
            }
            return s;
        }
        public static string CMonth_Abbreviation(DateTime toDateTime) {
            int i = toDateTime.Month;
            string s = "";
            switch (i) {
                case 1:
                    s = "Jan.";
                    break;
                case 2:
                    s = "Feb.";
                    break;
                case 3:
                    s = "March";
                    break;
                case 4:
                    s = "April";
                    break;
                case 5:
                    s = "May";
                    break;
                case 6:
                    s = "June";
                    break;
                case 7:
                    s = "July";
                    break;
                case 8:
                    s = "Aug.";
                    break;
                case 9:
                    s = "Sept.";
                    break;
                case 10:
                    s = "Oct.";
                    break;
                case 11:
                    s = "Nov.";
                    break;
                case 12:
                    s = "Dec.";
                    break;
            }
            return s;
        }
        public static DateTime GetSequentialDate(string tsSequence, string tsTargetDay, DateTime toDateTime) {
            // This method will return the (nth) (DOW) of a month
            // ie: the "First" or "Second" "Thursday" of the month
            // 
            // Acceptable values for tsSequence (First, Second, Third, Fourth, Last, 1st, 2nd, 3rd, 4th);
            return GetSequentialDate(GetSequenceFromString(tsSequence), GetDowFromString(tsTargetDay), toDateTime);
        }
        public static DateTime GetSequentialDate(string tsSequence, DayOfWeek teDayOfWeek, DateTime toDateTime) {
            return GetSequentialDate(GetSequenceFromString(tsSequence), Convert.ToInt32(teDayOfWeek), toDateTime);
        }
        public static DateTime GetSequentialDate(int tiSequence, DayOfWeek teDayOfWeek, DateTime toDateTime) {
            return GetSequentialDate(tiSequence, Convert.ToInt32(teDayOfWeek), toDateTime);
        }
        public static DateTime GetSequentialDate(int tiSequence, int tiDayOfWeek, DateTime toDateTime) {
            int iLastDayOfMonth = GetDaysInMonth(toDateTime);
            int iStartingDOW = Convert.ToInt32(new DateTime(toDateTime.Year, toDateTime.Month, 1).DayOfWeek);
            int iAnchorPoint = tiDayOfWeek - iStartingDOW;
            int iDow;

            if ((tiSequence == 1) && (iStartingDOW < tiDayOfWeek)) {
                iDow = 1 + (tiDayOfWeek - iStartingDOW);
            } else {
                iDow = ((tiDayOfWeek - iStartingDOW) + 1) + (tiSequence * 7);
                if (iDow > iLastDayOfMonth) {
                    iDow = ((tiDayOfWeek - iStartingDOW) + 1) + ((tiSequence - 1) * 7);
                }
            }
            return new DateTime(toDateTime.Year, toDateTime.Month, iDow, toDateTime.Hour, toDateTime.Minute, toDateTime.Second, toDateTime.Millisecond);
        }
        public static int GetSequenceFromString(string tsSequence) {
            int iReturn = -1;
            tsSequence = tsSequence.ToUpper().Trim();
            if ((tsSequence.Equals("FIRST")) || (tsSequence.Equals("1ST"))) {
                iReturn = 1;
            }
            if ((tsSequence.Equals("SECOND")) || (tsSequence.Equals("2ND"))) {
                iReturn = 2;
            }
            if ((tsSequence.Equals("THIRD")) || (tsSequence.Equals("3RD"))) {
                iReturn = 3;
            }
            if ((tsSequence.Equals("FOURTH")) || (tsSequence.Equals("4TH"))) {
                iReturn = 4;
            }
            if (tsSequence.Equals("LAST")) {
                iReturn = 5;
            }
            return iReturn;
        }

        public static int GetDowFromString(string tsDayName) {
            int iReturn = -1;
            tsDayName = tsDayName.ToUpper().Trim();
            switch (tsDayName) {
                case "SUNDAY":
                    iReturn = 0;
                    break;
                case "SUN.":
                    iReturn = 0;
                    break;
                case "SUN":
                    iReturn = 0;
                    break;
                case "MONDAY":
                    iReturn = 1;
                    break;
                case "MON.":
                    iReturn = 1;
                    break;
                case "MON":
                    iReturn = 1;
                    break;
                case "TUESDAY":
                    iReturn = 2;
                    break;
                case "TUES.":
                    iReturn = 2;
                    break;
                case "TUES":
                    iReturn = 2;
                    break;
                case "WEDNESDAY":
                    iReturn = 3;
                    break;
                case "WED.":
                    iReturn = 3;
                    break;
                case "WED":
                    iReturn = 3;
                    break;
                case "THURSDAY":
                    iReturn = 4;
                    break;
                case "THURS.":
                    iReturn = 4;
                    break;
                case "THURS":
                    iReturn = 4;
                    break;
                case "FRIDAY":
                    iReturn = 5;
                    break;
                case "FRI.":
                    iReturn = 5;
                    break;
                case "FRI":
                    iReturn = 5;
                    break;
                case "SATURDAY":
                    iReturn = 6;
                    break;
                case "SAT.":
                    iReturn = 6;
                    break;
                case "SAT":
                    iReturn = 6;
                    break;
            }
            return iReturn;
        }
        public static int GetMonthFromString(string tsMonth) {
            tsMonth = tsMonth.ToUpper().Trim();
            int iReturnValue = -1;

            switch (tsMonth) {
                case "JANUARY":
                    iReturnValue = 1;
                    break;
                case "FEBRUARY":
                    iReturnValue = 2;
                    break;
                case "MARCH":
                    iReturnValue = 3;
                    break;
                case "APRIL":
                    iReturnValue = 4;
                    break;
                case "MAY":
                    iReturnValue = 5;
                    break;
                case "JUNE":
                    iReturnValue = 6;
                    break;
                case "JULY":
                    iReturnValue = 7;
                    break;
                case "AUGUST":
                    iReturnValue = 8;
                    break;
                case "SEPTEMBER":
                    iReturnValue = 9;
                    break;
                case "OCTOBER":
                    iReturnValue = 10;
                    break;
                case "NOVEMBER":
                    iReturnValue = 11;
                    break;
                case "DECEMBER":
                    iReturnValue = 12;
                    break;
            }
            return iReturnValue;
        }
        public static string GetMonthStringFromInt(int tiMonth) {
            string sReturn = "";

            switch (tiMonth) {
                case 1:
                    sReturn = "January";
                    break;
                case 2:
                    sReturn = "February";
                    break;
                case 3:
                    sReturn = "March";
                    break;
                case 4:
                    sReturn = "April";
                    break;
                case 5:
                    sReturn = "May";
                    break;
                case 6:
                    sReturn = "June";
                    break;
                case 7:
                    sReturn = "July";
                    break;
                case 8:
                    sReturn = "August";
                    break;
                case 9:
                    sReturn = "September";
                    break;
                case 10:
                    sReturn = "October";
                    break;
                case 11:
                    sReturn = "November";
                    break;
                case 12:
                    sReturn = "December";
                    break;
            }
            return sReturn;
        }
        public static DateTime GetDateTimeFromDateTimeString(string tsDateTimeString) {
            DateTime oReturn = new DateTime(1900, 1, 1);
            string[] sDateTimeComponents = tsDateTimeString.Split(' ');
            string[] sDateComponents = sDateTimeComponents[0].Split('/');
            string[] sTimeComponents = sDateTimeComponents[1].Split(':');
            string sAmPm = sDateTimeComponents[2];


            int iMonth = 1, iDay = 1, iYear = 1900, iHour = 1, iMinute = 1, iSecond = 1;

            if (sTimeComponents.Length == 3) {
                iHour = Convert.ToInt32(sTimeComponents[0]);
                iMinute = Convert.ToInt32(sTimeComponents[1]);
                iSecond = Convert.ToInt32(sTimeComponents[2]);
                if (sAmPm.ToUpper().Equals("PM")) {
                    iHour += 12;
                }
            }
            if (sDateComponents.Length == 3) {
                iMonth = Convert.ToInt32(sDateComponents[0]);
                iDay = Convert.ToInt32(sDateComponents[1]);
                iYear = Convert.ToInt32(sDateComponents[2]);

            }
            return new DateTime(iYear, iMonth, iDay);
        }

        public static DateTime GetDateFromShortDateString(string tsShortDateString) {
            DateTime oReturn = new DateTime(1900, 1, 1);
            string[] sDateComponents = tsShortDateString.Split('/');
            int iMonth, iDay, iYear;

            if (sDateComponents.Length == 3) {
                iMonth = Convert.ToInt32(sDateComponents[0]);
                iDay = Convert.ToInt32(sDateComponents[1]);
                iYear = Convert.ToInt32(sDateComponents[2]);

                oReturn = new DateTime(iYear, iMonth, iDay);
            }
            return oReturn;
        }

    }
}
