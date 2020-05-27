using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace EmployeeSkillsManager.DomainClasses
{
    public class Department: IObjectWithState
    {
        public Department()
        {
            Employees = new HashSet<Employee>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DepartmentID { get; set; }

        [Required]
        [MaxLength(50)]
        [Column(TypeName = "varchar")]
         [DisplayName("Department Name")]
        public string Name { get; set; }

        [ForeignKey("Employees")]
        public string EmployeeID { get; set; }
        public ICollection<Employee> Employees
        {
            get; set;
        }
        [NotMapped]
        public ObjectState ObjectState { get; set; }
    }
}