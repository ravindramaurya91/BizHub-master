using System;
using System.Collections.Generic;
using System.Text;

namespace Model {
    public class EnumSample {
        public enum eShowStatus { ShowPublic = 0, ShowProtected = 1, NoShow = 2 }
        private eShowStatus _showStatus = eShowStatus.NoShow; 

        public eShowStatus ShowStatus { get => _showStatus; set => _showStatus = value; }
    }
}

