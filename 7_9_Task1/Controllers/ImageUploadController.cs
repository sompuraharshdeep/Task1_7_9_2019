using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _7_9_Task1.Controllers
{
    public class ImageUploadController : Controller
    {
        // GET: ImageUpload
        public ActionResult UploadImage()
        {
            ViewBag.files = ReadImages();
            return View();
        }

        [HttpPost]
        public ActionResult UploadImage(HttpPostedFileBase[] fileBase)
        {
            try
            {
                string dirPath = Server.MapPath("~/Content/Images/");
                if (!Directory.Exists(dirPath))
                {
                    Directory.CreateDirectory(dirPath);
                }

                foreach (var fl in fileBase)
                {
                    string fn = Guid.NewGuid().ToString().Replace('-', '-');
                    string[] arr = fl.FileName.Split('.');
                    string ext = arr[arr.Length - 1];
                    string fileName = String.Format("img_{0}.{1}", fn, ext);
                    string filePath = dirPath + "\\" + fileName;
                    fl.SaveAs(filePath);
                }

                ViewBag.message = "Image/Images Uploaded!";

                ViewBag.files = ReadImages();

            }
            catch (Exception ex)
            {

                ViewBag.error = ex.Message;
            }
            return View();
        }

        public List<string> ReadImages()
        {

            string[] phisycalPath = Directory.GetFiles(Server.MapPath("~/Content/Images/"));
            List<string> filesPath = new List<string>();
            //TempData["files"] = phisycalPath;
            foreach (var flPath in phisycalPath)
            {
                string[] arr = flPath.Split('\\');
                string flName = arr[arr.Length - 1];
                filesPath.Add("/Content/Images/" + flName);
            }

            return filesPath;
        }
    }
}