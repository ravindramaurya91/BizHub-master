using BizHub.Areas.Identity;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BizHub.Services {
    public class AuthenticationService {
        #region Fields
        private BizHubIdentityDbContext _dbContext;
        #endregion (Fields)

        public AuthenticationService(BizHubIdentityDbContext toBizHubIdentityDbContext) {
            _dbContext = toBizHubIdentityDbContext;
        }

        public void UpdateAuthenticationRecordFromLoggedInUserId(Entity toEntity) {

        }
        public void UpdateAuthenticationRecordFromEntity(Entity toEntity) {

        }
    }
}
