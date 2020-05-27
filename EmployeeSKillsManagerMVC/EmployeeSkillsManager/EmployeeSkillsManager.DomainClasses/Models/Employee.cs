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
    public  class Employee : IObjectWithState
    {
        public Employee()
        {
            EmployeeSkills = new HashSet<EmployeeSkills>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeID { get; set; }

        [Required(ErrorMessage = "Enter Name")]
        [StringLength(100)]
        [DisplayName("Employee Name")]
        [Column(TypeName = "varchar")]

        public string Name { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(50)]
        [Required]
        public string Email { get; set; }

        public string Gender { get; set; }
        public string Contact { get; set; }      
        public string Designation { get; set; }

        [DisplayName("Total experience")]
        public double? TotalExp { get; set; }

               
        [ForeignKey("Department")]        
        public int EmployeeDepartmentID { get; set; }


        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        [DisplayName("Created Date")]
        public DateTime? CreatedDate { get; set; }
        
        public ICollection<EmployeeSkills> EmployeeSkills { get; set; }        

        public virtual Department Department { get; set; }

        [NotMapped]
        public ObjectState ObjectState { get; set; }
        //[ForeignKey("EmployeeAddress")]
        //public int EmployeeAddressId { get; set; }

        //public virtual EmployeeAddress EmployeeAddress { get; set; }

    }
}