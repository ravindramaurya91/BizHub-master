using System;
using System.Collections.Generic;
using System.IO.Pipelines;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonUtil;
using Model;

namespace BizHub
{
    public class PagOnboardController : BasePageController
    {

        #region Enums
        public enum eOnboardedIndividualType { Buyer = 1, Seller = 2, Agent = 3 };
        #endregion (Enums)

        #region Events
        public event EventHandler OnTypeOfIndividualChanged;
        public event EventHandler OnUserCountChanged;
        public event EventHandler OnRegionCountChanged;
        public event EventHandler OnOfficeCountChanged;
        #endregion (Events)

        #region Fields
        private eOnboardedIndividualType _typeOfIndividual = eOnboardedIndividualType.Buyer;
        private int _regionCount = 0;
        private int _officeCount = 0;
        private int _UserCount = 0;
        private int _activePage = 1;
        private RegionDTO regionDTO = new RegionDTO();
        private List<UserDTO> _users = new List<UserDTO>();
        private List<RegionDTO> _regions = new List<RegionDTO>();
        private List<OfficeDTO> _offices = new List<OfficeDTO>();
        #endregion (Fields)

        #region Methods
        public void SetRegionCount(int tiRegionCount)
        {
            if (tiRegionCount != _regions.Count && tiRegionCount >= 0)
            {
                On_RegionCountChanged(tiRegionCount);
            }
        }
        private void On_RegionCountChanged(int tiRegionCount)
        {
            if (tiRegionCount > _regions.Count)
            {
                for (int i = _regions.Count; i < tiRegionCount; i++)
                {
                    RegionDTO oNewRegion = new RegionDTO();
                    _regions.Add(oNewRegion);
                }
            }
            else
            {
                for (int i = _regions.Count - 1; i >= tiRegionCount; i--)
                {
                    _regions.Remove(_regions[i]);
                }
            }

            OnRegionCountChanged?.Invoke(_regions, null);
        }

        public void SetOfficeCount(int tiOfficeCount)
        {
            if (tiOfficeCount != _offices.Count && tiOfficeCount >= 0)
            {
                //RegionDTO regionDTO = new RegionDTO();
                //regionDTO.SetOfficeCount(tiOfficeCount);
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
                    _offices.Add(oNewOffice);
                    //_regions[region].Offices.Add(oNewOffice)
                }
            }
            else
            {
                for (int i = _offices.Count - 1; i >= tiOfficeCount; i--)
                {
                    _offices.Remove(_offices[i]);
                }
            }

            OnOfficeCountChanged?.Invoke(_offices, null);
        }

        public void SetOfficeCount(string tiOfficeCounts, int region)
        {
            int tiOfficeCount = Convert.ToInt32(tiOfficeCounts);
            if (_regions[region].Offices.Count != 0 && tiOfficeCount != _regions[region].Offices.Count)
            {

                On_OfficeCountChanged(tiOfficeCount, region);
            }
            else
            {
                On_OfficeCountChanged(1, region);
            }
        }
        private void On_OfficeCountChanged(int tiOfficeCount, int region)
        {
            if (tiOfficeCount > _regions[region].Offices.Count)
            {
                for (int i = _regions[region].Offices.Count; i < tiOfficeCount; i++)
                {
                    OfficeDTO oNewOffice = new OfficeDTO();
                    //_offices.Add(oNewOffice);
                    _regions[region].Offices.Add(oNewOffice);
                }
            }
            else
            {
                for (int i = _regions[region].Offices.Count - 1; i >= tiOfficeCount; i--)
                {
                    _regions[region].Offices.Remove(_regions[region].Offices[i]);
                }
            }

            OnOfficeCountChanged?.Invoke(_offices, null);
        }
        public void SetUserCount(int tiUserCount)
        {
            if (tiUserCount != _users.Count && tiUserCount >= 0)
            {
                On_UserCountChanged(tiUserCount);
            }
        }
        private void On_UserCountChanged(int tiUserCount)
        {
            if (tiUserCount > _users.Count)
            {
                for (int i = _users.Count; i < tiUserCount; i++)
                {
                    UserDTO oNewUser = new UserDTO();
                    Users.Add(oNewUser);
                }
            }
            else
            {
                for (int i = _users.Count - 1; i >= tiUserCount; i--)
                {
                    Users.Remove(_users[i]);
                }
            }
            OnUserCountChanged?.Invoke(_users, null);
        }

        public void SetUserCount(int tiUserCount, int tiOfficeCount, int region)
        {
            if (_regions[region].Offices[tiOfficeCount].Users.Count != 0 && tiUserCount != _regions[region].Offices[tiOfficeCount].Users.Count)
            {

                On_UserCountChanged(tiUserCount, tiOfficeCount, region);
            }
            else
            {
                On_UserCountChanged(1, tiOfficeCount, region);
            }
        }
        private void On_UserCountChanged(int tiUserCount, int tiOfficeCount, int region)
        {
            if (tiUserCount > _regions[region].Offices[tiOfficeCount].Users.Count)
            {
                for (int i = _regions[region].Offices[tiOfficeCount].Users.Count; i < tiUserCount; i++)
                {
                    UserDTO oNewUser = new UserDTO();
                    _regions[region].Offices[tiOfficeCount].Users.Add(oNewUser);
                    //Users.Add(oNewUser);
                }
            }
            else
            {
                for (int i = _regions[region].Offices[tiOfficeCount].Users.Count - 1; i >= tiUserCount; i--)
                {
                    _regions[region].Offices[tiOfficeCount].Users.Remove(_regions[region].Offices[tiOfficeCount].Users[i]);
                }
            }
            OnUserCountChanged?.Invoke(_users, null);
        }

        public void SetUserCount(int tiUserCount, int tiOfficeCount)
        {
            if (Offices[tiOfficeCount].Users.Count != 0 && tiUserCount != Offices[tiOfficeCount].Users.Count)
            {

                On_UserCountChanged(tiUserCount, tiOfficeCount);
            }
            else
            {
                On_UserCountChanged(1, tiOfficeCount);
            }
        }
        private void On_UserCountChanged(int tiUserCount, int tiOfficeCount)
        {
            if (tiUserCount > Offices[tiOfficeCount].Users.Count)
            {
                for (int i = Offices[tiOfficeCount].Users.Count; i < tiUserCount; i++)
                {
                    UserDTO oNewUser = new UserDTO();
                    Offices[tiOfficeCount].Users.Add(oNewUser);
                    //Users.Add(oNewUser);
                }
            }
            else
            {
                for (int i = Offices[tiOfficeCount].Users.Count - 1; i >= tiUserCount; i--)
                {
                    Offices[tiOfficeCount].Users.Remove(Offices[tiOfficeCount].Users[i]);
                }
            }
            OnUserCountChanged?.Invoke(_users, null);
        }

        #region Events
        private void On_TypeOfIndividualChanged()
        {
            OnTypeOfIndividualChanged?.Invoke(this.TypeOfIndividual, null);
        }

        #endregion (Events)

        public void Save()
        {
            // To Be Implemented
            if (Page1IsValid())
            {
                SelectMenuItem();
            }
        }

        public void Back(int currentpage)
        {
            ChangeStep(currentpage);
        }

        public void SelectMenuItem()
        {
            switch (_typeOfIndividual)
            {
                case eOnboardedIndividualType.Buyer:
                    break;
                case eOnboardedIndividualType.Seller:
                    if (ActivePage == 2)
                    {
                        ActivePage = 3;
                    }
                    else
                    {
                        ActivePage = 3;
                    }
                    break;

                default:
                    if (ActivePage == 2)
                    {
                        ActivePage = 3;
                    }
                    else
                    {
                        ActivePage = 2;
                    }
                    break;
            }
            ChangeStep(ActivePage);
            //if (ActivePage == 1)
            //{
            //    ChangeStep(tiStepNumber);
            //}
            //else if (ActivePage == 2)
            //{
            //    ChangeStep(tiStepNumber);
            //}
        }
        public void ChangeStep(int tiArrowNumber)
        {
            this.ActivePage = tiArrowNumber;
        }

        #region Validate Pages

        public bool Page1IsValid()
        {
            bool result = false;
            List<string> oFields = new List<string>();
            switch (_typeOfIndividual)
            {
                case eOnboardedIndividualType.Buyer:
                    Validate_Buyer(oFields);
                    break;
                case eOnboardedIndividualType.Seller:
                    Validate_Seller(oFields);
                    //ActivePage = 3;
                    break;
                default:
                    Validate_Agent(oFields);
                    //ActivePage = 2;
                    break;
            }

            string sMsg;
            if (oFields.Count > 0)
            {
                if (oFields.Count == 1)
                {
                    sMsg = oFields[0].Replace(", ", "") + " is a required field to setup a new account.";
                }
                else
                {
                    sMsg = FSTools.ConvertListToDelimitedString(oFields, ", ");
                    int iPos = sMsg.IndexOfNthOccurrence(", ", oFields.Count - 2);
                    if (iPos > -1)
                    {
                        sMsg = sMsg.Substring(0, iPos) + ", and" + sMsg.Substring(iPos + 1); // Flip the next to last comma to the word "and"
                    }

                    sMsg += " are required fields to setup a new account."; // Remove the final comma 
                }
                ShowPopupDialog(sMsg, "Error");
                //throw new Exception(sMsg);
                IsSubmitted = true;
                result = false;
            }
            else
            {
                IsSubmitted = false;
                result = true;
            }
            // If we did not throw an error - we will retunr "True"  - We passed validation
            return result;
        }

        private void Validate_Buyer(List<string> toFields)
        {
            if ((string.IsNullOrEmpty(FirstName)) || (string.IsNullOrWhiteSpace(FirstName)))
            {
                toFields.Add("First Name");
            }
            if ((string.IsNullOrEmpty(LastName)) || (string.IsNullOrWhiteSpace(LastName)))
            {
                toFields.Add("Last Name");
            }
            if ((string.IsNullOrEmpty(Zip)) || (string.IsNullOrWhiteSpace(Zip)))
            {
                toFields.Add("Zip Code");
            }
        }

        private void Validate_Seller(List<string> toFields)
        {
            if ((string.IsNullOrEmpty(CompanyName)) || (string.IsNullOrWhiteSpace(FirstName)))
            {
                toFields.Add("Company Name");
            }
            if ((string.IsNullOrEmpty(CompanyZip)) || (string.IsNullOrWhiteSpace(Zip)))
            {
                toFields.Add("Company Zip Code");
            }

            Validate_Buyer(toFields);
        }
        private void Validate_Agent(List<string> toFields)
        {
            if (ActivePage == 1)
            {
                Validate_Seller(toFields);
                Validate_Buyer(toFields);
            }
            else
            {
                Validate_AgentPage2(toFields);
            }
        }
        private void Validate_AgentPage2(List<string> toFields)
        {
        }
        #endregion (Validate Pages)

        #endregion (Methods)

        #region Properties
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Zip { get; set; } = "";
        public string CompanyName { get; set; } = "";
        public string CompanyAddress1 { get; set; } = "";
        public string CompanyAddress2 { get; set; } = "";
        public string CompanyZip { get; set; } = "";
        public bool IsSubmitted { get; set; } = false;
        public bool HasMultipleRegions { get; set; } = false;
        public bool HasMultipleOffices { get; set; } = false;
        public int RegionCount
        {
            get { return _regions.Count; }
            set
            {
                if (_regions.Count != value)
                {
                    SetRegionCount(value);
                }

            }
        }
        public int OfficeCount
        {
            get { return _offices.Count; }
            set
            {
                if (_offices.Count != value)
                {
                    SetOfficeCount(value);
                }

            }
        }
        public int UserCount
        {
            get { return _users.Count; }
            set
            {
                if (_users.Count != value)
                {
                    SetUserCount(value);
                }
            }
        }


        //public RegionDTO RegionDTO { get; set; }
        //public int OfficeCount { get => _officeCount; set => _officeCount = value; }
        //public int UserCount { get => _users.Count; set => _UserCount = value; }
        public int ActivePage { get => _activePage; set => _activePage = value; }
        public eOnboardedIndividualType TypeOfIndividual
        {
            get { return _typeOfIndividual; }
            set
            {
                if (_typeOfIndividual != value)
                {
                    _typeOfIndividual = value;
                    On_TypeOfIndividualChanged();
                }
            }
        }
        public List<RegionDTO> Regions { get => _regions; set => _regions = value; }
        public List<OfficeDTO> Offices { get => _offices; set => _offices = value; }
        public List<UserDTO> Users { get => _users; set => _users = value; }

        #endregion (Properties)

    }
}
