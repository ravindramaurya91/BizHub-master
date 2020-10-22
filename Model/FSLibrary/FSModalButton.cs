
namespace Model {
    public class FSModalButton {


        #region Fields
        private string _css = "btn ";
        #endregion (Fields)

        #region Constructor
        public FSModalButton(string tsButtonType, bool tbIsPrimary = false, bool tbIsSmall = true) {
            IsPrimary = tbIsPrimary;
            IsSmall = tbIsSmall;
            Name = tsButtonType;
            SetCSS();
        }
        #endregion (Constructor)


        #region Methods
        private void SetCSS() {
            if (IsSmall) { 
                CSS += " btn-sm"; 
            } else {
                CSS += " btn-lg";
            }
            if (IsPrimary) {
                CSS += " btn-primary";
            } else {
                CSS += " btn-outline-secondary";
            }
        }
        #endregion (Methods)

        #region Properties
        public string Name { get; set; }
        public bool IsPrimary { get; set; }
        public bool IsSmall { get; set; }
        public string CSS { get => _css; set => _css = value; }
        #endregion (Properties)

    }
}
