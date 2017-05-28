﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.Azure;

namespace MvcApplication1
{
    public class BlobManager
    {
        static BlobManager singleton = new BlobManager();
        public static BlobManager Instance
        {
            get
            {
                return singleton;
            }
        }

        private CloudBlobContainer GetBlobContainer()
        {
            CloudBlobContainer result = null;
            const string blobContainerName = "a100362";
            const string storageConnectionString = "DefaultEndpointsProtocol=https;AccountName=a100362;AccountKey=A3R0gQkbO3cokcUC8C7HGcpacanRALioj4ykJMZiWNI7ZrQ+TsvY+mke0NweNjV+unwNJYluOWAQcnWI10Lisw==;EndpointSuffix=core.windows.net";
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(storageConnectionString);
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            result = blobClient.GetContainerReference(blobContainerName);
            return result;
        }

        public void UploadBlob(string fileName, HttpPostedFileBase file)
        {
            CloudBlockBlob blob = GetBlobContainer().GetBlockBlobReference(fileName);
            blob.Properties.ContentType = file.ContentType;
            blob.UploadFromStream(file.InputStream);
        }

        public bool DeleteBlob(string fileName)
        {
            CloudBlockBlob blob = GetBlobContainer().GetBlockBlobReference(fileName);
            bool success = blob.DeleteIfExists();
            return success;
        }

        public CloudBlockBlob GetBlockBlob(string fileName)
        {
            return GetBlobContainer().GetBlockBlobReference(fileName);
        }
    }
}