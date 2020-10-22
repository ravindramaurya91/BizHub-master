using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Syncfusion.Blazor.Inputs;
using Microsoft.AspNetCore.Components;
using System.IO;
using BlazorInputFile;

namespace BizHub.Components.GenericComponents.UploadFile {
    public partial class CmpUploadFile {

        #region Fields
        #endregion (Fields)

        #region Constructor
        #endregion (Constructor)

        #region Methods
        public void OnFileRemove(RemovingEventArgs args) {
            foreach (var removeFile in args.FilesData) {
                if (File.Exists(Path.Combine(@"wwwroot\\userImage", removeFile.Name))) {
                    File.Delete(Path.Combine(@"wwwroot\\userImage", removeFile.Name));
                }
            }
        }

        private void OnChange(UploadChangeEventArgs args) {
            async Task UploadAsync(IFileListEntry fileEntry) {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\userImage", fileEntry.Name);
                var ms = new MemoryStream();
                await fileEntry.Data.CopyToAsync(ms);
                using (FileStream file = new FileStream(path, FileMode.Create, FileAccess.Write)) {
                    ms.WriteTo(file);
                }
                userImagePath = "/userImage/" + fileEntry.Name;
            }
        }

        #endregion (Methods)

        #region Properties
        public string userImagePath = "/userImage/Images/User.png";
        [Parameter]
        public bool IsSingleUpload { get; set; } = true;
        [Parameter]
        public string AllowedExtensions { get; set; } = ".jpg, .jpeg, .png";
        [Parameter]
        public string ChildContent { get; set; } = "";
        #endregion (Properties)

    }
}
