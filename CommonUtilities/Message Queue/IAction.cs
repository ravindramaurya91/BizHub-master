using System;
using System.Collections.Generic;
using System.Text;

namespace CommonUtil {
    public interface IAction {
        void Run(QueableMessage message);
    }
}
