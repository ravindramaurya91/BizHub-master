using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using Amazon.S3.Util;
using Amazon.SQS.Model;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace CommonUtil {
    public class S3Client : AmazonS3Client {
        private S3Request _request;
        private string _key;
        private string _secret;
        private string _bucketName;
        private string _rootFolder = "BizHub/";
        private string _folderRoute = "";
        private RegionEndpoint _regionEndPoint = null;

        #region Constructor
        public S3Client(S3Request toRequest) : base(toRequest.AccessKey, toRequest.Secret, toRequest.RegionEndpoint) {
            _request = toRequest;
            _bucketName = _request.BucketName;
            _key = _request.AccessKey;
            _secret = _request.Secret;
            _rootFolder = _request.RootFolder;
            _folderRoute = _request.FolderRoute;
            _regionEndPoint = _request.RegionEndpoint;
        }

        public S3Client(string tsKey, string tsSecret, RegionEndpoint toEnpoint) : base(tsKey, tsSecret, toEnpoint) {
        }
        #endregion (Constructor)

        #region Methods

        public void UploadImageFileToS3() {
            if ((string.IsNullOrEmpty(_request.FilePath)) && (_request.FileStream == null)) {
                throw new Exception("Unable to upload image to the S3. You must either provide a file in the FilePath property to be uploaded or provide the FileStream.");
            }

            if (_request.FileStream == null) {
                // FileStream is empty - we will load the filestream from the FilePath provided
                if (!File.Exists(_request.FilePath)) {
                    throw new Exception($"Unable to upload image to the S3. Unable to locate requested file [{_request.FilePath}]");
                }
                _request.FileExtension = StringUtil.GetFileExtension(_request.FilePath).ToLower();
                _request.FileStream = File.OpenRead(_request.FilePath);
            }

            if (string.IsNullOrEmpty(_request.FileExtension)) {
                throw new Exception("Unable to upload image to the S3. You must provide a file extension. It will be used to identify the type of file being uploaded.");
            }

            // Aws Path =
            string sGuid = Guid.NewGuid().ToString();
            string sFileName = sGuid + _request.FileExtension;
            string sFinalFilePath =  _request.RootFolder + _request.FolderRoute + sFileName;


            TransferUtility oTransferUtil = new TransferUtility(this);
            TransferUtilityUploadRequest oUploadRequest = GetUploadRequest();
            oUploadRequest.ContentType = "image/" + _request.FileExtension.ToLower();
            oUploadRequest.InputStream = _request.FileStream;
            oUploadRequest.Key = sFinalFilePath;
            oTransferUtil.Upload(oUploadRequest);
            oTransferUtil.Dispose();
            //"https://bizhub-public.s3-us-west-2.amazonaws.com/bizhub-public/Listings/012345/d918e5f4-ebd5-4e84-a0ad-be4145f4eb7b.PNG"
            _request.S3Url = "https://" + _request.BucketName.Replace("/","") + ".s3-us-west-2.amazonaws.com//" +  sFinalFilePath;
            _request.FileStream.Dispose();

        }



        public string UploadPdfFileToS3(string tsSourceFileToUpload, string tsFolderStructure) {
            // Now upload to the Amazon S3
            string sReturn = "";
            string sFileName = StringUtil.StripPath(tsSourceFileToUpload).Replace(" ", "");
            string sAmazonPath = tsFolderStructure + sFileName;

            TransferUtility oTransferUtil = new TransferUtility(this);
            TransferUtilityUploadRequest oRequest = GetUploadRequest();
            oRequest.ContentType = "application/pdf";
            oRequest.FilePath = tsSourceFileToUpload;
            oRequest.Key = sAmazonPath;
            oTransferUtil.Upload(oRequest);
            oTransferUtil.Dispose();

            sReturn = _rootFolder + sAmazonPath;
            //tsS3UrlToFileDestination = Constant.AMAZON_S3_Root_DIRECTORY_FRO_CWS_S3 + sAmazonPath;
            return sReturn;
        }

        public string UploadImageFileToS3(string tsSourceFileToUpload, string tsFolderStructure) {
            string sUrl = "";

            if (!File.Exists(tsSourceFileToUpload)) {
                throw new Exception($"Unable to locate file: {tsSourceFileToUpload}");
            }
            string sFileExtension = StringUtil.GetFileExtension(tsSourceFileToUpload);


            using (FileStream oStream = File.OpenRead(tsSourceFileToUpload)) {
                if ((oStream != null) && (oStream.Length > 0)) {
                    // Load the User Profile Picture
                    UploadImageStreamToS3(oStream, ref sUrl, sFileExtension);
                    //ServiceUtility.UploadPhotoToAmazon(oStream, ref sUrlToS3Destination, sFileExtension);
                }

            }
            return sUrl;
        }

        public void UploadFileStreamToS3(string tsAwsPath, Stream toFileStream, ref string tsS3UrlToFileDestination, string tsFileExtension) {
            // Aws Path = EntityOid_Master / TargetTable / TargetOid/ "files" / (fileName) 
            // Now upload to the Amazon S3
            string sGuid = Guid.NewGuid().ToString();
            string sFileName = sGuid + tsFileExtension;
            string sFinalFilePath = tsAwsPath + sFileName;

            TransferUtility oTransferUtil = new TransferUtility(this);
            TransferUtilityUploadRequest oUploadRequest = GetUploadRequest();
            oUploadRequest.ContentType = "application/" + tsFileExtension;
            oUploadRequest.InputStream = toFileStream;
            oUploadRequest.Key = sFinalFilePath;
            oTransferUtil.Upload(oUploadRequest);
            oTransferUtil.Dispose();

            tsS3UrlToFileDestination = _rootFolder + _bucketName + "/" + sFinalFilePath;
        }
        private TransferUtilityUploadRequest GetUploadRequest() {
            TransferUtilityUploadRequest oReturn = new TransferUtilityUploadRequest();
            oReturn.AutoCloseStream = true;
            oReturn.BucketName = this.BucketName;
            oReturn.CannedACL = "public-read";
            return oReturn;
        }

        public void UploadImageStreamToS3(Stream toImageStream, ref string tsS3UrlToFileDestination, string tsFileExtension) {
            float fQuality = 25;

            //******  WEB P FORMATING *****************
            // Convert image to Webp format if needed.
            //string sPhotoExtensionsNeedingConversion = ",.jpg,.jpeg,.png,.gif,.tiff,";

            // Hide WebP conversion until Apple Safari supports it
            //if (sPhotoExtensionsNeedingConversion.Contains("," + tsFileExtension.ToLower() + ",")) {
            //    int iResolution = 25;
            //    string sImageResolution = ConfigurationMgr.Instance.GetValueByName("Webp Default Image Resolution");
            //    if (!String.IsNullOrEmpty(sImageResolution)) {
            //        iResolution = Convert.ToInt32(sImageResolution);
            //    }

            //    toPhotoStream = ImageManager.ConvertToWebPMemoryStream(toPhotoStream, iResolution);
            //    tsFileExtension = ".webp";
            //}
            //**************************************

            // Now upload to the Amazon S3
            string sGuid = Guid.NewGuid().ToString();

            string sAmazonBucket = _bucketName + "Images/";
            string sFinalFilePath = sGuid + tsFileExtension;

            //S3Response oResponse = await CreateAmazonBucketAsync();
            //if (!oResponse.Success) { throw new Exception("Unable to acces or create bucket on Amaxzon S3"); }
            // Another way to call an async method - but return must be void
            CreateAmazonBucketAsync().Wait();  // Check to see if Bucket exists - if not create it
            TransferUtility oTransferUtil = new TransferUtility(this);
            TransferUtilityUploadRequest oUploadRequest = GetUploadRequest();
            oUploadRequest.ContentType = "image/" + tsFileExtension;
            oUploadRequest.InputStream = toImageStream;
            oUploadRequest.Key = sFinalFilePath;
            oTransferUtil.Upload(oUploadRequest);
            oTransferUtil.Dispose();

            //PutACLRequest request = new PutACLRequest();
            //request.BucketName = this.BucketName;
            //request.Key = this._key;
            //request.CannedACL = S3CannedACL.PublicRead;
            //this.PutACLAsync(request);

            tsS3UrlToFileDestination = _rootFolder + sAmazonBucket + "/" + sFinalFilePath;
        }

        public void UploadVideoToAmazon(MemoryStream toVideoMemoryStream, MemoryStream toThumbnailMemoryStream, ref string tsVideoUrl, ref string tsThumbnailUrl, string tsFileExtension) {
            string sGuid = Guid.NewGuid().ToString();

            string sVideoFilePath = "Videos/" + sGuid + tsFileExtension;
            string sThumbnailFilePath = "Videos/" + sGuid + ".jpg";

            TransferUtility utility = new TransferUtility(this);   // amazon transfer class
            utility.Upload(toVideoMemoryStream, _bucketName, sVideoFilePath);
            utility.Upload(toThumbnailMemoryStream, _bucketName, sThumbnailFilePath);

            tsVideoUrl = _rootFolder + _bucketName + "/" + sVideoFilePath;
            tsThumbnailUrl = _rootFolder + _bucketName + "/" + sThumbnailFilePath;
        }

        #region Old Video Save with a Thumbnail Creation
        //public static void UploadVideoToAmazonFromStream(Stream toStream, ref string tsVideoUrl, ref string tsThumbnailUrl) {
        //}

        //public static void UploadVideoToAmazonFromFile(string tsFileName, ref string tsVideoUrl, ref string tsThumbnailUrl) {
        //    //NReco.VideoConverter.FFMpegConverter ffMpeg = null;
        //    string sFileExtension = StringUtil.GetFileExtension(tsFileName);

        //    ////******************    VIDEO     ********************************
        //    //// Create Memory Stream for video
        //    //MemoryStream oVideoMemoryStream = new MemoryStream();
        //    //// Cobnvert video to ffMpeg
        //    //ffMpeg = new NReco.VideoConverter.FFMpegConverter();
        //    //var settings = new NReco.VideoConverter.ConvertSettings();
        //    //settings.CustomOutputArgs = "-vcodec libx264 -profile:v main -level 3.1 -preset veryslow -b:v 555k -crf 23 -x264-params ref=4 -acodec copy -movflags +faststart -vf \"scale = -2:720:flags = lanczos\"";
        //    //if (sFileExtension.ToLower().Equals(".mov")) {
        //    //    ffMpeg.ConvertMedia(tsFileName, null, oVideoMemoryStream, NReco.VideoConverter.Format.mov, settings);
        //    //} else {
        //    //    ffMpeg.ConvertMedia(tsFileName, null, oVideoMemoryStream, NReco.VideoConverter.Format.mp4, settings);
        //    //}

        //    //// Upload Video to the S3

        //    ////******************    Thumbnail     ********************************
        //    //MemoryStream oThumbnailMemoryStream = new MemoryStream();
        //    //ffMpeg.GetVideoThumbnail(tsFileName, oThumbnailMemoryStream);

        //    //MercadoUtil.UploadVideoToAmazon(oVideoMemoryStream, oThumbnailMemoryStream, ref tsVideoUrl, ref tsThumbnailUrl, sFileExtension);
        //}
        #endregion (Old Video Save with a Thumbnail Creation)

        #region Amazon S3 Utilties
        private async Task<S3Response> CreateAmazonBucketAsync() {
            S3Response oReturn = new S3Response() { Success = true, Message = "Bucket already exists", Status = HttpStatusCode.OK };
            try {
                if (!await AmazonS3Util.DoesS3BucketExistV2Async(this, _bucketName)) {
                    var putBucketRequest = new PutBucketRequest {
                        BucketName = _bucketName,
                        UseClientRegion = true
                    };

                    PutBucketResponse putBucketResponse = await this.PutBucketAsync(putBucketRequest);
                    oReturn.Success = true;
                    oReturn.Message = "Success";
                    oReturn.Status = putBucketResponse.HttpStatusCode;
                }
                // Retrieve the bucket location.
                string bucketLocation = await FindBucketLocationAsync();
            } catch (AmazonS3Exception e) {
                Console.WriteLine("Error encountered on server. Message:'{0}' when writing an object", e.Message);
                oReturn.Success = false;
                oReturn.Message = e.Message;
                oReturn.Status = HttpStatusCode.InternalServerError;
            } catch (Exception e) {
                Console.WriteLine("Unknown encountered on server. Message:'{0}' when writing an object", e.Message);
                oReturn.Success = false;
                oReturn.Message = e.Message;
                oReturn.Status = HttpStatusCode.InternalServerError;
            }

            return oReturn;
        }
        private async Task<string> FindBucketLocationAsync() {
            var request = new GetBucketLocationRequest() {
                BucketName = _bucketName
            };
            GetBucketLocationResponse response = await this.GetBucketLocationAsync(request);
            return response.Location.ToString();
        }
        #endregion (Amazon S3 Utilties)

        #endregion (Methods)

        #region Properties
        //public RegionEndpoint RegionEndpoint {
        //    get { return _regionEndPoint; }
        //    set {
        //        _regionEndPoint = value;
        //        OnRegionEndPointSet();
        //    }
        //}

        public string BucketName { get => _bucketName; set => _bucketName = value; }
        public string RootFolder { get => _rootFolder; set => _rootFolder = value; }
        public string FolderRoute { get => _folderRoute; set => _folderRoute = value; }
        #endregion (Properties)
    }

    public class S3Response {
        #region Properties
        public bool Success { get; set; }
        public string Message { get; set; }
        public HttpStatusCode Status { get; set; }
        #endregion (Properties)
    }
}
