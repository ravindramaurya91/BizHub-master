using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Model.ModelExtensions {
    public partial class Listing {

        #region Fields
        private bool _isFavorite = false;
        #endregion (Fields)


        #region Methods
        public void SetIsFavorite(bool tbIsFavorite, Int64 tiEntityOid) {

        }
        #endregion (Methods)



        #region Properties
        public bool IsFavorite { get => _isFavorite; set => _isFavorite = value; }

        #endregion (Properties)

    }
}
