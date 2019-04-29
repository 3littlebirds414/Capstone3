using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ChoreChartThree.Models
{
    public class RewardPlan
    {
        [Key]
        public int RewardPlanId { get; set; }
        public string AgeRange { get; set; }
        public int AdjustmentFactor { get; set; }
        public double AdjustedEarnings { get; set; }

        [ForeignKey("guardian")]
        public int GuardianId { get; set; }
        public Guardian guardian { get; set; }
    }
}