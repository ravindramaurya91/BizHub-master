using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using Syncfusion.Blazor.RichTextEditor;

using Model;

namespace BizHub.FSLibrary.RichTextEditor {
    public partial class FSRichTextEditor : IFSVisualComponent {

        protected override void OnAfterRender(bool firstRender) {
            if (firstRender) {
                if (RTEditor != null) {
                    EditorInstantiated.InvokeAsync(RTEditor);
                }
            }
        }
        public string _width = "800";

        public virtual void On_Select(string tsValue) {
            OnSelect.InvokeAsync(tsValue);
        }

        public string InterimValue {
            get {
                return BoundValue;
            }
            set {
                BoundValue = value;
                On_Select(BoundValue);
            }
        }

        [Parameter]
        public string BoundValue { get; set; }
        
        [Parameter]
        public string CustomCss { get; set; }

        [Parameter]
        public List<FSVisualItem> Items { get; set; }

        [Parameter]
        public EventCallback<string> OnSelect { get; set; }

        [Parameter]
        public EventCallback<SfRichTextEditor> EditorInstantiated { get; set; }

        public SfRichTextEditor RTEditor { get; set; }

        public object[] Tools = new object[] {
            "Bold", "Italic", "Underline", "SubScript", "SuperScript", "StrikeThrough",
        "FontName", "FontSize", "FontColor", "BackgroundColor",
        "LowerCase", "UpperCase", "|",
        "Formats", "Alignments", "OrderedList", "UnorderedList",
        "Outdent", "Indent", "|", 
        "CreateLink", "Image", "|", "ClearFormat", "Print",
        "|", "Undo", "Redo"
        };

    }
}
