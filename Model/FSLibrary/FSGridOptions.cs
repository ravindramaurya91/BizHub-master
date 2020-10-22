using System;
using System.Collections.Generic;
using System.Text;

namespace Model {
    public class FSGridOptions {

        #region Fields
        private bool _allowPaging = true;
        private bool _allowSorting = true;
        private bool _allowGrouping = true;
        private bool _allowFiltering = true;
        private bool _allowReordering = true;
        private bool _allowResizing = true;
        private Int32 _pageSize = 20;
        #endregion (Fields)

        #region Properties
        public bool IsAllowPaging { get => _allowPaging; set => _allowPaging = value; }
        public bool IsAllowSorting { get => _allowSorting; set => _allowSorting = value; }
        public bool IsAllowGrouping { get => _allowGrouping; set => _allowGrouping = value; }
        public bool IsAllowFiltering { get => _allowFiltering; set => _allowFiltering = value; }
        public bool IsAllowReordering { get => _allowReordering; set => _allowReordering = value; }
        public bool IsAllowResizing { get => _allowResizing; set => _allowResizing = value; }
        public Int32 PageSize { get => _pageSize; set => _pageSize = value; }
        #endregion (Properties)

    }
}
