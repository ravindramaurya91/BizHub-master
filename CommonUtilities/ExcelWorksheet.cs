using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonUtil {
    public class ExcelWorksheet {

        #region Fields
        private List<ExcelWorksheet> _rows = new List<ExcelWorksheet>();
        System.Data.DataTable _table;
        #endregion (Fields)

        #region Constructor
        public ExcelWorksheet() {}

        public ExcelWorksheet(string tsFileName) {
            _table = ExcelReader.GetDataTable(tsFileName);
        }

        public ExcelWorksheet(string tsFileName,string tsWorksheetName) {
            _table = ExcelReader.GetDataTable(tsFileName,tsWorksheetName);
        }
        #endregion (Constructor)

        public void LoadData() {
            foreach(DataRow oDataRow in _table.Rows) {
                LoadRow(oDataRow);
            }
        }

        public virtual void LoadRow(DataRow toRow) {
        }

        public virtual void Save(DataRow toRow) {
        }

        #region Properties
        public List<ExcelWorksheet> Rows { get => _rows; set => _rows = value; }
        public System.Data.DataTable Table { get => _table; set => _table = value; }
        #endregion (Properties)
    }
}
