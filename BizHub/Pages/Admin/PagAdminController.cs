using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BizHub
{
    public class PagAdminController : BasePageController
    {

        #region Fields
        private LookupDefinition _activeLookupDefinition = null;
        private LookupDefinition _lookupDefinition = new LookupDefinition();
        private Lookup _lookupz = new Lookup();
        private Lookup _activeLookup = null;
        private List<LookupDefinition> _definitions;
        private LookupUdfBlock _lookupUdfBlock = new LookupUdfBlock();
        private List<Lookup> _lookups = new List<Lookup>();
        #endregion(Fields)

        #region Constructor
        public PagAdminController()
        {
            _definitions = LookupDefinition.Fetch(" ORDER BY LookupName");
            if (_definitions.Count > 0)
            {
                ActiveLookupDefinition = _definitions[0];
            }
        }
        #endregion (Constructor)

        #region Methods

        #region Lookups
        public void SaveLookups()
        {

        }
        public void CancelLookups()
        {
            ActiveLookupDefinition = new LookupDefinition();
            ActiveLookup = new Lookup();
        }
        public void AddLookups()
        {
            ActiveLookupDefinition = new LookupDefinition();
            ActiveLookup = new Lookup();
        }

        private void On_ActiveLookupDefinitionChanged()
        {
            if (_activeLookupDefinition != null)
            {
                _lookups = Lookup.Fetch("WHERE LookupName = @0 ORDER BY Value", _activeLookupDefinition.LookupName);
                if (_lookups.Count > 0)
                {
                    ActiveLookup = _lookups[0];
                }
            }
            else
            {
                _lookups = new List<Lookup>();
            }
            _lookupUdfBlock.LookupDefinition = _activeLookupDefinition;
            _lookupUdfBlock.UDF1Value = ActiveLookup.UDF1;
            _lookupUdfBlock.UDF2Value = ActiveLookup.UDF2;
            _lookupUdfBlock.UDF3Value = ActiveLookup.UDF3;
            _lookupUdfBlock.UDF4Value = ActiveLookup.UDF4;
        }
        private void On_ActiveLookupChanged()
        {
            _lookupUdfBlock.Lookup = _activeLookup;
        }
        #endregion (Lookups)

        #endregion (Methods)

        #region Properties
        public LookupDefinition ActiveLookupDefinition
        {
            get { return _activeLookupDefinition; }
            set
            {
                if (_activeLookupDefinition != value)
                {
                    _activeLookupDefinition = value;
                    On_ActiveLookupDefinitionChanged();
                }
            }
        }
        public Lookup ActiveLookup
        {
            get { return _activeLookup; }
            set
            {
                if (_activeLookup != value)
                {
                    _activeLookup = value;
                    On_ActiveLookupChanged();
                }
            }
        }
        public List<LookupDefinition> Definitions { get => _definitions; set => _definitions = value; }
        public List<Lookup> Lookups { get => _lookups; }
        public LookupUdfBlock LookupUdfBlock { get => _lookupUdfBlock; }

        public bool IsDefinitionClicked { get; set; } = false;
        public bool IsValueClicked { get; set; } = false;

        public LookupDefinition LookupDefinitions { get => _lookupDefinition; set => _lookupDefinition = value; }
        public Lookup Lookup { get => _lookupz; set => _lookupz = value; }
        #endregion (Properties 
    }
}
