using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ChoreChartThree.Models
{
    public class Guardian
    {
        [Key]
        public int GuardianId { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string GuardianName { get; set; }
        public bool? TaskApproval { get; set; }


        [ForeignKey("ApplicationUser")]
        public string ApplicationId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}