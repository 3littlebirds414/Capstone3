using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ChoreChartThree.Models
{
    public class ChallengeRound
    {
        [Key]
        public int ChallengeRoundId { get; set; }
        public bool GuardianApproval { get; set; }
        public int ChallengeWinner { get; set; }

        [ForeignKey("dependent")]
        public int? DependentId { get; set; }
        public Dependent dependent { get; set; }

        [ForeignKey("image")]
        public int ImageId { get; set; }
        public Image image { get; set; }

        public IEnumerable<Image> Images { get; set; }
    }
}