namespace EmployeeSKillsManagerMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SkillsCategory",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.Skill",
                c => new
                    {
                        Description = c.String(maxLength: 250, unicode: false),
                        SkillID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50, unicode: false),
                        DateSkillAdded = c.DateTime(),
                        SkillCategoryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SkillID)
                .ForeignKey("dbo.SkillsCategory", t => t.SkillCategoryID, cascadeDelete: true)
                .Index(t => t.Name, unique: true)
                .Index(t => t.SkillCategoryID);
            
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        EmployeeID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100, unicode: false),
                        Email = c.String(nullable: false, maxLength: 50, unicode: false),
                        Gender = c.String(),
                        Contact = c.String(),
                        Designation = c.String(),
                        TotalExp = c.Double(),
                        AcNo = c.String(),
                        SSN = c.String(),
                        EmployeeDepartmentID = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeID)
                .ForeignKey("dbo.Department", t => t.EmployeeDepartmentID, cascadeDelete: true)
                .Index(t => t.EmployeeDepartmentID);
            
            CreateTable(
                "dbo.Department",
                c => new
                    {
                        DepartmentID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.DepartmentID);
            
            CreateTable(
                "dbo.EmployeeSkills",
                c => new
                    {
                        Employee_EmployeeID = c.Int(nullable: false),
                        Skill_SkillID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Employee_EmployeeID, t.Skill_SkillID })
                .ForeignKey("dbo.Employee", t => t.Employee_EmployeeID, cascadeDelete: true)
                .ForeignKey("dbo.Skill", t => t.Skill_SkillID, cascadeDelete: true)
                .Index(t => t.Employee_EmployeeID)
                .Index(t => t.Skill_SkillID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Skill", "SkillCategoryID", "dbo.SkillsCategory");
            DropForeignKey("dbo.EmployeeSkills", "Skill_SkillID", "dbo.Skill");
            DropForeignKey("dbo.EmployeeSkills", "Employee_EmployeeID", "dbo.Employee");
            DropForeignKey("dbo.Employee", "EmployeeDepartmentID", "dbo.Department");
            DropIndex("dbo.EmployeeSkills", new[] { "Skill_SkillID" });
            DropIndex("dbo.EmployeeSkills", new[] { "Employee_EmployeeID" });
            DropIndex("dbo.Employee", new[] { "EmployeeDepartmentID" });
            DropIndex("dbo.Skill", new[] { "SkillCategoryID" });
            DropIndex("dbo.Skill", new[] { "Name" });
            DropTable("dbo.EmployeeSkills");
            DropTable("dbo.Department");
            DropTable("dbo.Employee");
            DropTable("dbo.Skill");
            DropTable("dbo.SkillsCategory");
        }
    }
}
