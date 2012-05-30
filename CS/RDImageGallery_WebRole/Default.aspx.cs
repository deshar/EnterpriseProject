// ----------------------------------------------------------------------------------
// Microsoft Developer & Platform Evangelism
// 
// Copyright (c) Microsoft Corporation. All rights reserved.
// 
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES 
// OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// ----------------------------------------------------------------------------------
// The example companies, organizations, products, domain names,
// e-mail addresses, logos, people, places, and events depicted
// herein are fictitious.  No association with any real company,
// organization, product, domain name, email address, logo, person,
// places, or events is intended or should be inferred.
// ----------------------------------------------------------------------------------

namespace RDImageGallery_WebRole
{
    using Microsoft.WindowsAzure;
    using Microsoft.WindowsAzure.ServiceRuntime;
    using Microsoft.WindowsAzure.StorageClient;
    using Microsoft.WindowsAzure.StorageClient.Protocol;
    using System;
    using System.Collections.Specialized;
    using System.Configuration;
    using System.Linq;
    using System.Web.UI.WebControls;

    public partial class _Default : System.Web.UI.Page
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    this.EnsureContainerExists();
                }
                this.RefreshGallery();
            }
            catch (System.Net.WebException we)
            {
                status.Text = "Network error: " + we.Message;
                if (we.Status == System.Net.WebExceptionStatus.ConnectFailure)
                {
                    status.Text += "<br />Please check if the blob service is running at " +
                    ConfigurationManager.AppSettings["storageEndpoint"];
                }
            }
            catch (StorageException se)
            {
                Console.WriteLine("Storage service error: " + se.Message);
            }
        }

        protected void upload_Click(object sender, EventArgs e)
        {
            if (imageFile.HasFile)
            {
                status.Text = "Inserted [" + imageFile.FileName + "] - Content Type [" + imageFile.PostedFile.ContentType + "] - Length [" + imageFile.PostedFile.ContentLength + "]";
                this.SaveImage(
                  Guid.NewGuid().ToString(),
                  imageName.Text,
                  imageDescription.Text,
                  imageTags.Text,
                  imageFile.FileName,
                  imageFile.PostedFile.ContentType,
                  imageFile.FileBytes
                );
                RefreshGallery();
            }
            else
                status.Text = "No image file";
        }

        /// <summary>
        /// Cast out blob instance and bind it's metadata to metadata repeater
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void OnBlobDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                var metadataRepeater = e.Item.FindControl("blobMetadata") as Repeater;
                var blob = ((ListViewDataItem)(e.Item)).DataItem as CloudBlob;

                // If this blob is a snapshot, rename button to "Delete Snapshot"
                if (blob != null)
                {
                    if (blob.SnapshotTime.HasValue)
                    {
                        var delBtn = e.Item.FindControl("deleteBlob") as LinkButton;

                        if (delBtn != null)
                        {
                            delBtn.Text = "Delete Snapshot";
                            var snapshotRequest = BlobRequest.Get(new Uri(delBtn.CommandArgument), 0, blob.SnapshotTime.Value, null);
                            delBtn.CommandArgument = snapshotRequest.RequestUri.AbsoluteUri;
                        }

                        var snapshotBtn = e.Item.FindControl("SnapshotBlob") as LinkButton;
                        if (snapshotBtn != null) snapshotBtn.Visible = false;
                    }

                    if (metadataRepeater != null)
                    {
                        //bind to metadata
                        metadataRepeater.DataSource = from key in blob.Metadata.AllKeys
                                                      select new
                                                      {
                                                          Name = key,
                                                          Value = blob.Metadata[key]
                                                      };
                        metadataRepeater.DataBind();
                    }
                }
            }
        }

        /// <summary>
        /// Delete an image blob by Uri
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void OnDeleteImage(object sender, CommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Delete")
                {
                    var blobUri = (string)e.CommandArgument;
                    var blob = this.GetContainer().GetBlobReference(blobUri);
                    blob.DeleteIfExists();
                }
            }
            catch (StorageClientException se)
            {
                status.Text = "Storage client error: " + se.Message;
            }
            catch (Exception) { }
            RefreshGallery();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void OnCopyImage(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "Copy")
            {
                // Prepare an Id for the copied blob
                var newId = Guid.NewGuid();
                // Get source blob
                var blobUri = (string)e.CommandArgument;
                var srcBlob = this.GetContainer().GetBlobReference(blobUri);
                // Create new blob
                var newBlob = this.GetContainer().GetBlobReference(newId.ToString());
                // Copy content from source blob
                newBlob.CopyFromBlob(srcBlob);
                // Explicitly get metadata for new blob
                newBlob.FetchAttributes(new BlobRequestOptions { BlobListingDetails = BlobListingDetails.Metadata });
                // Change metadata on the new blob to reflect this is a copy via UI
                newBlob.Metadata["ImageName"] = "Copy of \"" + newBlob.Metadata["ImageName"] + "\"";
                newBlob.Metadata["Id"] = newId.ToString();
                newBlob.SetMetadata();
                // Render all blobs
                RefreshGallery();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void OnSnapshotImage(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "Snapshot")
            {
                // Get source blob
                var blobUri = (string)e.CommandArgument;
                var srcBlob = this.GetContainer().GetBlobReference(blobUri);
                // Create a snapshot
                var snapshot = srcBlob.CreateSnapshot();
                status.Text = "A snapshot has been taken for image blob:" + srcBlob.Uri + " at " + snapshot.SnapshotTime;
                RefreshGallery();
            }
        }
        private void EnsureContainerExists()
        {
            var container = GetContainer();
            container.CreateIfNotExist();
            var permissions = container.GetPermissions();
            permissions.PublicAccess = BlobContainerPublicAccessType.Container;
            container.SetPermissions(permissions);
        }
        private CloudBlobContainer GetContainer()
        {
            // Get a handle on account, create a blob service client and get container proxy
            var account = CloudStorageAccount.FromConfigurationSetting("DataConnectionString");
            var client = account.CreateCloudBlobClient();
            return client.GetContainerReference(RoleEnvironment.GetConfigurationSettingValue("ContainerName"));
        }
        private void RefreshGallery()
        {
            images.DataSource =
              this.GetContainer().ListBlobs(new BlobRequestOptions()
              {
                  UseFlatBlobListing = true,
                  BlobListingDetails = BlobListingDetails.All
              });
            images.DataBind();
        }
        private void SaveImage(string id, string name, string description, string tags, string fileName, string contentType, byte[] data)
        {
            // Create a blob in container and upload image bytes to it
            var blob = this.GetContainer().GetBlobReference("gallery");
            blob.Properties.ContentType = contentType;
            // Create some metadata for this image
            var metadata = new NameValueCollection();
            metadata["Id"] = id;
            metadata["Filename"] = fileName;
            metadata["ImageName"] = String.IsNullOrEmpty(name) ? "unknown" : name;
            metadata["Description"] = String.IsNullOrEmpty(description) ? "unknown" : description;
            metadata["Tags"] = String.IsNullOrEmpty(tags) ? "unknown" : tags;
            // Add and commit metadata to blob
            blob.Metadata.Add(metadata);
            blob.UploadByteArray(data);
        }
    }
}