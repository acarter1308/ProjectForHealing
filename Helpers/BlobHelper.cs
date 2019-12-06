using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Auth;
using Microsoft.Azure.Storage.Blob;

namespace ProjectForHealing.Helpers
{


  
    public static class BlobHelper
    {

        private const string _BlobKey = "lB8CB0hCfsvVeJtdp1L2qa3qZFTHszMgPwn89wHDwhGo/avBFrwiV+zLtu2ob7J9CiZ+DLYGt0LJqdSdBMxNbQ==";
        private const string _BlobConnectionString = "DefaultEndpointsProtocol=https;AccountName=projectforhealing;AccountKey=lB8CB0hCfsvVeJtdp1L2qa3qZFTHszMgPwn89wHDwhGo/avBFrwiV+zLtu2ob7J9CiZ+DLYGt0LJqdSdBMxNbQ==;EndpointSuffix=core.windows.net";
        private static readonly CloudStorageAccount _CloudStorageAccount;

        static BlobHelper()
        {
            var storageCredentials = new StorageCredentials("projectforhealing", _BlobKey);
            _CloudStorageAccount = new CloudStorageAccount(storageCredentials, true);

       }

        public static void StoreFile(string FileName, Byte[] File)
        {

            var BlobClient = _CloudStorageAccount.CreateCloudBlobClient();
            var Container = BlobClient.GetContainerReference("resourcefiles");
            var BlockBlob = Container.GetBlockBlobReference(FileName);
            using (var stream = new MemoryStream(File))
            {
                BlockBlob.UploadFromStream(stream);
            }
           

        }

        public static Byte[] GetFile(string FileName)
        {
            var BlobClient = _CloudStorageAccount.CreateCloudBlobClient();
            var Container = BlobClient.GetContainerReference("resourcefiles");
            var BlockBlob = Container.GetBlockBlobReference(FileName);

            using (var stream = new MemoryStream())
            {
                BlockBlob.DownloadToStream(stream);
                return stream.ToArray();
            }
             
        }
    }
}
