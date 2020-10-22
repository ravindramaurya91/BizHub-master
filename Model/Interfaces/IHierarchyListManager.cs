using System;
using System.Collections.Generic;
using System.Text;

namespace Model {
    public interface IHierarchyListManager{
        void AddItem(Int64 tiOid);
        void AddItems(List<Int64> toList);

        void RemoveItem(Int64 tiOid);
        void RemoveItems(List<Int64> toList);
        
        List<IHierarchy> SelectedItems { get; }

        List<IHierarchy> GetAllItems();


    }
}
