using System;
using System.Collections.Generic;
using System.Text;

namespace Model {
    public class FSInfoModalOptions : FSGenericModalOptions {

        #region Contructor
        public FSInfoModalOptions() {

        }

        public FSInfoModalOptions(string tsDefaultType) {
            GenerateDefaultValuesByType(tsDefaultType);
        }
        #endregion (Contructor)

        #region Methods
        public void GenerateDefaultValuesByType(string tsDefaultType) {
            FSModalButton oButton = new FSModalButton(Constants.BUTTON_OK, true);
            switch (tsDefaultType) {
                case "Warning":
                    Header = "Warning!";
                    oButton.CSS += " warning-button dialog-buttons";
                    Buttons.Add(oButton);
                    IconCSS = "fa-exclamation-circle warning-icon";
                    break;

                case "Error":
                    Header = "Error!";
                    oButton.CSS += " error-button dialog-buttons";
                    Buttons.Add(oButton);
                    IconCSS = "fa-times error-icon";
                    break;

                case "Success":
                    Header = "Success!";
                    oButton.CSS += " success-button dialog-buttons";
                    Buttons.Add(oButton);
                    IconCSS = "fa-check success-icon";
                    break;

                default: break;
            }
        }
        #endregion (Methods)

    }
}
