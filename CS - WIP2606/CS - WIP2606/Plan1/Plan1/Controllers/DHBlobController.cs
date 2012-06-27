using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.ServiceRuntime;
using Microsoft.WindowsAzure.StorageClient;
using Microsoft.WindowsAzure.StorageClient.Protocol;
using Plan1.Models;
using System.IO;


namespace Plan1.Controllers
{
    public class DHBlobController : Controller
    {        
        //
        // GET: /DHBlob/

        public ActionResult Index(string id)
        {
            // Retrieve storage account from connection-string
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                CloudConfigurationManager.GetSetting("StorageConnectionString"));

            // Create the blob client
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            // Retrieve reference to a previously created container
            CloudBlobContainer container = blobClient.GetContainerReference("donnybrook");

            List<DHBlob> listBlobs = new List<DHBlob>();

            foreach (var i in container.ListBlobs())
            {
                DHBlob dhBlob = new DHBlob();
                dhBlob.blobURI = i.Uri.ToString();
                listBlobs.Add(dhBlob);
            }
            return View(listBlobs);
        }

        //
        // GET: /DHBlob/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /DHBlob/Create

        public ActionResult Create(string id)
        {
            // Retrieve storage account from connection-string
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                CloudConfigurationManager.GetSetting("StorageConnectionString"));

            // Create the blob client 
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            // Retrieve a reference to a container 
            //CloudBlobContainer container = blobClient.GetContainerReference(id value = postal address);
            CloudBlobContainer container = blobClient.GetContainerReference("donnybrook");

            // Create the container if it doesn't already exist
            container.CreateIfNotExist();

            container.SetPermissions(
                new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });

            // Retrieve reference to a blob named "DHMichaeln"
            CloudBlob blob = container.GetBlobReference("DHMichael7");

            // Create or overwrite the "dhblob" blob with contents from a local file
            using (var fileStream = System.IO.File.OpenRead(@id))
            {
                blob.UploadFromStream(fileStream);
            }

            return RedirectToAction("Index", new { id = id });
        } 

        //
        // POST: /DHBlob/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /DHBlob/Edit/5
 
        public ActionResult Edit(string id)
        {
            return View();
        }

        //
        // POST: /DHBlob/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /DHBlob/Delete/5
 
        public ActionResult Delete(string uri)
        {
            Uri uriCurrent = new Uri(uri);
            string currentContainer = uriCurrent.Segments[1];
            string currentBlob = uriCurrent.Segments[2];
            
            // Retrieve storage account from connection-string
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                CloudConfigurationManager.GetSetting("StorageConnectionString"));

            // Create the blob client
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            // Retrieve reference to a previously created container
            CloudBlobContainer container = blobClient.GetContainerReference(currentContainer);

            // Retrieve reference to a blob named "myblob"
            CloudBlob blob = container.GetBlobReference(currentBlob);

            // Delete the blob
            blob.Delete();

            return RedirectToAction("Index", new { id = currentContainer });
        }

        //
        // POST: /DHBlob/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // This action renders the form 
        public ActionResult GetFname()
        {
            return View();
        }

        // This action handles the form POST and the upload 
        [HttpPost]
        public ActionResult GetFname(HttpPostedFileBase file)
        {
            // Verify that the user selected a file 
            if (file != null && file.ContentLength > 0)
            {
                // string filePath = Path.GetFullPath(file.FileName);
                
                
                // extract only the fielname 
                string fileName = Path.GetFileName(file.FileName);
                // store the file inside ~/App_Data/uploads folder 
                //var path = Path.Combine(Server.MapPath("~/App_Data/uploads"), fileName);
                string filePath = Path.Combine(@"D:\Drawings", file.FileName);
                //save the file to our local path                

                // file.SaveAs(filePath);

                // Retrieve storage account from connection-string
                CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                    CloudConfigurationManager.GetSetting("StorageConnectionString"));

                // Create the blob client 
                CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

                // Retrieve a reference to a container 
                //CloudBlobContainer container = blobClient.GetContainerReference(id value = postal address);
                CloudBlobContainer container = blobClient.GetContainerReference("donnybrook");

                // Create the container if it doesn't already exist
                container.CreateIfNotExist();

                container.SetPermissions(
                    new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });

                // Retrieve reference to a blob named <fileName>
                CloudBlob blob = container.GetBlobReference(fileName);

                // Create or overwrite the "dhblob" blob with contents from a local file
                using (var fileStream = System.IO.File.OpenRead(@filePath))
                {
                    blob.UploadFromStream(fileStream);
                }

                
            }
            // redirect back to the index action to show the form once again 
            return RedirectToAction("Index", new { id = "donnybrook" });
        } 


        
    }
}
