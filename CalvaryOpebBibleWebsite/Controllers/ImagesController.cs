using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CalvaryOpebBibleWebsite.DAL;
using CalvaryOpebBibleWebsite.Models;
using System.IO;
using PagedList;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage;
using System.Threading.Tasks;
using System.Configuration;

namespace CalvaryOpebBibleWebsite.Views
{
    //Tutorial used http://stackoverflow.com/questions/16255882/uploading-displaying-images-in-mvc-4
    public class ImagesController : Controller
    {
        public CalvaryContext db = new CalvaryContext();
     

        // GET: Images
        public ActionResult Index( int page =1, int pagesize =12)

        {

            List<Image> images = db.Image.ToList();
            PagedList<Image> model = new PagedList<Image>(images, page, pagesize);
            return View(model);
        
        }
        public ActionResult Videos(int page = 1, int pagesize = 12)
        {
            List<Image> images = db.Image.Where(d => d.Category == "Video").ToList();
            PagedList<Image> model = new PagedList<Image>(images, page, pagesize);
            return View(model);

        }

        public ActionResult Kids(int page = 1, int pagesize = 12)
        {
            List<Image> images = db.Image.Where(d => d.Category == "Kids").ToList();
            PagedList<Image> model = new PagedList<Image>(images, page, pagesize);
            return View(model);
        
        }
        public ActionResult YouthGroup(int page = 1, int pagesize = 12)
        {
            List<Image> images = db.Image.Where(d => d.Category == "Youth Group").ToList();
            PagedList<Image> model = new PagedList<Image>(images, page, pagesize);
            return View(model);
        }
        public ActionResult CommunityGroups(int page = 1, int pagesize = 12)
        {
            List<Image> images = db.Image.Where(d => d.Category == "Community Groups").ToList();
            PagedList<Image> model = new PagedList<Image>(images, page, pagesize);
            return View(model);
        }
        public ActionResult SundayChurch(int page = 1, int pagesize = 12)
        {
            List<Image> images = db.Image.Where(d => d.Category == "Sunday Church").ToList();
            PagedList<Image> model = new PagedList<Image>(images, page, pagesize);
            return View(model);
        }
        public ActionResult LiveStream()
        {
            return View();
        }
         [Authorize(Users = "jpoet1291@gmail.com,Parafin07!")]
        public ActionResult Admin(int page = 1, int pagesize = 12)
        {

            List<Image> images = db.Image.ToList();
            PagedList<Image> model = new PagedList<Image>(images, page, pagesize);
            return View(model);

        }
        // GET: Images/Details/5
        public ActionResult ViewImage(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Image image = db.Image.Find(id);
            if (image == null)
            {
                return HttpNotFound();
            }
            return View(image);
        }

        // GET: Images/Create
         [Authorize(Users = "jpoet1291@gmail.com,Parafin07!")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Users = "jpoet1291@gmail.com,Parafin07!")]
               public ActionResult Create([Bind(Include = "ImageID,Title,ImagePath,Details, Category")] Image img, HttpPostedFileBase file)
         {
             if (file != null)
             {
                 CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                     CalvaryOpebBibleWebsite.Properties.Settings.Default.StorageConnection);

                 CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
                 CloudBlobContainer container =
                     blobClient.GetContainerReference("video");

                 container.CreateIfNotExists();

                 container.SetPermissions(
                     new BlobContainerPermissions
                     {
                         PublicAccess = BlobContainerPublicAccessType.Container
                     });
 

                 CloudBlockBlob blob = container.GetBlockBlobReference(file.FileName);
                 blob.UploadFromStream(file.InputStream);

                 img.ImagePath = blob.Uri.ToString();
                 db.Image.Add(img);
                 db.SaveChanges();
             }
               
                return RedirectToAction("Admin");
           
        }
        // GET: Images/Edit/5
         [Authorize(Users = "jpoet1291@gmail.com,Parafin07!")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Image image = db.Image.Find(id);
            if (image == null)
            {
                return HttpNotFound();
            }
            return View(image);
        }

        // POST: Images/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
         [HttpPost]
         [ValidateAntiForgeryToken]
         [Authorize(Users = "jpoet1291@gmail.com,Parafin07!")]
         public ActionResult Edit([Bind(Include = "ID,Title,Details,Category,ImagePath")] Image img, HttpPostedFileBase file)
         {

             if (file != null)
             {
                 file.SaveAs(HttpContext.Server.MapPath("~/Content/Images/")
                                                       + file.FileName);
                 img.ImagePath = file.FileName;
             }
             db.Entry(img).State = EntityState.Modified;
             db.SaveChanges();
             return RedirectToAction("Admin");

         }

        // GET: Images/Delete/5
         [Authorize(Users = "jpoet1291@gmail.com,Parafin07!")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Image image = db.Image.Find(id);
            if (image == null)
            {
                return HttpNotFound();
            }
            return View(image);
        }

        // POST: Images/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Users = "jpoet1291@gmail.com,Parafin07!")]
        public ActionResult DeleteConfirmed(int id)
        {
            Image image = db.Image.Find(id);
            db.Image.Remove(image);
            db.SaveChanges();
            return RedirectToAction("Admin");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
