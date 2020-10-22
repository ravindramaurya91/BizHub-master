using System;
using System.Collections.Generic;
using System.Text;

namespace Model {
    public class FSGenericModalOptions {


        #region Fields
        private string _header = "";
        private string _headerCSS = "";
        private string _body = "";
        private string _bodyCSS = "";
        private string _iconCSS = "";
        private List<FSModalButton> _buttons = new List<FSModalButton>();
        #endregion (Fields)


        #region Properties
        public string Header { get => _header; set => _header = value; }
        public string HeaderCSS { get => _headerCSS; set => _headerCSS = value; }
        public string Body { get => _body; set => _body = value; }
        public string BodyCSS { get => _bodyCSS; set => _bodyCSS = value; }
        public string IconCSS { get => _iconCSS; set => _iconCSS = value; }
        public List<FSModalButton> Buttons { get => _buttons; set => _buttons = value; }
        #endregion (Properties)

    }
}
