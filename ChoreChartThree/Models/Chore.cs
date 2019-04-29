using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ChoreChartThree.Models
{
    public class Chore
    {

        [Key]
        public int ChoreId { get; set; }
        public string ChoreName { get; set; }
        public string Description { get; set; }
        public int ChorePointValue { get; set; }
        public DateTime ExpCompletionDate { get; set; }
        public bool GuardianApproved { get; set; }
        public string ChoreType { get; set; }

        [ForeignKey("dependent")]
        public int DependentId { get; set; }
        public Dependent dependent { get; set; }

        [ForeignKey("image")]
        public int ImageId { get; set; }
        public Image image { get; set; }

        public IEnumerable<Image> Images { get; set; }
    }
}