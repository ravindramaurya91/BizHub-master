using Amazon;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web.Http.Routing.Constraints;
using Amazon;

namespace CommonUtil {
    public class S3Request {

        #region Enums
        public enum ePrivacySetting { Private, Public };
        #endregion (Enums)

        #region Fields
        private string _accessKey;
        private string _secret;
        private string _bucketName;
        private string _rootFolder = "";
        private string _folderRoute = "";
        private string _filePath = "";
        private string _fileExtension = "";
        private string _s3Url = "";
        private Stream _fileStream = null;
        private RegionEndpoint _regionEndpoint = null;
        private ePrivacySetting _privacySetting = ePrivacySetting.Private;
        private RegionEndpoint _region = RegionEndpoint.USWest2;
        #endregion (Fields)


        #region Constructor
        public S3Request() {
            LoadDefaults();
        }
        #endregion (Constructor)

        #region Methods
        public  virtual void LoadDefaults() {
        }
        public void UploadImageFileToS3() {
            S3Client oClient = new S3Client(this);
            oClient.UploadImageFileToS3();
            oClient.Dispose();
        }
        #endregion (Methods)



        #region Properties
        public string AccessKey { get => _accessKey; set => _accessKey = value; }
        public string Secret { get => _secret; set => _secret = value; }
        public string BucketName { get => _bucketName; set => _bucketName = value; }
        public string RootFolder { get => _rootFolder; set => _rootFolder = value; }
        public string FolderRoute { get => _folderRoute; set => _folderRoute = value; }
        public string FilePath { get => _filePath; set => _filePath = value; }
        public string FileExtension { get => _fileExtension; set => _fileExtension = value; }
        public string S3Url { get => _s3Url; set => _s3Url = value; }
        public Stream FileStream { get => _fileStream; set => _fileStream = value; }
        public RegionEndpoint RegionEndpoint { get => _regionEndpoint; set => _regionEndpoint = value; }
        public ePrivacySetting PrivacySetting { get => _privacySetting; set => _privacySetting = value; }
        #endregion (Properties)

    }
}
