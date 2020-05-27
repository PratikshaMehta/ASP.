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
 
    public class Skill : IObjectWithState
    {
        public Skill()
        {
            EmployeeSkills = new HashSet<EmployeeSkills>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SkillID { get; set; }

        [MaxLength(250)]
        [Column(Order =3, TypeName = "varchar")]     
        public string Description { get; set; } 


        [Required]
        [MaxLength(50)]
        [Column(TypeName = "varchar")]
        [Index(IsUnique =true)]

        [DisplayName("Skill Name")]
        public string Name { get; set; }



        [DisplayName("Date Skill Added")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime? DateSkillAdded{ get; set; }
        public ICollection<EmployeeSkills> EmployeeSkills { get; set; }

        [ForeignKey("Category")]
        public int SkillCategoryID { get; set; }
        public Category Category { get; set; }
        [NotMapped]
        public ObjectState ObjectState { get; set; }
    }
}