using _7_9_Task1.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _7_9_Task1.Controllers
{
    public class ImageController : Controller
    {
        // GET: Image
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        // POST: Image
        [HttpPost]
        public ActionResult Add(ImageUpload imageUpload)
        {
            //Get Only Filename
            string filename = Path.GetFileNameWithoutExtension(imageUpload.ImageFile.FileName);

            //Get File Extension
            string extension = Path.GetExtension(imageUpload.ImageFile.FileName);

            //Combine all above things
            filename = filename + DateTime.Now.ToString("yymmssfff") + extension;

            //Get Relative Path of Image
            imageUpload.ImagePath = "~/Content/Images/" + filename;
            filename = Path.Combine(Server.MapPath("~/Content/Images/"),filename);

            //Save Image with Filename
            imageUpload.ImageFile.SaveAs(filename);
            ModelState.Clear();
            return View();
        }

        [HttpGet]
        public ActionResult ViewImage(int id)
        {
            ImageUpload imageUpload = new ImageUpload();
            return View(imageUpload);
        }
    }
}