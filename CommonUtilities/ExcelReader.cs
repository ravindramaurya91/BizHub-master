using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using ExcelDataReader;

namespace CommonUtil {
    public class ExcelReader {

        public static DataTable GetDataTable(string tsFilePath) {
            System.Data.DataTable oReturn = null;

            DataSet oDataSet = GetDataSet(tsFilePath);
            if(oDataSet != null) {
                foreach(DataTable oTable in oDataSet.Tables) {
                    // Get the first worksheet - This way we are not Name dependent
                    oReturn = oTable;
                    break;
                }
            }
            return oReturn;
        }

        public static DataTable GetDataTable(string tsFilePath,string tsExcelSheetName) {
            System.Data.DataTable oReturn = null;

            DataSet oDataSet = GetDataSet(tsFilePath);
            if(oDataSet != null) {
                // Getting the worksheet by Name
                oReturn = oDataSet.Tables[tsExcelSheetName];
            }
            return oReturn;
        }
        public static DataSet GetDataSet(string tsFilePath) {
            System.Data.DataSet oReturn = null;

            //Encoding.GetEncoding(1252);
            //Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            //StreamReader reader = new StreamReader(stream,Encoding.GetEncoding(437));

            ExcelReaderConfiguration oConfig = new ExcelReaderConfiguration { FallbackEncoding = Encoding.GetEncoding(1252) };
            //using(var reader = ExcelReaderFactory.CreateReader(stream,)) {



            using(var stream = File.Open(tsFilePath,FileMode.Open,FileAccess.Read)) {
                using(var reader = ExcelReaderFactory.CreateReader(stream,oConfig)) {
                    oReturn = reader.AsDataSet(new ExcelDataSetConfiguration() {
                        ConfigureDataTable = (data) => new ExcelDataTableConfiguration() {
                            UseHeaderRow = true
                        }
                    });


                }
            }
            return oReturn;
        }

        public static void ListValues(DataTable toDataTable) {
            foreach(DataRow row in toDataTable.Rows) {
                foreach(var value in row.ItemArray) {
                    Console.WriteLine("{0}, {1}",value,value.GetType());
                }
            }
        }

        private static IList<string> GetTablenames(DataTableCollection toTables) {
            List<string> oReturn = new List<string>();
            foreach(var table in toTables) {
                oReturn.Add(table.ToString());
            }

            return oReturn;
        }
    }
}