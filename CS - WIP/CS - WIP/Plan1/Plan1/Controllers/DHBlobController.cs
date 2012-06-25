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
            CloudBlobContainer container = blobClient.GetContainerReference(id);

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
            //CloudBlobContainer container = blobClient.GetContainerReference(iContainer value = postal address);
            CloudBlobContainer container = blobClient.GetContainerReference(id);

            // Create the container if it doesn't already exist
            container.CreateIfNotExist();

            container.SetPermissions(
                new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });

            // Retrieve reference to a blob named "DHMichael1"
            CloudBlob blob = container.GetBlobReference("DHMichael1");

            // Create or overwrite the "dhblob" blob with contents from a local file
            using (var fileStream = System.IO.File.OpenRead(@"logo.png"))
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
 
        public ActionResult Edit(int id)
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
 
        public ActionResult Delete(int id)
        {
            return View();
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

        
    }
}
