
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ManageMyStuff.Models.Learning
{
    public class LearningPlan
    {
        public int LearningPlanID { get; set; }

        [Required]
        [MaxLength(25)]
        [Column(TypeName = "varchar")]
        public string Subject { get; set; }

        [Required]
        public string Goal { get; set; }

        public string Notes { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public List<LearningPlanAction> LearningPlanActions { get; set; }
    }
}