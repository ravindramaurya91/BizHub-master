using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Blazored.Modal;

namespace BizHub {
    public class FSBlazorModalOptions : ModalOptions {

        public FSBlazorModalOptions() {
            Class = "modal-forward ";
            DisableBackgroundCancel = true;
        }

    }
}
