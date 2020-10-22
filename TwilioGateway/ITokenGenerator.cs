using System;
using System.Collections.Generic;
using System.Text;

namespace TwilioGateway {
    public interface ITokenGenerator {
        string Generate(string Identity);
    }
}
