using System;
using System.Collections.Generic;
using System.Text;

using CommonUtil;
using Base;
using System.Configuration.Internal;
using Microsoft.Extensions.Configuration;

using Amazon;

namespace Model {
    public class S3Request : CommonUtil.S3Request{

        public override void LoadDefaults() {
            
            IConfiguration oConfig = Base.Context.Get<IConfiguration>();
            var section = oConfig.GetSection("Amazon:S3:BizHub");
            AccessKey = section.GetValue<string>("AccessKey");
            Secret = section.GetValue<string>("Secret");
            BucketName = section.GetValue<string>("BucketName");
            RootFolder = section.GetValue<string>("RootFolder");
            RegionEndpoint = RegionEndpoint.GetBySystemName(section.GetValue<string>("Region"));
            PrivacySetting = ePrivacySetting.Private;
        }
    }
}
