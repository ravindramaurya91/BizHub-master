using System;
using System.Collections.Generic;
using System.Text;

using PetaPoco;

namespace Model {
    public class OfficeDTO : BaseEntity{
        #region Events
        public event EventHandler OnUserCountChanged;
        #endregion (Events)

        #region Fields
        private List<UserDTO> _users = new List<UserDTO>();
        #endregion (Fields)

        #region Methods
        public void SetUserCount(int tiUserCount) {
            if (tiUserCount != _users.Count) {
                On_OfficeCountChanged(tiUserCount);
            }
        }
        private void On_OfficeCountChanged(int tiUserCount) {
            if (tiUserCount > _users.Count) {
                for (int i = _users.Count; i < tiUserCount; i++) {
                    UserDTO oNewUser = new UserDTO();
                    Users.Add(oNewUser);
                }
            } else {
                for (int i = _users.Count - 1; i >= tiUserCount; i--) {
                    Users.Remove(_users[i]);
                }
            }

            OnUserCountChanged?.Invoke(_users, null);
        }
        #endregion (Methods)


        #region Properties
        //public int UserCount
        //{
        //    get { return _users.Count; }
        //    set
        //    {
        //        if (_users.Count != value)
        //        {
        //            SetUserCount(value);
        //        }

        //    }
        //}
        public int UserCount { get; set; }
        public List<UserDTO> Users { get => _users; set => _users = value; }
        #endregion (Properties)

    }
}
