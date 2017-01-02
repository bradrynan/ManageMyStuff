using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ManageMyStuff.Models.Learning
{
    public class LearningPlanAction
    {
        public LearningPlan LearningPlan { get; set; }

        public int LearningPlanActionID { get; set; }

        public string Description { get; set; }

        [Required]
        [MaxLength(25)]
        [Column(TypeName = "varchar")]
        // [AssertThat("Status IN('ACTIVE', 'COMPLETE', 'ON HOLD')")]
        public string Status { get; set; }

    }
}