using System;
using System.Collections.Generic;
using System.Text;
using PetaPoco;

namespace Model {
    public partial class Recipe {
        #region Fields
        private List<Ingredient> _ingredients = new List<Ingredient>();
        #endregion (Fields)

        #region Properties
        [Ignore]
        public List<Ingredient> Ingredients {
            get { return _ingredients; }
            set { _ingredients = value; }
        }
        #endregion (Properties)


    }
}
