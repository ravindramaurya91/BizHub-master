using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BizHub.Components.Modals.ContactBroker;
using BizHub.Components.Modals.HierarchicSelector;
using BizHub.Components.Modals.IdentityCard;
using BizHub.Services;
using Blazored.Modal;
using Blazored.Modal.Services;
using BlazorInputFile;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace BizHub.Components.AccountComponents {
    public partial class CmpUserProfile {
        #region Fields
        private IdentityCardDTO _userProfileDTO = new IdentityCardDTO();
        private CmpAccountMenuController _controller = new CmpAccountMenuController();
        #endregion (Fields)

        #region Methods
        public async Task UploadAsync(IFileListEntry fileEntry) {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\userImage", fileEntry.Name);
            var ms = new MemoryStream();
            await fileEntry.Data.CopyToAsync(ms);
            using (FileStream file = new FileStream(path, FileMode.Create, FileAccess.Write)) {
                ms.WriteTo(file);
            }
            userImagePath = "/userImage/" + fileEntry.Name;
        }

        public void PreviewProfile() {
            ShowProfileModal();
        }

        async Task ShowProfileModal() {
            ModalParameters oParameters = new ModalParameters();
            oParameters.Add("EntityOid", UserProfileDTO.Oid);
            FSBlazorModalOptions oOptions = new FSBlazorModalOptions();
            oOptions.HideCloseButton = true;
            oOptions.Class += " identity-card-modal modal-forward";
            // oOptions.HideHeader = true;
            ModalResult BCModalResult = await Controller.ShowModal(typeof(IdentityCard), "", oParameters, oOptions).Result;
            if (BCModalResult.Cancelled) {
                Console.WriteLine("Modal was cancelled");
            } else {
                Console.WriteLine(BCModalResult.Data);
            }
        }

        public void UpdateAboutMe(string tsAboutMe) {
            UserProfileDTO.AboutMe = tsAboutMe;
        }

        protected override void OnInitialized() {
            GetProfileCardDTO();
        }

        public void Cancel() {
            GetProfileCardDTO();
        }

        public void SaveProfileDTO() {
            try {
                UserProfileDTO.Save();
                Controller.ShowPopupDialog("Successfully saved your profile", "Success");
            } catch (Exception ex) {
                Controller.ShowPopupDialog("Unable to save profile: <br>" + ex.Message, "Error");
            }
        }

        public void GetProfileCardDTO() {
            try {
                IdentityCardDTO oDTO = IdentityCardDTO.GetProfileCardDTOByEntityOid(SessionMgr.Instance.User.EntityOid);
                if (oDTO != null) {
                    UserProfileDTO = oDTO;
                }
            } catch (Exception ex) {
                Controller.ShowPopupDialog("Unable to retrieve profile: <br>" + ex.Message, "Error");

            }
        }
        #endregion (Methods)

        #region Properties
        public CmpAccountMenuController Controller { get => _controller; set => _controller = value; }
        public string userImagePath = "/images/man-profile.jpg";

        [Parameter] public IdentityCardDTO UserProfileDTO { get => _userProfileDTO; set => _userProfileDTO = value; }
        #endregion (Properties)

        //UserImage Upload
        IFileListEntry file;
        async Task HandleFileSelected(IFileListEntry[] files) {
            file = files.FirstOrDefault();
            if (file != null) {
                await UploadAsync(file);
            }
        }

    }
}
