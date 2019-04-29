using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ChoreChartThree.Models
{
    public class Dependent
    {
        [Key]
        public int DependentId { get; set; }
        public int ChildAge { get; set; }
        public string DependentName { get; set; }
        public string ToDoList { get; set; }
        public string BonusTask { get; set; }
        public string CompletedSubmissionFilePath { get; set; }
        public bool PendingGuardianApproval { get; set; }

        //// This is Mike approved!
        [ForeignKey("guardian")]
        public int GuardianId { get; set; }
        public Guardian guardian { get; set; }
    }
}