using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace _7_9_Task1.Models
{
    public class ImageUpload
    {
        public int ImageId { get; set; }
        //public string ImageTitle { get; set; }

        [DisplayName("Upload Files")]
        public string ImagePath { get; set; }

        public HttpPostedFileBase ImageFile { get; set; }
    }
}