using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BlazorInputFile;

namespace TestUtilities {

    public  class AWS_S3 {
            string bucketName = "cgvak";
            string awsAccessKey = "AKIAQ2VNISEYTTAJAOCC";
            string awsSecretKey = "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";

            IAmazonS3 client = new AmazonS3Client("AKIAQ2VNISEYTTAJAOCC", "za1RDDPx5QCuT4Jc1IwNKERhwfdEbbDTuTM4f88l", RegionEndpoint.USEast2);

            public async Task FolderCreationS3() {
                try {
                    string folderPath = "test/sub-folder/";

                    PutObjectRequest request = new PutObjectRequest() {
                        BucketName = bucketName,
                        Key = folderPath
                    };

                    PutObjectResponse response = await client.PutObjectAsync(request);
                } catch (Exception ex) {

                }

            }

            public async Task FileCopyToS3() {
                try {
                    FileInfo file = new FileInfo(@"d:\AWS\testdoc1.docx");
                    string path = "test/" + file.Name;

                    PutObjectRequest request = new PutObjectRequest() {
                        InputStream = file.OpenRead(),
                        BucketName = bucketName,
                        Key = path // <-- in S3 key represents a path
                    };

                    PutObjectResponse response = await client.PutObjectAsync(request);
               
                } catch (Exception ex) {

                }
            }

            public async Task FileReadFromS3() {
                try {

                } catch (Exception ex) {

                }
            }
        }
    }
