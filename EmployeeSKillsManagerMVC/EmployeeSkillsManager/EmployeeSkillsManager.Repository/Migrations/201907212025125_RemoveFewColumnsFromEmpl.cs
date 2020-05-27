namespace EmployeeSkillsManager.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveFewColumnsFromEmpl : DbMigration
    {
        public override void Up()
        {
           

            DropColumn("dbo.Employee", "AcNo");
            DropColumn("dbo.Employee", "SSN");

        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.EmployeeSkills",
                c => new
                    {
                        Employee_EmployeeID = c.Int(nullable: false),
                        Skill_SkillID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Employee_EmployeeID, t.Skill_SkillID });
            
            AddColumn("dbo.Employee", "SSN", c => c.String());
            AddColumn("dbo.Employee", "AcNo", c => c.String());
            AddColumn("dbo.Employee", "Address", c => c.String());
            DropForeignKey("dbo.Employee", "EmployeeDepartmentID", "dbo.Department");
            DropForeignKey("dbo.EmployeeSkillsMaster", "SkillID", "dbo.Skill");
            DropForeignKey("dbo.EmployeeSkillsMaster", "EmployeeID", "dbo.Employee");
            DropIndex("dbo.Employee", new[] { "EmployeeDepartmentID" });
            DropIndex("dbo.EmployeeSkillsMaster", new[] { "SkillID" });
            DropIndex("dbo.EmployeeSkillsMaster", new[] { "EmployeeID" });
            AlterColumn("dbo.Employee", "EmployeeDepartmentID", c => c.Int());
            AlterColumn("dbo.Employee", "CreatedDate", c => c.DateTime(nullable: false));
            DropTable("dbo.EmployeeSkillsMaster");
            RenameColumn(table: "dbo.Employee", name: "EmployeeDepartmentID", newName: "Department_DepartmentID");
            CreateIndex("dbo.EmployeeSkills", "Skill_SkillID");
            CreateIndex("dbo.EmployeeSkills", "Employee_EmployeeID");
            CreateIndex("dbo.Employee", "Department_DepartmentID");
            AddForeignKey("dbo.Employee", "Department_DepartmentID", "dbo.Department", "DepartmentID");
            AddForeignKey("dbo.EmployeeSkills", "Skill_SkillID", "dbo.Skill", "SkillID", cascadeDelete: true);
            AddForeignKey("dbo.EmployeeSkills", "Employee_EmployeeID", "dbo.Employee", "EmployeeID", cascadeDelete: true);
        }
    }
}
