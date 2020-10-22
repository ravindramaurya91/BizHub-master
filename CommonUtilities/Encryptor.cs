using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualBasic;

namespace CommonUtil {
    public enum eEncryptionScheme { SHA256, CWS, Base64 };

    public class Encryptor {
        public const int CWS_ENCRYPTOR_KEY = 71;
        public static string AUTHENTICATION_SEPARATOR = ((char)0).ToString();
        public static string EMPTY_VALUE = "q^K~";

        #region Encrypt
        public static string Encrypt(string tsSource) {
            return Encrypt(tsSource, tsSource.Length + 8);
        }
        public static string Encrypt(string tsSource, eEncryptionScheme teEncryptionScheme) {
            return Encrypt(tsSource, tsSource.Length + 8, teEncryptionScheme);
        }

        public static string Encrypt(string tsSource, int tiReturnLength) {
            return Encrypt(tsSource, tsSource.Length + 8, eEncryptionScheme.CWS);
        }
        public static string Encrypt(string tsSource, int tiReturnLength, eEncryptionScheme teEncryptionScheme) {
            string sReturn = "";
            char cEncryptionSchemeMarker;
            if (tsSource.Equals("")) {
                tsSource = EMPTY_VALUE;
            }

            if (teEncryptionScheme == eEncryptionScheme.SHA256) {
                sReturn = EncryptUsingSHA256_OneWayOnly(tsSource);
            } else {

                if (teEncryptionScheme == eEncryptionScheme.Base64) {
                    cEncryptionSchemeMarker = ((char)2);
                } else {
                    cEncryptionSchemeMarker = ((char)3);
                }

                int iSourceLength = tsSource.Length;
                int iTargetLength = Math.Max(tiReturnLength, iSourceLength + 8);
                int iDynamicKey = Math.Min(iSourceLength + CWS_ENCRYPTOR_KEY, 250);
                string sGarbage = @"~aee#$23A-.!DSD*@#&@sdopeep23\sd\~@# #ddfadf}{zxasdf-=#_{lsaDF_#EA:Sd3,as@#_)lp-as-=@_3o;lWDL:d";
                string sWorkingString = tsSource + sGarbage;

                // CHR(128) = Delimiter which marks the first character after the Original length number
                // CHR(129) = Means that the return type for Decryptor is Character
       
                sReturn = cEncryptionSchemeMarker + ((char)iDynamicKey).ToString() + ((char)iSourceLength).ToString() +  ((char)128).ToString() + ((char)129).ToString();
                
                for (int i = 0; i < iTargetLength; i++) {
                    sReturn += ((char)GetCharValue(Strings.AscW(sWorkingString[i]), iDynamicKey));
                }

                if (teEncryptionScheme == eEncryptionScheme.Base64) {
                    sReturn = sReturn.Substring(0,1) + System.Convert.ToBase64String(Encoding.UTF8.GetBytes(sReturn.Substring(1)));
                }
            }
            return sReturn;
        }

        private static string EncryptUsingSHA256_OneWayOnly(string tsData) {
            UnicodeEncoding oUnicode = new UnicodeEncoding();
            byte[] oDataAsByteArray = oUnicode.GetBytes(tsData);
            System.Security.Cryptography.SHA256Managed oCrypto = new System.Security.Cryptography.SHA256Managed();
            byte[] bHash = oCrypto.ComputeHash(oDataAsByteArray);
            return Convert.ToBase64String(bHash);
        }

        private static string EncryptUsingSHA256_OneWayOnly_Method2(string tsData) {
            System.Security.Cryptography.SHA256 sha256 = new System.Security.Cryptography.SHA256Managed();
            byte[] sha256Bytes = System.Text.Encoding.Default.GetBytes(tsData);
            byte[] cryString = sha256.ComputeHash(sha256Bytes);
            string sha256Str = string.Empty;
            for (int i = 0; i < cryString.Length; i++) {
                sha256Str += cryString[i].ToString("X");
            }
            return sha256Str;
        }
        #endregion (Encrypt)

        #region Decrypt
        public static string Decrypt(string tsSource) {
            string sReturn = "";

            if (tsSource.Length > 0) {
                byte[] orig;
            

                int iStartingPos = 4;
                int iEncryptionScheme = Strings.AscW(tsSource[0]);
                tsSource = tsSource.Substring(1);

                if (iEncryptionScheme == 2) {
                    // This encryption used Base64  - reverse it here
                    orig = System.Convert.FromBase64String(tsSource);
                    tsSource = Encoding.UTF8.GetString(orig);
                }

                int iDynamicKey = Strings.AscW(tsSource[0]);
                int iTargetLength = Strings.AscW(tsSource[1]);
                int iDelimiter = Strings.AscW(tsSource[2]);  // chr(128) == The first cgharacter after the length indicator
                int iReturnType = Strings.AscW(tsSource[3]);  // chr(129) == String  (No other types supported yet)

                for (int i = iStartingPos; i < iTargetLength + iStartingPos; i++) {
                    sReturn += ((char)ReverseCharValue(Strings.AscW(tsSource[i]), iDynamicKey));
                }

                if (sReturn.Equals(EMPTY_VALUE)) {
                    sReturn = "";
                }
            }
            return sReturn;
        }
        #endregion (Decrypt)

        #region Authentication Strings
        public static string EncryptAuthenticationString(string tsLoginName, string tsPassword) {
            return EncryptAuthenticationString("", tsLoginName, tsPassword, eEncryptionScheme.CWS);
        }
        public static string EncryptAuthenticationString(string tsLoginName, string tsPassword, eEncryptionScheme teEncryptionScheme) {
            return EncryptAuthenticationString("", tsLoginName, tsPassword, teEncryptionScheme);
        }

        public static string EncryptAuthenticationString(string tsSalt, string tsLoginName, string tsPassword, eEncryptionScheme teEncryptionScheme) {
            string sAuthenticationString = "";

            if (teEncryptionScheme == eEncryptionScheme.SHA256) {
                sAuthenticationString = Encryptor.EncryptUsingSHA256_OneWayOnly(tsSalt + tsLoginName + tsPassword);
            } else {
                string sEncryptedSalt = Encrypt(tsSalt, teEncryptionScheme);
                string sEncryptedUserLogin = Encrypt(tsLoginName.Trim(), teEncryptionScheme);
                string sEncryptedPassword = Encrypt(tsPassword.Trim(), teEncryptionScheme);

                //if (teEncryptionScheme == eEncryptionScheme.Base64) {
                //    sEncryptedSalt = System.Convert.ToBase64String(Encoding.UTF8.GetBytes(sEncryptedSalt));
                //    sEncryptedUserLogin = System.Convert.ToBase64String(Encoding.UTF8.GetBytes(sEncryptedUserLogin));
                //    sEncryptedPassword = System.Convert.ToBase64String(Encoding.UTF8.GetBytes(sEncryptedPassword));
                //}

                sAuthenticationString = sEncryptedSalt + AUTHENTICATION_SEPARATOR + sEncryptedUserLogin + AUTHENTICATION_SEPARATOR + sEncryptedPassword;
            }

            return sAuthenticationString;
        }

        public static void DecryptAuthenticationString(string tsEncryptedPassword, ref string tsLoginName, ref string tsPassword) {
            string sSalt = "";
            DecryptAuthenticationString(tsEncryptedPassword, ref sSalt, ref tsLoginName, ref tsPassword);
        }
        public static void DecryptAuthenticationString(string tsEncryptedData, ref string tsSalt, ref string tsLoginName, ref string tsPassword) {
            string sLoginData = tsEncryptedData;
            int iPos = sLoginData.IndexOf(AUTHENTICATION_SEPARATOR);

            if (iPos > -1) {
                tsSalt = sLoginData.Substring(0, iPos);

                sLoginData = sLoginData.Substring(iPos + 1);
                iPos = sLoginData.IndexOf(AUTHENTICATION_SEPARATOR);

                if (iPos > -1) {
                    tsLoginName = sLoginData.Substring(0, iPos);
                    tsPassword = sLoginData.Substring(iPos + 1);
                }
            }

            tsSalt = Decrypt(tsSalt);
            tsLoginName = Decrypt(tsLoginName);
            tsPassword = Decrypt(tsPassword);

        }
        #endregion (Authentication Strings)

        public static int GetCharValue(int tiDataValue, int tiKeyValue) {
            int i = tiDataValue + tiKeyValue;
            if (i > 255) {
                i -= 255;
            }
            return i;
        }
        public static int ReverseCharValue(int tiDataValue, int tiKeyValue) {
            int i = tiDataValue - tiKeyValue;
            if (i < 0) {
                i += 255;
            }
            return i;
        }


    }
}