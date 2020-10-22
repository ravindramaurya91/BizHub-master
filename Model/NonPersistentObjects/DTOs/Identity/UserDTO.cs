using SqlKata;
using System;
using System.Collections.Generic;
using System.Text;

using PetaPoco;

namespace Model{
    public class UserDTO : BaseEntity{

        #region Region Name
        [Column("AboutMe")]
        public string AboutMe { get; set; }
        [Column("FirstName")]
        public string FirstName { get; set; }
        [Column("LastName")]
        public string LastName { get; set; }
        [Column("Title")]
        public string Title { get; set; }
        [Column("DOB")]
        public DateTime DOB { get; set; }
        [Column("IsElite")]
        public bool IsElite { get; set; }
        #endregion (Region Name)

    }
}
