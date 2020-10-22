using Microsoft.AspNetCore.Components;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BizHub {
	public class CmpListViewWithToggleDisplay {

		#region Events
		public event EventHandler OnListChanged;
		#endregion (Events)

		#region Fields
		private string _title = "";
		private bool _isExpanded = false;
		private bool _isMultiSelect = false;
		private List<IValue> _items = new List<IValue>();
		private IValue _selectedItem = null;
		#endregion (Fields)

		#region Constructor
		#endregion (Constructor)

		#region Methods
		public void On_ListChanged() {
			if (OnListChanged != null) {
				OnListChanged.Invoke(Items, null);
			}
		}

		public void ToggleIsExpanded() {
			IsExpanded = !IsExpanded;
		}

		public void OnListItemSelect(IValue tiItem) {
			if(tiItem != null) {
				if (IsMultiSelect) {

				} else {
				}
			}
		}

		#endregion (Methods)

		#region Properties
		[Parameter]
		public string Title { get => _title; set => _title = value; }
		[Parameter]
		public bool IsExpanded { get => _isExpanded; set => _isExpanded = value; }
		[Parameter]
		public bool IsMultiSelect { get => _isMultiSelect; set => _isMultiSelect = value; }
		[Parameter]
		public List<IValue> Items {
			get { return _items; }
			set {
				_items = value;
				On_ListChanged();
			}
		}
		[Parameter]
		public IValue SelectedItem { get => _selectedItem; set => _selectedItem = value; }
		#endregion (Properties)

	}
}
