using System;
using System.IO;
using System.Web;
//using System.Web.Script.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Diagnostics;
using System.Threading;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using System.Reflection.Metadata.Ecma335;

using TheArtOfDev.HtmlRenderer.Core;
//using TheArtOfDev.HtmlRenderer.PdfSharp;

namespace CommonUtil {
    public class FSTools {

        #region Fields
        private static volatile FSTools _fsTools = null;
        private static object _syncRoot = new Object(); //for multi thread protection
        #endregion (Fields)

        #region Constructor
        static FSTools() {

            #region Instantiate Associated Static Classes
            #endregion (Instantiate Aassociated static Classes)

        }

        private static FSTools GetFSTools() {
            // Return an object reference to GlobalUtilities
            if (_fsTools == null) {
                lock (_syncRoot) {
                    _fsTools = new FSTools();
                }
            }
            return _fsTools;
        }
        #endregion (Constructor)

        #region File I/O and Directory Management

        public static DateTime GetLastModifiedDate(string tsFileName) {
            DateTime dtReturnValue = new DateTime();
            //FileInfo oFileInfo;

            if (!File.Exists(tsFileName)) {
                throw new Exception("A call has been made to GlobalTools.GetLastModifiedDate()\r\n\r\nERROR: File Does Not Exists\r\n\r\nFile:  " + tsFileName + " - File Does Not Exists");
            } else {
                dtReturnValue = new FileInfo(tsFileName).LastWriteTime;
            }

            return dtReturnValue;
        }

        public static DateTime GetFileCreationTime(string tsFileName) {
            DateTime dt = DateTime.UtcNow;
            try {
                System.IO.FileInfo fi = new System.IO.FileInfo(tsFileName);
                dt = fi.CreationTime;
            } catch {
            }
            return dt;
        }

        public static bool FileIsSeenOnly(string tsFullFileName) {
            bool bReturn = false;
            if (File.Exists(tsFullFileName)) {
                FileAttributes attributes = File.GetAttributes(tsFullFileName);
                byte myByte1 = (byte)System.IO.FileAttributes.ReadOnly;

                bReturn = (((byte)attributes) & myByte1) > 0;
            }
            return bReturn;
        }

        public void OpenFileAndRetrieveContents(string tsFileName, ref string tsContents) {
            string sError = "";
            OpenFileAndRetrieveContents(tsFileName, ref tsContents, ref sError, false);
        }
        public void OpenFileAndRetrieveContents(string tsFileName, ref string tsContents, ref string tsErrorCondition) {
            OpenFileAndRetrieveContents(tsFileName, ref tsContents, ref tsErrorCondition, false);
        }
        public void OpenFileAndRetrieveContents(string tsFileName, ref string tsContents, bool tbShowErrorMessageDialog) {
            string sError = "";
            OpenFileAndRetrieveContents(tsFileName, ref tsContents, ref sError, tbShowErrorMessageDialog);
        }
        public void OpenFileAndRetrieveContents(string tsFileName, ref string tsContents, ref string tsErrorCondition, bool tbShowErrorMessageDialog) {
            tsErrorCondition = "";
            StreamReader sr = null;

            if (tsFileName.Length == 0) {
                tsErrorCondition = "No File Name Given";
            } else {
                if (!File.Exists(tsFileName)) {
                    tsErrorCondition = "File Does Not Exist.\r\n[" + tsFileName + "]";
                } else {
                    // Open requested file & read the contents into the [tsContents] variable
                    try {
                        sr = new StreamReader(tsFileName);
                        tsContents = sr.ReadToEnd();
                        sr.Close();
                        tsErrorCondition = "";
                    } catch (Exception ex) {
                        try {
                            tsErrorCondition = ex.Message;
                            // If file failed it was probably set as "Read Only"
                            FileAttributes oAttributes = File.GetAttributes(tsFileName);
                            if (oAttributes == FileAttributes.ReadOnly) {
                                try {
                                    File.SetAttributes(tsFileName, FileAttributes.Normal);
                                    Thread.Sleep(250);
                                    sr = new StreamReader(tsFileName);
                                    tsContents = sr.ReadToEnd();
                                    sr.Close();
                                    tsErrorCondition = "";
                                } catch {
                                    try {
                                        Thread.Sleep(250);
                                        sr = new StreamReader(tsFileName);
                                        tsContents = sr.ReadToEnd();
                                        sr.Close();
                                        tsErrorCondition = "";
                                    } catch {
                                        try {
                                            Thread.Sleep(500);
                                            sr = new StreamReader(tsFileName);
                                            tsContents = sr.ReadToEnd();
                                            sr.Close();
                                            tsErrorCondition = "";
                                        } catch (Exception ex3) {
                                            tsContents = "";
                                            oAttributes = File.GetAttributes(tsFileName);
                                            throw new Exception("Unable to read file. " + ex3.Message);
                                        }
                                    }
                                    return;
                                }
                            }

                        } catch {
                            tsContents = "";
                        }
                    }
                }
            }
            if (sr != null) {
                sr.Close();
            }

            sr = null;
        }

        public void MoveFile(string tsSourceFile, string tsDestinationFile) {
            if (File.Exists(tsSourceFile)) {
                File.Copy(tsSourceFile, tsDestinationFile, true);

                try {
                    File.Delete(tsSourceFile);
                } catch {
                    //this.PostApplicationAlert("ERROR: Unable to delete file [" + tsSourceFile + "]  (global.MoveFile()");
                }
            }
        }

        public static void WriteFile(string tsFileName, string tsContents) {
            WriteFile(tsFileName, ref tsContents);
        }
        public static void WriteFile(string tsFileName, ref string tsContents) {
            string sDirectory = StringUtil.GetPathFromFileName(tsFileName);
            if (!Directory.Exists(sDirectory)) {
                Directory.CreateDirectory(sDirectory);
            }

            FileStream fs = new FileStream(tsFileName, FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);
            sw.Write(tsContents);
            sw.Close();
            fs.Close();
        }


        public static void SaveStreamToFile(String path, Stream stream) {
            var fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
            stream.CopyTo(fileStream);
            fileStream.Dispose();
        }

        public static byte[] ReadFileToByteAray(string tsFileName) {
            byte[] oReturnValue = null;

            if (tsFileName.Length == 0) {
                throw new Exception("No File Name Given");
            } else {
                if (!File.Exists(tsFileName)) {
                    throw new Exception("File Does Not Exist.\r\n[" + tsFileName + "]");
                } else {
                    //Initialize byte array with a null value. 

                    //Use FileInfo object to get file size. 
                    FileInfo fInfo = new FileInfo(tsFileName);
                    long numBytes = fInfo.Length;

                    //Open FileStream to read file 
                    try {
                        FileStream fStream = new FileStream(tsFileName, FileMode.Open, FileAccess.Read);

                        //Use BinaryReader to read file stream into byte array. 
                        BinaryReader br = new BinaryReader(fStream);

                        //When you use BinaryReader, you need to supply number of bytes to read from file. 
                        //In this case we want to read entire file. So supplying total number of bytes. 
                        oReturnValue = br.ReadBytes((int)numBytes);
                    } catch (Exception ex) {
                        throw ex;
                    }
                }
            }
            return oReturnValue;
        }
        public static string ConvertListToDelimitedString(List<Int64> toList) {
            // Creates a Coma delimited list of numbers from a List of Int64
            return String.Join(",", toList.ToArray());
        }
        public static string ConvertListToDelimitedString(List<string> toList) {
            // Creates a Coma delimited list of numbers from a List of strings
            return String.Join(",", toList.ToArray());
        }
        public static string ConvertListToDelimitedString(List<string> toList, string tsDelimiter) {
            // Creates a Coma delimited list of numbers from a List of strings
            return String.Join(tsDelimiter, toList.ToArray());
        }
        public static string ConvertListToDelimitedStringWithQuotationMarks(List<string> toList) {
            // Creates a Coma delimited list of numbers from a List of strings
            return "'" + String.Join("','", toList.ToArray()) + "'";
        }
        public static List<T> ConvertDelimitedStringToList<T>(string tsDelimitedString, char tcDelimitor) {
            return ConvertDelimitedStringToList<T>(tsDelimitedString, tcDelimitor.ToString());
        }
        public static List<T> ConvertDelimitedStringToList<T>(string tsDelimitedString, string tsDelimitor) {
            List<T> oReturn = new List<T>();

            string[] oStrings = (!string.IsNullOrEmpty(tsDelimitedString)) ? tsDelimitedString.Split(tsDelimitor) : new string[]{ };
            foreach (string s in oStrings) {
                if (!string.IsNullOrEmpty(s)) {
                    oReturn.Add((T)Convert.ChangeType(s.Trim(), typeof(T)));
                }
            }
            return oReturn;
        }
        public static List<Int64> ConvertListToInt64(string tsList) {
            // Converts a Coma delimited list of numbers into a List of Int64
            List<Int64> oReturn = new List<long>();

            if (!string.IsNullOrEmpty(tsList)){
                string[] oStrings = tsList.Split(',');
                foreach (string s in oStrings) {
                    oReturn.Add(Convert.ToInt64(s));
                }
            }
            return oReturn;
        }


        public static MemoryStream ConvertByteArrayToMemoryStream(byte[] toByteArray) {
            return new MemoryStream(toByteArray);
        }
        public static MemoryStream ConvertStreamToMemoryStream(Stream toSourceStream) {
            MemoryStream oReturn = new MemoryStream();
            toSourceStream.CopyTo(oReturn);
            return oReturn;
        }
        public static byte[] ConvertMemoryStreamToByteArray(MemoryStream toMS) {
            return toMS.ToArray();
        }
        public static byte[] ConvertStreamToByteArray(Stream toStream) {
            return ConvertStreamToMemoryStream(toStream).ToArray();
        }
        public static Object ConvertStreamToObject(Stream toStream) {
            // Construct a binary formatter
            BinaryFormatter formatter = new BinaryFormatter();
            return (Object)formatter.Deserialize(toStream); ;
        }
        public static byte[] ConvertObjectToByteArray(object toObject) {
            byte[] oReturn = null;
            BinaryFormatter bf = new BinaryFormatter();
            using (var ms = new MemoryStream()) {
                bf.Serialize(ms, toObject);
                oReturn = ms.ToArray();
            }
            return oReturn;
        }
        public static object ConvertByteArrayToObject(byte[] toByteArray) {
            object oReturn = null;
            try {
                if (toByteArray != null) {
                    BinaryFormatter bf = new BinaryFormatter();
                    using (MemoryStream ms = new MemoryStream(toByteArray)) {
                        oReturn = bf.Deserialize(ms);
                    }
                }
            } catch (Exception ex) {
                // Error
                Console.WriteLine("Exception caught in process: {0}", ex.ToString());
                throw ex;
            }

            return oReturn;
        }

        public static T ConvertByteArrayToObject<T>(byte[] toByteArray) {
            T oReturn = default(T);

            object obj = ConvertByteArrayToObject(toByteArray);
            if(obj != null) {
                oReturn = (T)obj;
            }

            return oReturn;
        }

        public static Tout CopyValue<Tin, Tout>(Tin from, Tout toPrototype) {
            Type underlyingT = Nullable.GetUnderlyingType(typeof(Tout));
            if (underlyingT == null) {
                return (Tout)Convert.ChangeType(from, typeof(Tout));
            } else {
                return (Tout)Convert.ChangeType(from, underlyingT);
            }
        }

        public static object ConvertValueByType(Type toType, object toValue) {
            object oReturn = null;
            string sType = toType.ToString().Replace("System.", "");

            if (toValue != null) {
                switch (sType) {
                    case "String":
                        oReturn = toValue.ToString();
                        break;
                    case "Nullable`1[Decimal]":
                    case "Decimal":
                        oReturn = Convert.ToDecimal(toValue);
                        break;
                    case "Nullable`1[Int16]":
                    case "Int16":
                        oReturn = Convert.ToInt16(toValue);
                        break;
                    case "Nullable`1[Int32]":
                    case "Int32":
                    case "int":
                        oReturn = Convert.ToInt32(toValue);
                        break;
                    case "Nullable`1[Int64]":
                    case "Int64":
                    case "long":
                        oReturn = Convert.ToInt64(toValue);
                        break;
                    case "Nullable`1[Double]":
                    case "Double":
                        oReturn = Convert.ToDouble(toValue);
                        break;
                    case "Nullable`1[Boolean]":
                    case "Boolean":
                        oReturn = Convert.ToBoolean(toValue);
                        break;
                    case "Nullable`1[DateTime]":
                    case "DateTime":
                        oReturn = Convert.ToDateTime(toValue);
                        break;
                    case "Nullable`1[Byte]":
                    case "Byte":
                        oReturn = Convert.ToByte(toValue);
                        break;
                    case "Nullable`1[Char]":
                    case "Char":
                        oReturn = Convert.ToChar(toValue);
                        break;
                    case "Nullable`1[SByte]":
                    case "SByte":
                        oReturn = Convert.ToSByte(toValue);
                        break;
                    default:
                        oReturn = null;
                        break;
                }
            }
            return oReturn;
        }
        public static bool WriteByteArrayToFile(byte[] toData, string tsFileName) {
            bool response = false;

            try {
                FileStream fs = new FileStream(tsFileName, FileMode.Create, FileAccess.ReadWrite);
                BinaryWriter bw = new BinaryWriter(fs);
                bw.Write(toData);
                bw.Close();
                response = true;
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }

            return response;
        }

        #region Serialization
        public static void Serialize(string tsFileName, object toObject) {
            string sDirectory = StringUtil.GetPathFromFileName(tsFileName);


            if ((sDirectory.Length > 0) && (!Directory.Exists(sDirectory))) {
                Directory.CreateDirectory(sDirectory);
            }

            FileStream fs = new FileStream(tsFileName, FileMode.Create);
            // Construct a BinaryFormatter and use it to serialize the data to the stream.
            BinaryFormatter formatter = new BinaryFormatter();
            try {

                formatter.Serialize(fs, toObject);
            } catch (SerializationException ex) {
                throw ex;
            } finally {
                fs.Close();
            }
        }
        public static object Deserialize(string tsFileName) {
            object oReturnValue = null;
            string sDirectory = StringUtil.GetPathFromFileName(tsFileName);
            if (!Directory.Exists(sDirectory)) {
                Console.WriteLine("Failed to deserialize. Reason: Directory does not exist - " + sDirectory);
                // ERROR MESSAGE
            } else {
                if (!File.Exists(tsFileName)) {
                    Console.WriteLine("Failed to deserialize. Reason: File does not exist - " + tsFileName);
                    // ERROR MESSAGE
                } else {
                    FileStream fs = new FileStream(tsFileName, FileMode.Open);
                    try {
                        BinaryFormatter formatter = new BinaryFormatter();

                        // Deserialize the class from the file and 
                        // assign the reference to the local variable.
                        oReturnValue = formatter.Deserialize(fs);
                    } catch (SerializationException e) {
                        Console.WriteLine("Failed to deserialize. Reason: " + e.Message);
                        // ERROR MESSAGE
                        throw new Exception("Failed to deserialize. Reason: " + e.Message);
                    } finally {
                        fs.Close();
                    }
                }
            }
            return oReturnValue;
        }

        public static string ToJSON(Object obj) {
            return System.Text.Json.JsonSerializer.Serialize(obj);
            //return JsonConvert.SerializeObject(obj);
        }
        public static T FromJSON<T>(string tsJson) {
            return System.Text.Json.JsonSerializer.Deserialize<T>(tsJson);
            //return JsonConvert.DeserializeObject<T>(tsJson);
        }

        public byte[] ObjectToByteArray(Object obj) {
            MemoryStream fs = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(fs, obj);
            byte[] rval = fs.ToArray();
            fs.Close();
            return rval;
        }

        public object ByteArrayToObject(Byte[] Buffer) {
            BinaryFormatter formatter = new BinaryFormatter();
            MemoryStream stream = new MemoryStream(Buffer);
            object rval = formatter.Deserialize(stream);
            stream.Close();
            return rval;
        }
        #endregion (Serialization)

        //public bool DoesList1ContainAnyElementFromList2<T>(List<T) {
        //    var items = (from x in parameters
        //                 join y in myStrings on x.Source equals y
        //                 select x)
        //    .ToList();
        //}

        private static string IncrementFileNameCounter(string tsFileName) {
            string sReturn = tsFileName;
            string[] sFileNameParts = tsFileName.Split('.');
            int iIncrementor = Convert.ToInt32(sFileNameParts[2]);

            while (File.Exists(sReturn)) {

                iIncrementor++;
                sReturn = sFileNameParts[0] + "." + sFileNameParts[1] + "." + iIncrementor.ToString() + ".00.CMD";
            }
            return sReturn;
        }

        public static string[] GetListOfFileNamesInDirectory(string tsDirectory) {
            return GetListOfFileNamesInDirectory(tsDirectory, "");
        }

        public static string[] GetListOfFileNamesInDirectory(string tsDirectory, string tsSearchTemplate) {
            string[] directoryFileList = null;
            if ((tsDirectory != null) && (tsDirectory.Length > 0)) {
                if (tsSearchTemplate.Length > 0) {
                    directoryFileList = Directory.GetFiles(tsDirectory, tsSearchTemplate);
                } else {
                    directoryFileList = Directory.GetFiles(tsDirectory);
                }
            }

            return directoryFileList;
        }

        public void CreateDirectory(string tsNewDirectory) {
            if (!Directory.Exists(tsNewDirectory)) {
                Directory.CreateDirectory(tsNewDirectory);
            }
        }

        public bool ClearDirectory(string tsDirectory) {
            bool bReturn = false;
            if (tsDirectory.Length > 0) {
                if (Directory.Exists(tsDirectory)) {
                    DeleteAllFilesInDirectory(tsDirectory);
                    string[] sSubDirectories = Directory.GetDirectories(tsDirectory);
                    foreach (string sDirectoryName in sSubDirectories) {
                        ClearDirectory(sDirectoryName);
                    }
                    bReturn = true;
                }
            }
            return bReturn;
        }

        public bool DeleteAllFilesInDirectory(string tsDirectoryName) {
            bool bSuccess = true;
            if (tsDirectoryName.Length > 0) {
                bSuccess = false;

                if (!Directory.Exists(tsDirectoryName)) {
                    bSuccess = false;
                    throw new Exception("An attempt has been made to clear all files from the " + tsDirectoryName + " directory.\r\n\r\n        Directory does not exist");
                } else {
                    string[] sFileList = Directory.GetFiles(tsDirectoryName);
                    foreach (string sFileName in sFileList) {
                        try {
                            File.Delete(sFileName);
                        } catch {
                            if (File.Exists(sFileName)) {
                                if (FSTools.FileIsSeenOnly(sFileName)) {
                                    File.SetAttributes(sFileName, FileAttributes.Normal);
                                }
                                try {
                                    File.Delete(sFileName);
                                } catch {
                                    bSuccess = false;
                                    //this.PostApplicationAlert("Unable to delete " + sFileName + ". Program:  GobalUtilities.DeleteAllFilesInDirectory()  Directory:   " + tsDirectoryName);
                                }
                            }
                        }
                    }
                }
            }
            return bSuccess;
        }

        #region Things Managed in the Temp Directory
        public void CreateTempDirectory() {
            string sTempDirectory = FSTools.GetTempDirectory();
            if (!Directory.Exists(sTempDirectory)) {
                Directory.CreateDirectory(sTempDirectory);
            }

            // Clear out all files that do not have a file lock
            string[] sFileList = Directory.GetFiles(sTempDirectory);
            foreach (string sFileName in sFileList) {
                try {
                    File.Delete(sFileName);
                } catch {
                    // Nothing to do - Someone has the file locked - we'll leave it until next time and delete it then
                }
            }
        }

        public static string GetTempDirectory() {
            string temp = Environment.GetEnvironmentVariable("TEMP");
            string sPath = ((temp == null || temp.Length == 0) ? "c:" : temp);
            sPath += "\\CWS";
            return sPath;
        }

        /// <summary>
        /// Creates a unique local file name preferably in the users temp directory.
        /// </summary>
        public static string GetTempFilename() {
            return GetTempFilename(".tmp");
        }
        public static string GetTempFilename(string tsExtension) {
            string sPath = GetTempDirectory();
            return GetTempFilename(sPath, tsExtension);
        }
        public static string GetTempFilename(string tsPath, string tsExtension) {
            if (!tsExtension.Substring(0, 1).Equals(".")) {
                tsExtension = "." + tsExtension;
            }
            return tsPath + "\\~temp" + DateTime.UtcNow.Ticks.ToString() + tsExtension;
        }
        public static string GetUniqueFilename(string tsPath, string tsFileName) {
            int iCounter = 0;
            if (!tsPath.Substring(tsPath.Length -2, 1).Equals("\\")) {
                tsPath = tsPath + "\\";
            }
            string sReturn = tsPath + tsFileName;
            while (File.Exists(sReturn)){
                iCounter++;
                sReturn = tsPath + iCounter.ToString() + tsFileName;
            }
            return sReturn;
        }
        #endregion (Things Managed in the Temp Directory)

        public static void OpenFile(string tsFullPathName) {

            try {
                System.Diagnostics.Process myProcess = new Process();
                myProcess.StartInfo.FileName = tsFullPathName;
                string[] s = myProcess.StartInfo.Verbs;
                myProcess.StartInfo.Verb = "Open";
                myProcess.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
                //myProcess.StartInfo.CreateNoWindow = true;
                myProcess.Start();
            } catch (Exception ex) {
                throw ex;
            }

        }
        /// <summary>
        /// Deletes the specified file.
        /// </summary>
        public static void DeleteLocalFile(string tsFileName) {
            try {
                if (File.Exists(tsFileName)) {
                    File.Delete(tsFileName);
                }
            } catch (Exception ex) {
                //TODO: Figure out why we are getting file lock exceptions.
                throw ex;
            }
        }
        #endregion (File I/O and Directory Management)

        #region Data Types
        public static Type GetTypeFromString(string tsTypeName) {
            Type t = null;

            switch (tsTypeName) {
            case "System.String":
                t = typeof(string);
                break;
            case "System.Int16":
            case "short":
                t = typeof(Int16);
                break;
            case "System.Int32":
            case "int":
                t = typeof(Int32);
                break;
            case "System.Int64":
            case "long":
                t = typeof(Int64);
                break;
            case "System.Decimal":
            case "decimal":
                t = typeof(decimal);
                break;
            case "System.Double":
            case "double":
                t = typeof(double);
                break;
            case "System.Boolean":
            case "boolean":
                t = typeof(bool);
                break;
            case "System.Byte":
            case "byte":
                t = typeof(byte);
                break;
            case "System.Char":
            case "char":
                t = typeof(char);
                break;
            case "System.UInt16":
                t = typeof(UInt16);
                break;
            case "System.UInt32":
                t = typeof(UInt32);
                break;
            case "System.UInt64":
                t = typeof(UInt64);
                break;
            case "System.DateTime":
                t = typeof(DateTime);
                break;
            }
            return t;
        }
        public object ConvertStringToDataType(string tsTypeName, string tsValue) {
            object oReturn = null;
            switch (tsTypeName) {
            case "System.String":
                oReturn = tsValue;
                break;
            case "System.Int16":
            case "short":
                oReturn = Convert.ToInt16(tsValue);
                break;
            case "System.Int32":
            case "int":
                oReturn = Convert.ToInt32(tsValue);
                break;
            case "System.Int64":
            case "long":
                oReturn = Convert.ToInt64(tsValue);
                break;
            case "System.Decimal":
            case "decimal":
                oReturn = Convert.ToDecimal(tsValue);
                break;
            case "System.Double":
            case "double":
                oReturn = Convert.ToDouble(tsValue);
                break;
            case "System.Boolean":
            case "boolean":
                oReturn = Convert.ToBoolean(tsValue);
                break;
            case "System.Byte":
            case "byte":
                oReturn = Convert.ToByte(tsValue);
                break;
            case "System.Char":
            case "char":
                oReturn = Convert.ToChar(tsValue);
                break;
            case "System.UInt16":
                oReturn = Convert.ToUInt16(tsValue);
                break;
            case "System.UInt32":
                oReturn = Convert.ToUInt32(tsValue);
                break;
            case "System.UInt64":
                oReturn = Convert.ToUInt64(tsValue);
                break;
            }
            return oReturn;
        }

        #endregion (Data Types)

        #region Misc Utility Methods
        public static string GenerateSequentialStringKey() {
            Random oRandomProvider = new Random();

            Guid oGuid = Guid.NewGuid();
            string sID = oGuid.ToString("N");
            string shortGuid = Convert.ToBase64String(oGuid.ToByteArray());
            return shortGuid;

            char[] Alphabet = {
            '0', '1', '2', '3', '4', '5', '6', '7', '8', '9',
            'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J',
            'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T',
            'U', 'V', 'W', 'X', 'Y', 'Z',
            'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j',
            'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't',
            'u', 'v', 'w', 'x', 'y', 'z'};

            int iKeyLength = 16;
            int iTimeLength = 8;

            char[] key = new char[iKeyLength];
            // time portion of key
            double value = DateTime.UtcNow.Millisecond;

            try {
                int index = iTimeLength - 1;
                while (value >= Alphabet.Length) {
                    double remainder = value % Alphabet.Length;
                    key[index--] = Alphabet[(int)remainder];
                    value = value / Alphabet.Length;
                }
                if (value > 0) {
                    key[index--] = Alphabet[(int)value];
                }
                while (index >= 0) {
                    key[index--] = Alphabet[0];
                }
            } catch (Exception ex) {
                throw new Exception("The time portion of a generated key has exceeded allowed room.", ex);
            }
            // random portion of key
            for (int i = iTimeLength; i < iKeyLength; i++) {
                key[i] = Alphabet[oRandomProvider.Next(Alphabet.Length)];
            }
            return new String(key);
        }

        #endregion (Misc Utility Methods)

        #region Zip Code
        public static void GetCityStateFromZip(string tsZip, ref string tsCity, ref string tsState) {
            // TODO Need a Zip Code Lookup Service Here so we can get the City / State
        }
        #endregion (Zip Code)

        #region Data type Conversions
        public static bool ConvertToBoolean(bool? tbValue) {
            // Converts a bool? to bool - Assumption - If the value is null the boolean value = False
            bool bReturn = false;
            if ((tbValue != null) && ((bool)tbValue)) {
                bReturn = true;
            }
            return bReturn;
        }
        public static bool ConvertToBoolean(string tsValue) {
            // Converts a bool? to bool - Assumption - If the value is not "T" or "True", the boolean value = False
            bool bReturn = false;
            if (!String.IsNullOrEmpty(tsValue) && ((tsValue.Equals("True")) || (tsValue.Equals("T")))) {
                bReturn = true;
            }
            return bReturn;
        }
        public static Byte[] HtmlToPdf(string tsHtml) {
            return ConvertHtmlToPdf(tsHtml);
        }
        public static Byte[] ConvertHtmlToPdf(string tsHtml) {
            Byte[] oReturn = null;
            using (MemoryStream ms = new MemoryStream()) {
                var pdf = TheArtOfDev.HtmlRenderer.PdfSharp.PdfGenerator.GeneratePdf(tsHtml, PdfSharp.PageSize.A4);
                pdf.Save(ms);
                oReturn = ms.ToArray();
            }
            return oReturn;
        }
        #endregion (Data type Conversions)




        #region Properties
        public static FSTools Instance {
            get {
                if (_fsTools == null) {
                    _fsTools = GetFSTools();
                }
                return _fsTools;
            }
        }
        #endregion (Properties)
    }
}
