using System;
using System.Collections.Generic;
using System.Text;


namespace CommonUtil {
    [Serializable]
    public class XML_Parser {

        private string originalString = "";
        private string currentString = "";
        private string _tagName;
        private string _dataType;
        private string _value;
        private Exception _ex;

        public XML_Parser() {
        }

        public XML_Parser(string tsNewXMLString) {
            LoadXml(ref tsNewXMLString);
        }

        private void SetErrorHandlingTags(string tsTagName, string tsDataType) {
            _tagName = tsTagName;
            _dataType = tsDataType;
            _value = "Unknown";
            _ex = null;
        }

        public void LoadXml(ref string tsNewString) {
            if (tsNewString.Length > 0) {
                originalString = tsNewString;
                currentString = tsNewString;
            }
        }

        public void Reset() {
            currentString = originalString;
        }

        public int GetInteger(string tsTag, ref string tsString) {
            int iReturnValue = GetInteger(tsTag, ref tsString, false);
            return iReturnValue;
        }
        public int GetInteger(string tsTag, ref string tsString, bool tbPreserveXml) {
            SetErrorHandlingTags(tsTag, "integer");
            try {
                int iReturnValue = -1;
                _value = ExtractDataBlockFromXML(ref tsTag, ref tsString, false).Trim();
                if (_value.Length > 0) {
                    iReturnValue = Convert.ToInt32(_value);
                }
                return iReturnValue;
            } catch (Exception ex) {
                XmlParserException oEx = new XmlParserException(_tagName, _dataType, _value, ex);
                throw oEx;
            }
        }
        public Int16 GetInt16(string tsTag, ref string tsString) {
            Int16 iReturnValue = GetInt16(tsTag, ref tsString, false);
            return iReturnValue;
        }
        public Int16 GetInt16(string tsTag, ref string tsString, bool tbPreserveXml) {
            Int16 iReturnValue = -1;
            string sStringValue = ExtractDataBlockFromXML(ref tsTag, ref tsString, false).Trim();
            if (sStringValue.Length > 0) {
                iReturnValue = Convert.ToInt16(sStringValue);
            }
            return iReturnValue;
        }
        public Int32 GetInt32(string tsTag, ref string tsString) {
            Int32 iReturnValue = GetInt32(tsTag, ref tsString, false);
            return iReturnValue;
        }
        public Int32 GetInt32(string tsTag, ref string tsString, bool tbPreserveXml) {
            Int32 iReturnValue = -1;
            string sStringValue = ExtractDataBlockFromXML(ref tsTag, ref tsString, false).Trim();
            if (sStringValue.Length > 0) {
                iReturnValue = Convert.ToInt32(sStringValue);
            }
            return iReturnValue;
        }
        public Int64 GetInt64(string tsTag, ref string tsString) {
            Int64 iReturnValue = GetInt64(tsTag, ref tsString, false);
            return iReturnValue;
        }
        public Int64 GetInt64(string tsTag, ref string tsString, bool tbPreserveXml) {
            Int64 iReturnValue = -1;
            string sStringValue = ExtractDataBlockFromXML(ref tsTag, ref tsString, false).Trim();
            if (sStringValue.Length > 0) {
                iReturnValue = Convert.ToInt64(sStringValue);
            }
            return iReturnValue;
        }

        public DateTime GetDate(string tsTag, ref string tsString) {
            return DateFunction.GetDateFromShortDateString(GetString(tsTag, ref tsString, false));
        }
        public DateTime GetDateTime(string tsTag, ref string tsString) {
            return DateFunction.GetDateTimeFromDateTimeString(GetString(tsTag, ref tsString, false));
        }
        public bool GetBoolean(string tsTag, ref string tsString) {
            bool bReturnValue = GetBoolean(tsTag, ref tsString, false);
            return bReturnValue;
        }

        public bool GetBoolean(string tsTag, ref string tsString, bool tbPreserveXml) {
            bool bReturnValue = false;
            string sStringValue = ExtractDataBlockFromXML(ref tsTag, ref tsString, tbPreserveXml).Trim();
            if (sStringValue.Length > 0) {
                string s = sStringValue.Substring(0, 1).ToUpper();
                bReturnValue = ((s.Equals("Y")) || (s.Equals("T")));
            }
            return bReturnValue;
        }
        public byte[] GetByteArray(string tsTag, ref string tsString) {
            return GetByteArray(tsTag, ref tsString, false);
        }
        public byte[] GetByteArray(string tsTag, ref string tsString, bool tbPreserveXml) {
            return new byte[] { };
        }
        public decimal GetDecimal(string tsTag, ref string tsString) {
            decimal iReturnValue = GetDecimal(tsTag, ref tsString, false);
            return iReturnValue;
        }

        public decimal GetDecimal(string tsTag, ref string tsString, bool tbPreserveXml) {
            decimal iReturnValue = 0;
            string sStringValue = ExtractDataBlockFromXML(ref tsTag, ref tsString, tbPreserveXml).Trim();
            if (sStringValue.Length > 0) {
                iReturnValue = Convert.ToDecimal(sStringValue);
            }
            return iReturnValue;
        }

        public double GetDouble(string tsTag, ref string tsString) {
            double iReturnValue = GetDouble(tsTag, ref tsString, false);
            return iReturnValue;
        }

        public double GetDouble(string tsTag, ref string tsString, bool tbPreserveXml) {
            double iReturnValue = 0;
            string sStringValue = ExtractDataBlockFromXML(ref tsTag, ref tsString, tbPreserveXml).Trim();
            if (sStringValue.Length > 0) {
                iReturnValue = Convert.ToDouble(sStringValue);
            }
            return iReturnValue;
        }
        public float GetFloat(string tsTag, ref string tsString) {
            return GetFloat(tsTag, ref tsString, false);
        }
        public float GetFloat(string tsTag, ref string tsString, bool tbPreserveXml) {
            float fReturnValue = 0;
            string sStringValue = ExtractDataBlockFromXML(ref tsTag, ref tsString, tbPreserveXml).Trim();
            if (sStringValue.Length > 0) {
                fReturnValue = Convert.ToSingle(sStringValue);
            }
            return fReturnValue;
        }

        public Guid GetGuid(string tsTag, ref string tsString) {
            return GetGuid(tsTag, ref tsString, false);
        }

        public Guid GetGuid(string tsTag, ref string tsString, bool tbPreserveXml) {
            Guid oReturn = Guid.Empty;
            string sGuid = GetString(tsTag, ref tsString, tbPreserveXml).Trim();
            if (sGuid.Length > 0) {
                oReturn = new Guid(sGuid);
            }
            return oReturn;
        }

        #region GetString

        public string GetString(string tsTag, ref string tsString) {
            return GetString(tsTag, ref tsString, false, true);
        }

        public string GetString(string tsTag, ref string tsString, bool tbPreserveXml) {
            return GetString(tsTag, ref tsString, tbPreserveXml, true);
        }
        public string GetString(string tsTag, ref string tsString, bool tbPreserveXml, bool tbTrim) {
            string sReturn = "";
            try {
                sReturn = ExtractDataBlockFromXML(ref tsTag, ref tsString, tbPreserveXml);
                if (tbTrim) {
                    sReturn = sReturn.Trim();
                }
            } catch (Exception ex) {
                throw new Exception(ex.Message + "\r\n\r\nXML Tag = " + tsTag, ex);
            }
            return sReturn;
        }
        #endregion (GetString)

        public object GetEnum(string tsTag, ref string tsString, Enum teDefaultValue) {
            return GetEnum(tsTag, ref tsString, teDefaultValue, false);
        }
        public object GetEnum(string tsTag, ref string tsString, Enum teDefaultValue, bool tbPreserveXml) {
            object oReturn = null;
            string sStringValue = ExtractDataBlockFromXML(ref tsTag, ref tsString, false).Trim();
            if (sStringValue.Length > 0) {
                try {
                    oReturn = Enum.Parse(teDefaultValue.GetType(), sStringValue);

                } catch {
                    // nothing to do - in the event of an error, the return will be the default
                }
            }
            if (oReturn == null) {
                oReturn = teDefaultValue;
            }
            return oReturn;
        }

        private void GetLocation(ref string tsTag, ref string tsString, ref int tiStartPos, ref int tiEndPos, ref int tiStartPos2, ref int tiEndPos2) {
            tsTag = tsTag.ToUpper();
            string startTag = "<" + tsTag + ">";
            string endTag = "</" + tsTag + ">";

            string comparisonString = tsString.ToUpper();
            // Get start and end tags
            tiStartPos = comparisonString.IndexOf(startTag);
            tiEndPos = comparisonString.IndexOf(endTag);
            tiStartPos2 = tiStartPos + startTag.Length;
            tiEndPos2 = tiEndPos + endTag.Length;
        }

        public void ReplaceTagValuePair(ref string tsXml, string tsTag, string tsNewTagAndValue) {
            // This Method replaces the Tag and the Value associated
            int startPos = -1, startPos2 = -1, endPos = -1, endPos2 = -1;

            GetLocation(ref tsTag, ref tsXml, ref startPos, ref endPos, ref startPos2, ref endPos2);

            if (endPos < startPos) {
                // ERROR:  If endPos = 0 & startPos > 0 - there is an error in th XML- there should be an endPos
                Exception ex = new Exception("A request has been issued to the XML Parser to INSERT data inside the <" + tsTag + "> tag.  However, the data string submitted does not have an ending matching end tag.");
                throw (ex);
            } else {
                if ((startPos > -1) && (endPos2 > -1)) {
                    // Get the return block from the XML string
                    tsXml = tsXml.Substring(0, startPos) + tsNewTagAndValue + tsXml.Substring(endPos2);
                }
            }
        }
        public void ReplaceValue(string tsExistingTag, string tsNewValue, ref string tsXml) {
            ReplaceValue(tsExistingTag, tsNewValue, ref tsXml, false);
        }
        public void ReplaceValue(string tsExistingTag, string tsNewValue, ref string tsXml, bool tbAppendValueToEndIfNoTagFound) {
            // This Method Inserts the Value inside the existing Tag
            int startPos = -1, startPos2 = -1, endPos = -1, endPos2 = -1;

            GetLocation(ref tsExistingTag, ref tsXml, ref startPos, ref endPos, ref startPos2, ref endPos2);

            if (endPos < startPos) {
                // ERROR:  If endPos = 0 & startPos > 0 - there is an error in th XML- there should be an endPos
                Exception ex = new Exception("A request has been issued to the XML Parser to INSERT data inside the <" + tsExistingTag + "> tag.  However, the data string submitted does not have an ending matching end tag.");
                throw (ex);
            } else {
                if ((startPos2 > -1) && (endPos > -1)) {
                    // Get the return block from the XML string
                    tsXml = tsXml.Substring(0, startPos2) + tsNewValue + tsXml.Substring(endPos);
                } else {
                    if (tbAppendValueToEndIfNoTagFound) {
                        tsXml += "<" + tsExistingTag + ">" + tsNewValue + "</" + tsExistingTag + ">";
                    }
                }
            }
        }
        private string ExtractDataBlockFromXML(ref string tsTag, ref string tsXml, bool tbPreserveXml) {
            int startPos = -1, startPos2 = -1, endPos = -1, endPos2 = -1;
            string returnValue = "";

            GetLocation(ref tsTag, ref tsXml, ref startPos, ref endPos, ref startPos2, ref endPos2);

            if (endPos < startPos) {
                // ERROR:  If endPos = 0 & startPos > 0 - there is an error in th XML- there should be an endPos
                Exception ex = new Exception("A request has been issued to the XML Parser to retrieve data inside the <" + tsTag + "> tag.  However, the data string submitted does not have an ending matching end tag.");
                throw (ex);
            } else {
                // Get inside content start and end positions
                if ((startPos > -1) && (endPos2 > -1)) {
                    // Get the return block from the XML string
                    returnValue = tsXml.Substring(startPos2, endPos - startPos2);

                    // Now remove the block from the original string
                    if (!tbPreserveXml) {
                        if (startPos == 0) {
                            tsXml = tsXml.Substring(endPos2);
                        } else {
                            tsXml = tsXml.Substring(0, startPos) + tsXml.Substring(endPos2);
                        }
                    }
                }
            }
            return returnValue;
        }

        public static string Format_XML(string tsXML) {
            XML_Parser oParser = new XML_Parser();
            return oParser.FormatXML(tsXML);
        }
        public string FormatXML(string tsXML) {
            int iTabCount = 0;
            //			int iStartPos = 0;
            string ReturnString = "";
            char nextChar;

            for (int i = 0; i < tsXML.Length; i++) {
                nextChar = (char)tsXML[i];
                if (nextChar == '<') {
                    i = StartTag(i, ref iTabCount, ref ReturnString, ref tsXML);
                }
            }
            return ReturnString;
        }

        private int StartTag(int tiPos, ref int tiTabCount, ref string tsOutput, ref string tsInput) {
            // This method works with the FormatXML() method
            int iReturn = tiPos;
            int iEndPos;
            string EndOfLine = "\r\n";

            if ((tsInput.Length > tiPos + 2) && (tsInput.Substring(tiPos + 1, 1) == "/")) {
                // This is a "Closing Tag that followed a closing tag - Decrement the tab count	
                iEndPos = tsInput.IndexOf(">", tiPos);
                string newOutput = tsInput.Substring(tiPos, (iEndPos - tiPos) + 1);
                tsOutput += newOutput + EndOfLine;
                if ((tsInput.Length > iEndPos + 2) && (tsInput.Substring(iEndPos + 2, 1) == "/")) {
                    tiTabCount--;
                }
                tsOutput += GetTabs(tiTabCount);
            } else {
                iEndPos = tsInput.IndexOf("<", tiPos + 1);
                if (tsInput.Length > iEndPos + 2) {
                    if (tsInput.Substring(iEndPos + 1, 1) == "/") {
                        // This is a closing tag
                        iEndPos = tsInput.IndexOf(">", iEndPos);
                        iReturn = iEndPos;
                        string newOutput = tsInput.Substring(tiPos, (iEndPos - tiPos) + 1);
                        tsOutput += newOutput + EndOfLine;
                        if ((tsInput.Length > iEndPos + 2) && (tsInput.Substring(iEndPos + 2, 1) == "/")) {
                            tiTabCount--;
                        }
                        tsOutput += GetTabs(tiTabCount);
                    } else {
                        // This is a new Tag
                        tiTabCount++;
                        tsOutput += tsInput.Substring(tiPos, iEndPos - tiPos) + EndOfLine + GetTabs(tiTabCount);
                        iReturn = iEndPos - 1;
                    }

                }
            }
            return iReturn;
        }

        public void RemoveTabsAndLineFeeds(ref string tsXML) {
            tsXML = StringUtil.StringTransform(StringUtil.StringTransform(tsXML, "\r\n"), "\t");
        }

        private string GetTabs(int tiTabCount) {
            // This method works with the FormatXML() and the StartTag() method
            string sReturn = "";

            for (int i = 0; i < tiTabCount; i++) {
                sReturn += (char)9;
            }
            return sReturn;
        }
    }
}
