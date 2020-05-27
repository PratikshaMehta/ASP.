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
    public class Category: IObjectWithState
    {
        public Category()
        {
            Skills = new HashSet<Skill>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryID { get; set; }

        [Required]
        [MaxLength(50)]

        [Column(TypeName = "varchar")]
        [DisplayName("Skill Category Name")]
        public string Name { get; set; }
        public ICollection<Skill> Skills
        {
            get; set;
        }
        [NotMapped]
        public ObjectState ObjectState { get; set; }
    }
}
