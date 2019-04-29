using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ChoreChartThree.Models
{
    public class Image
    {
        [Key]
        public int ImageId { get; set; }
        public string ImageCatagory { get; set; }
        public string ImageDescription { get; set; }
        public DateTime ImageTimeStamp { get; set; }
        public string ImageFilePath { get; set; }
    }
}