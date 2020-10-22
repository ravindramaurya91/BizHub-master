using System;
using System.Collections.Generic;
using System.Text;

namespace Model {
    public interface IIndexer {
        object Get(string tsPropertyName);
        void Set(string tsPropertyName, object value);
    }
}
