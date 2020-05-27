using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace EmployeeSkillsManager.DomainClasses
{
    [Table(("EmployeeSkillsMaster"))]
    public class EmployeeSkills : IObjectWithState
    {

        [Key]
        [Column(Order = 0)]
        [ForeignKey("Employee")]
        public int EmployeeID { get; set; }

        [Key]
        [Column(Order = 1)]
        [ForeignKey("Skill")]
        public int SkillID { get; set; }

        [DisplayName("Skill Level")]
        public int SkillLevel { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        [DisplayName("Modified Date")]
        public DateTime? ModofiedDate { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Skill Skill { get; set; }
        [NotMapped]
        public ObjectState ObjectState { get; set; }
    }
}