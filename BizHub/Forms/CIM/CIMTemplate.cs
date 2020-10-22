using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using System.IO;
using System.IO.Packaging;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System.Text;

namespace BizHub.Forms.CIM
{
    public partial class CIMTemplate
    {
        #region Fields
        private CIMController _controller = new CIMController();
        #endregion (Fields)

        #region Constructor
        protected override void OnInitialized()
        {
            string path = "";
            //path = path + @"E:\Milan bhai\Development\Git Biz-Hub-Master\BizHub\BizHub\wwwroot\Doc\CIM Page 1 Text.docx";
            path = path + @"E:\Milan bhai\BizHub\23-09-2020\LT.docx";
            Controller.GetPageWiseContent(path, 1);
        }
        #endregion (Constructor)

        #region Methods

        #endregion (Methods)

        #region Properties
        public CIMController Controller { get => _controller; set => _controller = value; }
        public FormResource formResource { get; set; }
        public ParagraphInfo ParagraphInfo { get; set; }

        #endregion (Properties)
    }
}
