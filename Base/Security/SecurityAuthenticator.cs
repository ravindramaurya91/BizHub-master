
using Serilog;

namespace Base.Security
{
    public class SecurityAuthenticator
    {
        /// <summary>
        /// Attempts to authenticate a username and password.
        /// </summary>
        /// <returns>
        ///     A non-null serializable object if authentication was successful.
        ///     Null if failed to authenticate.
        /// </returns>
        public virtual IUserData Authenticate(LoginRequest toRequest)
        {
            Log.Error("No security authenticator set. Please make sure to add/register a <SecurityAuthenticator> during startup.");
            return null;
        }
    }
}
