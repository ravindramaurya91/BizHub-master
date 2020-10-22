using System;
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

using Amazon;

using BizHub.Service;
using CommonUtil;
using Base;
using Model;
using System.Reflection.Metadata;
using System.Net.Http;
using Amazon.S3;

namespace TestUtilities {
    public class Test_S3 {
        private IHttpClientFactory _httpClientFactory;

        #region Setup / Tear down
        [SetUp]
        public void InitializeTestHarness() {
            Initialization.BuildServiceProvider();
        }

        [TearDown]
        public void TearDown() {
            // Noithing to do here
        }

        #endregion Setup / Tear down

        [Test]
        public void Test_01_SaveImageToS3() {
            try {
                string sUrl = "";
                string sFileFullPath = @"D:\TWorld\BizHub\Website\WebSite\Candidates\BizHubStoryBoard (21).png";

                S3Client oClient = null;

                //oClient = new S3Client(Constants.AWS_S3_5STONES_KEY, Constants.AWS_S3_5STONES_SECRET,
                //                                Constants.AWS_S3_5STONES_BUCKET, Constants.AWS_S3_5STONES_ROOT_DIRECTORY);

                //oClient.RegionEndpoint = Amazon.RegionEndpoint.USWest2; ;
                //oClient.UploadPdfFileToS3(sFileFullPath, "testArea", out sUrl);
                //Debug.WriteLine(sUrl);


            } catch (ArgumentException ex) {
                Debug.WriteLine(ex);
            }
        }


        [Test]
        public void Test_02_SaveToS3() {
            string awsAccessKey_gcvak = "AKIAQ2VNISEYTTAJAOCC";
            string awsSecretKey_gcvak = "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";

            string awsAccessKey_CWS = "AKIAJZV4HHYHKZPQFVMQ";
            string awsSecretKey_CWS = "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";
            string sUrl = "";


            string AwsIdOnGcVakAccount = "f95e514ebc8ecc72e5d160d00950b7a58f74f2e9aba178da";
            try {




                S3Client oClient = new S3Client(awsAccessKey_CWS, awsSecretKey_CWS, RegionEndpoint.USWest2);
                oClient.BucketName = "5stones/";

                string sFileName = @"D:\TWorld\BizHub\Website\WIP\Images\Register.png";
                string sFolderPath = "test/sub-folder/";

                //oClient.UploadPdfFileToS3(sFileName, sFolderPath, out sUrl);


                //sUrl = oClient.UploadImageFileToS3(sFileName, sFolderPath);

                string sUrlBase = @"https://5stones.s3-us-west-2.amazonaws.com/";
                sUrl = sUrlBase + sUrl;

                //IAmazonS3 client = new AmazonS3Client("AKIAQ2VNISEYTTAJAOCC", "za1RDDPx5QCuT4Jc1IwNKERhwfdEbbDTuTM4f88l", RegionEndpoint.USEast2);
            } catch (AmazonS3Exception amazonS3Exception) {
                Debug.WriteLine(amazonS3Exception.Message);
            } catch (Exception ex) {
                Debug.WriteLine(ex.Message);
            }
            Debug.WriteLine(sUrl);
        }

        [Test]
        public void Test_03_SaveToS3() {
            Model.S3Request oRequest = null;
            try {
                oRequest = new Model.S3Request() {
                    PrivacySetting = CommonUtil.S3Request.ePrivacySetting.Public,
                    FilePath = @"D:\TWorld\BizHub\Website\WIP\Images\Register.png",
                    RootFolder = "Listings/",
                    FolderRoute = "012345/"
                };

                oRequest.UploadImageFileToS3();

            } catch (AmazonS3Exception amazonS3Exception) {
                Debug.WriteLine(amazonS3Exception.Message);
            } catch (Exception ex) {
                Debug.WriteLine(ex.Message);
            }
            Debug.WriteLine(oRequest.S3Url);
        }
    }
}
