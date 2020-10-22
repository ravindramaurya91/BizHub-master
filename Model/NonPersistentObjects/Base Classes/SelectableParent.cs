using System;
using System.Collections.Generic;
using System.Text;

namespace Model {
    public class SelectableParent : SelectableItem {
        #region Fields
        private SelectableParent _parent = null;
        private List<SelectableParent> _children = new List<SelectableParent>();
        #endregion(Fields)

        #region Methods
        protected override void On_SelectedValueChanged() {
            foreach (SelectableParent oChild in Children) {
                oChild.SetIsSelectedOnChild(this);
            }
        }
        public void SetIsSelectedOnChild(SelectableParent toParent) {
            IsSelected = toParent.IsSelected;
        }
        public void AddChild(SelectableParent toItem) {
            _children.Add(toItem);
            toItem.Parent = this;
        }

        private SelectableParent GetMasterParent() {
            SelectableParent oReturn = this;
            if (Parent != null) {
                oReturn = Parent.MasterParent;
            }
            return oReturn;
        }

        private void On_ChildrenCollectionAdded() {
            foreach (SelectableParent p in _children) {
                p.Parent = this;
                IsSelected = p.IsSelected;
            }
        }
        #endregion(Methods)


        #region Properties

        public SelectableParent MasterParent {
            get {
                return GetMasterParent();
            }
        }
        public SelectableParent Parent { get => _parent; set => _parent = value; }
        public List<SelectableParent> Children {
            get => _children;
            set {
                if (_children != value) {
                    _children = value;
                    On_ChildrenCollectionAdded();
                }

            }
        }
        #endregion(Properties)
    }
}
