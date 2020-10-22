using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using CommonUtil;
using Model;


namespace ServiceHub {
    public class TestAction : IAction {
        public void Run(QueableMessage toMessage) {
            // This is an Action class to the the routing of the API 
            // Nothing to do here.
            Debug.WriteLine(" ");
            Debug.WriteLine(" ************************************");
            Debug.WriteLine(" The test message bas been received by ServiceHub and has been successfully processed.");
            Debug.WriteLine(" ************************************");
            Debug.WriteLine(" ");
        }
    }
}
