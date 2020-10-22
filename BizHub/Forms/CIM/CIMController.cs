using BizHub.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System.Text;


namespace BizHub
{
    public class CIMController
    {
        #region Fields

        #endregion (Fields)
        private List<ParagraphInfo> _paragraphInfolist = new List<ParagraphInfo>();
        #region Methods

        #endregion (Methods)
        public void GetPageWiseContent(string path = "", int pageNum = 1)
        {
            try
            {
                Dictionary<int, string> pageviseContent = new Dictionary<int, string>();
                int pageCount = 0;
                using (WordprocessingDocument wordDocument = WordprocessingDocument.Open(path, true))
                {
                    // Stream stream = File.Open(path, FileMode.Open);
                    Body body = wordDocument.MainDocumentPart.Document.Body;
                    // string content = body.InnerText;
                    if (wordDocument.ExtendedFilePropertiesPart.Properties.Pages.Text != null)
                    {
                        pageCount = Convert.ToInt32(wordDocument.ExtendedFilePropertiesPart.Properties.Pages.Text);
                    }

                    var paragraphInfos = new List<ParagraphInfo>();
                    var paragraphs = wordDocument.MainDocumentPart.Document.Descendants<Paragraph>();
                    StringBuilder pageContentBuilder = new StringBuilder();
                    int pageIdx = 1;
                    foreach (var paragraph in paragraphs)
                    {
                        var run = paragraph.GetFirstChild<Run>();

                        if (run != null)
                        {
                            var lastRenderedPageBreak = run.GetFirstChild<LastRenderedPageBreak>();
                            var pageBreak = run.GetFirstChild<Break>();
                            if (lastRenderedPageBreak != null || pageBreak != null)
                            {
                                pageIdx++;
                            }
                            var info = new ParagraphInfo
                            {
                                Paragraph = paragraph.InnerText,
                                PageNumber = pageIdx
                            };

                            paragraphInfos.Add(info);
                            ParagraphInfolist.Add(info);
                        }

                    }
                    #region Commented
                    //int i = 1;

                    //foreach (var element in body.ChildElements)
                    //{
                    //    if (element.InnerXml.IndexOf("<w:br w:type=\"page\" />", StringComparison.OrdinalIgnoreCase) < 0)
                    //    {
                    //        pageContentBuilder.Append(element.InnerText);
                    //    }
                    //    else
                    //    {
                    //        pageviseContent.Add(i, pageContentBuilder.ToString());
                    //        i++;
                    //        pageContentBuilder = new StringBuilder();
                    //    }
                    //    if (body.LastChild == element && pageContentBuilder.Length > 0)
                    //    {
                    //        pageviseContent.Add(i, pageContentBuilder.ToString());
                    //    }
                    //} 
                    #endregion
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region Properties
        public string CompanyName { get; set; } = "Capitol Door Company";
        public string CompanyAcronym { get; set; } = "CDC";

        public List<ParagraphInfo> ParagraphInfolist { get => _paragraphInfolist; set => _paragraphInfolist = value; }
        #endregion (Properties)

    }
}
