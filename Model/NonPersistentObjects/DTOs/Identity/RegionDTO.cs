using System;
using System.Collections.Generic;
using System.Text;

using PetaPoco;

namespace Model
{
    public class RegionDTO : BaseEntity
    {

        #region Events
        public event EventHandler OnOfficeCountChanged;
        #endregion (Events)

        #region Fields
        private List<OfficeDTO> _offices = new List<OfficeDTO>();
        #endregion (Fields)


        #region Methods
        public void SetOfficeCount(int tiOfficeCount)
        {
            if (tiOfficeCount != _offices.Count && tiOfficeCount >= 0)
            {
                On_OfficeCountChanged(tiOfficeCount);
            }
        }
        private void On_OfficeCountChanged(int tiOfficeCount)
        {
            if (tiOfficeCount > _offices.Count)
            {
                for (int i = _offices.Count; i < tiOfficeCount; i++)
                {
                    OfficeDTO oNewOffice = new OfficeDTO();
                    Offices.Add(oNewOffice);
                }
            }
            else
            {
                for (int i = _offices.Count - 1; i >= tiOfficeCount; i--)
                {
                    Offices.Remove(_offices[i]);
                }
            }

            OnOfficeCountChanged?.Invoke(_offices, null);
        }
        #endregion (Methods)

        #region Properties

        public int OfficeCount { get; set; }
        //public int OfficeCount
        //{
        //    get { return _offices.Count; }
        //    set
        //    {
        //        if (_offices.Count != value)
        //        {
        //            //SetOfficeCount(value);
        //        }

        //    }
        //}

        [Column("HasMultipleOffices")]
        public bool HasMultipleOffices { get; set; }
        public List<OfficeDTO> Offices { get => _offices; set => _offices = value; }
        #endregion (Properties)

    }
}
