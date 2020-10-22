using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using System.Text;
using Microsoft.VisualBasic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace CommonUtil {
    public class StringUtil {

        public StringUtil() {
        }
        public static bool IsEmpty(string s) {
            return (s.Length == 0);
        }
        public static string GetAbsoluteString(string tsString) {
            // This method is designed to return an empty string when the parameter == null
            string bReturn = String.Empty;
            if (tsString != null) {
                bReturn = tsString;
            }
            return bReturn;
        }
        public static string StringTransform(string tsIncomingString, string tsTargetString) {
            return StringTransform(tsIncomingString, tsTargetString, "");
        }

        public static string StringTransform(string tsIncomingString, string tsTargetString, string tsReplacementString) {
            return tsIncomingString.Replace(tsTargetString, tsReplacementString);
        }

        public static string GetPathFromFileName(string tsFileName) {
            return System.IO.Path.GetDirectoryName(tsFileName);
        }

        public static string ToDelimitedString(List<Int64> toList) { 
            string sDelimiter = ", ";
            StringBuilder sb = new StringBuilder();

            foreach (var oItem in toList) {
                sb.Append(sDelimiter + oItem.ToString());
            }

            string sReturn = sb.ToString();
            if (sReturn.Length > 2) {
                sReturn = sReturn.Substring(2);
            }
            return sReturn;
        }

        public static string StripLeadingBlanks(string tsString) {
            return tsString.TrimStart(' ');
        }

        public static string StripTrailingBlanks(string tsString) {
            return tsString.TrimEnd(' ');
        }

        public static string StripPunctuation(string tsString) {
            return tsString.Replace(",", "")
                           .Replace("!", "")
                           .Replace(".", "")
                           .Replace("?", "")
                           .Replace("(", "")
                           .Replace(")", "")
                           .Replace(":", "")
                           .Replace(";", "");            
        }

        public static string GetCommaDelimitedStringFromStringCollection(List<string> toList) {
            return GetCommaDelimitedStringFromStringCollection(toList.ToArray());
        }
        public static string GetCommaDelimitedStringFromStringCollection(string[] toArray){
            string sReturn = "";

            foreach (string s in toArray) {
                sReturn = sReturn + ", " + s;
            }
            if (sReturn.Length > 0) {
                sReturn.Substring(2);
            }


            return sReturn;
        }

        public static string StripPath(string tsFileName) {
            return StringUtil.GetFileName(tsFileName);
        }

        public static string StripExt(string sFileName) {
            sFileName = sFileName.Trim();
            string sReturnValue = sFileName;
            int iPos = sFileName.LastIndexOf(".");

            if (iPos > 0) {
                if (iPos > Math.Max(sFileName.LastIndexOf(@"\"), sFileName.LastIndexOf(":"))) {
                    sReturnValue = sFileName.Substring(0, iPos);
                }
            }

            return sReturnValue;
        }

        public static string StripDecimals(string tsValue) {
            if (!string.IsNullOrEmpty(tsValue)) {
                int iPos = tsValue.IndexOf('.');
                if (iPos > 0) {
                    tsValue = tsValue.Substring(0, iPos);
                }
            }
            return tsValue;
        }
        public static string GetFileNameWithoutExtension(string tsFileName) {
            return System.IO.Path.GetFileNameWithoutExtension(tsFileName).ToUpper();
        }
        public static string GetFileName(string tsFileName) {
            return System.IO.Path.GetFileName(tsFileName).ToUpper();
        }
        public static string GetFileExtension(string tsFileName) {
            return System.IO.Path.GetExtension(tsFileName).ToUpper();
        }

        public static string Encrypt(string tsSource) {
            return Encryptor.Encrypt(tsSource);
        }

        public static string Encrypt(string tsSource, int tiReturnLength) {
            return Encryptor.Encrypt(tsSource, tiReturnLength);
        }
        public static string Decrypt(string tsSource) {
            return Encryptor.Decrypt(tsSource);
        }
        public static string NumberToText(int tiNumber) {
            string s = tiNumber.ToString();
            string sRightMost = s.Substring(s.Length - 1);
            bool isTeen = ((tiNumber > 10) && (tiNumber < 20));

            if (isTeen) {
                s += "th";
            } else {
                switch (sRightMost) {
                    case " 1":
                        s += "st";
                        break;
                    case "2":
                        s += "nd";
                        break;
                    case "3":
                        s += "rd";
                        break;
                    default:
                        s += "th";
                        break;
                }
            }
            return s;
        }
        public static TimeSpan GetTimeSpanFromString(string tsTimeText) {
            // This method translates a text string of time (1:00 AM, 1:30 AM etc.) into a TimeSpan object
            // "Open" or "" translates to 0:0:01 AM
            // "Noon" & "Midnight" are supported as well

            TimeSpan oSpan = new TimeSpan(0, 0, 1);

            tsTimeText = tsTimeText.ToUpper().Trim().Replace(" ", "");
            switch (tsTimeText) {
                case "OPEN":
                    // Nothing to do - "Open" translates to 0:0:01 AM
                    break;
                case "":
                    // Nothing to do - "" translates to 0:0:01 AM
                    break;
                case "NOON":
                    oSpan = new TimeSpan(12, 0, 0);
                    break;
                case "MIDNIGHT":
                    oSpan = new TimeSpan(23, 59, 59);
                    break;
                default:
                    int iHours = 0, iMinutes = 0, iSeconds = 0;
                    bool isPM = tsTimeText.Contains("PM");
                    tsTimeText = tsTimeText.Replace("AM", "").Replace("PM", "");

                    string[] sParts = tsTimeText.Split(':');
                    if (sParts.Length > 0) {
                        iHours = Convert.ToInt32(sParts[0]);
                        if ((isPM) && (iHours != 12)) {
                            iHours += 12;
                        }
                    }
                    if (sParts.Length > 1) {
                        iMinutes = Convert.ToInt32(sParts[1]);
                    }
                    if (sParts.Length > 2) {
                        iSeconds = Convert.ToInt32(sParts[2]);
                    }
                    oSpan = new TimeSpan(iHours, iMinutes, iSeconds);
                    break;
            }
            return oSpan;
        }
        public static string GetTimeFromDateTimeAsString(DateTime toDateTime) {
            TimeSpan ts = toDateTime.TimeOfDay;
            string sReturn = "  Open";
            if ((ts.Hours == 0) && (ts.Minutes == 0) && (ts.Seconds == 1)) {
                sReturn = "  Open";

            } else {
                if ((ts.Hours == 12) && (ts.Minutes == 0)) {
                    sReturn = "  Noon";
                } else {
                    if ((ts.Hours == 23) && (ts.Minutes == 59) && (ts.Minutes == 59)) {
                        sReturn = " Midnight";
                    } else {
                        sReturn = toDateTime.ToShortTimeString();
                    }
                }
            }
            return sReturn;
        }
        public static string EncodeNumber2Alpha(int tiNumber) {
            return EncodeNumber2Alpha(Convert.ToInt64(tiNumber));
        }
        public static string EncodeNumber2Alpha(int tiNumber, int tiLength) {
            return EncodeNumber2Alpha(Convert.ToInt64(tiNumber), tiLength);
        }
        public static string EncodeNumber2Alpha(Int64 tiNumber) {
            return EncodeNumber2Alpha(tiNumber, -1);
        }
        public static string EncodeNumber2Alpha(Int64 tiNumber, int tiLength) {
            if (tiNumber < 0) {
                // Flip negative numbers to positive;
                tiNumber = tiNumber * -1;
            }

            string sCandidate = tiNumber.ToString();
            if (tiLength < 1) {
                tiLength = sCandidate.Length;
            }
            return EncodeNumberAsString2Alpha(sCandidate, tiLength);
        }

        private static string EncodeNumberAsString2Alpha(string tsCandidateString, int tiLength) {
            string sReturn = "";
            char sChar;

            while (tsCandidateString.Length < tiLength) {
                tsCandidateString = "0" + tsCandidateString;
            }

            for (int i = 0; i < tsCandidateString.Length; i++) {
                sChar = tsCandidateString[i];
                switch (sChar) {
                    case '0':
                        sReturn += "A";
                        break;
                    case '1':
                        sReturn += "B";
                        break;
                    case '2':
                        sReturn += "C";
                        break;
                    case '3':
                        sReturn += "D";
                        break;
                    case '4':
                        sReturn += "E";
                        break;
                    case '5':
                        sReturn += "F";
                        break;
                    case '6':
                        sReturn += "G";
                        break;
                    case '7':
                        sReturn += "H";
                        break;
                    case '8':
                        sReturn += "I";
                        break;
                    case '9':
                        sReturn += "J";
                        break;
                    default:
                        sReturn += "K";
                        break;
                }
            }
            return sReturn;
        }

        public static int DecodeAlpha2Number(string tsAlphaString) {
            string sReturn = "";
            char sChar;
            tsAlphaString = tsAlphaString.ToUpper();

            for (int i = 0; i < tsAlphaString.Length; i++) {
                sChar = tsAlphaString[i];
                switch (sChar) {
                    case 'A':
                        sReturn += "0";
                        break;
                    case 'B':
                        sReturn += "1";
                        break;
                    case 'C':
                        sReturn += "2";
                        break;
                    case 'D':
                        sReturn += "3";
                        break;
                    case 'E':
                        sReturn += "4";
                        break;
                    case 'F':
                        sReturn += "5";
                        break;
                    case 'G':
                        sReturn += "6";
                        break;
                    case 'H':
                        sReturn += "7";
                        break;
                    case 'I':
                        sReturn += "8";
                        break;
                    case 'J':
                        sReturn += "9";
                        break;
                    default:
                        sReturn += "";
                        break;
                }
            }
            if (sReturn.Length == 0) {
                sReturn = "0";
            }
            return Convert.ToInt32(sReturn);
        }
        public static string ToProperCase(string tsString) {
            return ToProperCase(tsString, false);
        }
        public static string ToProperCase(string tsString, bool tbConvertNullToUnknown) {
            if (tsString == null) {
                if (tbConvertNullToUnknown) {
                    return "Unknown";
                } else {
                    return "";
                }
            } else {
                if (tsString.Length > 0) {
                    StringBuilder sb = new StringBuilder();
                    string s;
                    string[] s2 = tsString.Split(' ');

                    for (int i = 0; i < s2.Length; i++) {
                        if (s2[i].Length > 0) {
                            if (s2[i].Length == 1) {
                                s = " " + s2[i].ToUpper();
                            } else {
                                s = " " + s2[i].Substring(0, 1).ToUpper() + s2[i].Substring(1).ToLower();
                                if ((s.Substring(0, 1).Equals("#")) && (s.Length > 1)) {
                                    if (s.Length > 2) {
                                        s = "#" + s.Substring(1, 1).ToUpper() + s.Substring(2).ToLower();
                                    } else {
                                        s = "#" + s.Substring(1, 1).ToUpper();
                                    }
                                }
                                if (s.Contains("-")) {
                                    s = ToProperCase(s, "-");
                                }
                                if (s.Contains("/")) {
                                    s = ToProperCase(s, "/");
                                }
                            }
                            sb.Append(s);
                        }
                    }
                    return sb.ToString().Substring(1);
                } else {
                    return "";
                }
            }
        }

        public static byte[] ToByteArray(string tsText) {
            return ConvertStringToByteArray(tsText);
        }
        public static string FromByteArray(byte[] toData) {
            return ConvertByteArrayToString(toData);
        }

        //PSAHELP - I added this better version, The old didn't support as wide a spectrum as I needed, and this fixed it.
        public static byte[] ConvertStringToByteArray(string tsText) {
            byte[] bytes = new byte[tsText.Length * sizeof(char)];
            System.Buffer.BlockCopy(tsText.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
            //System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
            //return encoding.GetBytes(tsText);
        }
        public static string ConvertByteArrayToString(byte[] toData) {
            char[] chars = new char[toData.Length / sizeof(char)];
            System.Buffer.BlockCopy(toData, 0, chars, 0, toData.Length);
            return new string(chars);
            //return System.Text.ASCIIEncoding.ASCII.GetString(toData); 
        }

        public static string ConvertDateTimeToSqlDateString(DateTime dtDate) {
            return DateFunction.ToSqlDateString(dtDate);
        }
        public static string ToProperCase(string tsString, string tsToken) {
            StringBuilder sb = new StringBuilder();
            string[] s2 = tsString.Split(tsToken.ToCharArray());

            for (int i = 0; i < s2.Length; i++) {
                if (s2[i].Length > 0) {
                    if (s2[i].Length == 1) {
                        sb.Append(s2[i].Substring(0, 1).ToUpper());
                    } else {
                        sb.Append(s2[i].Substring(0, 1).ToUpper() + s2[i].Substring(1).ToLower());
                    }
                }
                if (i < (s2.Length - 1)) {
                    sb.Append(tsToken);
                }
            }
            return sb.ToString();
        }
        public static bool IsDigit(string tsString) {
            bool b = true;

            for (int i = 0; i < tsString.Length; i++) {
                if ((!char.IsDigit(tsString, i)) && (!tsString[i].Equals('.')) && (!tsString[i].Equals('-')) && (!tsString[i].Equals('E'))) {
                    b = false;
                    break;
                }
            }
            return b;
        }
        public static string Pluralize(string tsValue) {
            tsValue = tsValue.Trim();
            if (tsValue.Length > 0) {
                string sLastCharacter = tsValue.Substring(tsValue.Length - 1, 1).ToLower();

                switch (sLastCharacter) {
                    case "s":
                        tsValue += "es";
                        break;
                    case "y":
                        tsValue = tsValue.Substring(0, tsValue.Length - 1) + "ies";
                        break;
                    default:
                        if ((tsValue.Substring(tsValue.Length - 2, 2).ToLower().Equals("ch")) || (tsValue.Substring(tsValue.Length - 2, 2).ToLower().Equals("sh"))) {
                            tsValue += "es";
                        } else {
                            tsValue += "s";
                        }
                        break;
                }
            }
            return tsValue;
        }

        public static string Space(int tiCount) {
            return "".PadLeft(tiCount, ' ');
        }
        public static int IndexOfAlphaNumericChracter(string tsString) {
            return IndexOfAlphaNumericChracter(tsString, 1);
        }
        public static int IndexOfAlphaNumericChracter(string tsString, int tiPos) {
            int iReturn = -1;
            int iCount = 1;
            for (int i = 0; i < tsString.Length; i++) {
                if(Char.IsLetterOrDigit(tsString[i])){
                    if (iCount == tiPos) {
                        iReturn = i;
                        break;
                    }
                    iCount++;
                }
            }
            return iReturn;
        }
        public static int IndexOfAlphaChracter(string tsString) {
            return IndexOfAlphaChracter(tsString, 1);
        }
        public static int IndexOfAlphaChracter(string tsString, int tiPos) {
            int iReturn = -1;
            int iCount = 1;
            for (int i = 0; i < tsString.Length; i++) {
                if (Char.IsLetter(tsString[i])) {
                    if (iCount == tiPos) {
                        iReturn = i;
                        break;
                    }
                    iCount++;
                }
            }
            return iReturn;
        }
        public static int IndexOfNonAlphaChracter(string tsString) {
            return IndexOfNonAlphaChracter(tsString, 1);
        }
        public static int IndexOfNonAlphaChracter(string tsString, int tiPos) {
            int iReturn = -1;
            int iCount = 1;
            for (int i = 0; i < tsString.Length; i++) {
                if (!Char.IsLetter(tsString[i])) {
                    if (iCount == tiPos) {
                        iReturn = i;
                        break;
                    }
                    iCount++;
                }
            }
            return iReturn;
        }
        public static int IndexOfChar(string tsString, char tcChar) {
            return IndexOfChar(tsString, tcChar, 1);
        }
        public static int IndexOfChar(string tsString, char tcChar, int tiPos) {
            if (tiPos < 1) { throw new Exception("When calling the IndexOfChar() method, the Position Count must be greater than [0]"); }
            int iReturn = -1;
            int iCount = 1;
            for (int i = 0; i < tsString.Length; i++) {
                if (tsString[i].Equals(tcChar)) {
                    if (iCount == tiPos) {
                        iReturn = i;
                        break;
                    }
                    iCount++;
                }
            }
            return iReturn;
        }
        public static int IndexOfDigit(string tsString) {
            return IndexOfDigit(tsString, 1);
        }
        public static int IndexOfDigit(string tsString, int tiPos) {
            if(tiPos < 1) { throw new Exception("When calling the IndexOfDigit() method, the Position Count must be greater than [0]"); }
            int iReturn = -1;
            int iCount = 1;
            for (int i = 0; i < tsString.Length; i++) {
                if (Char.IsDigit(tsString[i])) {
                    if (iCount == tiPos) {
                        iReturn = i;
                        break;
                    }
                    iCount++;
                }
            }
            return iReturn;
        }
        public static int IndexOfNonDigit(string tsString) {
            return IndexOfNonDigit(tsString, 1);
        }
        public static int IndexOfNonDigit(string tsString, int tiPos) {
            if (tiPos < 1) { throw new Exception("When calling the IndexOfNonDigit() method, the Position Count must be greater than [0]"); }
            int iReturn = -1;
            int iCount = 1;
            for (int i = 0; i < tsString.Length; i++) {
                if (!Char.IsDigit(tsString[i])) {
                    if (iCount == tiPos) {
                        iReturn = i;
                        break;
                    }
                    iCount++;
                }
            }
            return iReturn;
        }

    }
}
