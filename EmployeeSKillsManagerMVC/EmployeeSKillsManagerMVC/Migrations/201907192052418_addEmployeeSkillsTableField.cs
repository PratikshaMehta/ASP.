namespace EmployeeSKillsManagerMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addEmployeeSkillsTableField : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.EmployeeSkills", "Employee_EmployeeID", "dbo.Employee");
            DropForeignKey("dbo.EmployeeSkills", "Skill_SkillID", "dbo.Skill");
            DropIndex("dbo.EmployeeSkills", new[] { "Employee_EmployeeID" });
            DropIndex("dbo.EmployeeSkills", new[] { "Skill_SkillID" });
            CreateTable(
                "dbo.EmployeeSkillsMaster",
                c => new
                    {
                        EmployeeID = c.Int(nullable: false),
                        SkillID = c.Int(nullable: false),
                        SkillLevel = c.Int(nullable: false),
                        ModofiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.EmployeeID, t.SkillID })
                .ForeignKey("dbo.Employee", t => t.EmployeeID, cascadeDelete: true)
                .ForeignKey("dbo.Skill", t => t.SkillID, cascadeDelete: true)
                .Index(t => t.EmployeeID)
                .Index(t => t.SkillID);
            
            DropTable("dbo.EmployeeSkills");
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
            
            DropForeignKey("dbo.EmployeeSkillsMaster", "SkillID", "dbo.Skill");
            DropForeignKey("dbo.EmployeeSkillsMaster", "EmployeeID", "dbo.Employee");
            DropIndex("dbo.EmployeeSkillsMaster", new[] { "SkillID" });
            DropIndex("dbo.EmployeeSkillsMaster", new[] { "EmployeeID" });
            DropTable("dbo.EmployeeSkillsMaster");
            CreateIndex("dbo.EmployeeSkills", "Skill_SkillID");
            CreateIndex("dbo.EmployeeSkills", "Employee_EmployeeID");
            AddForeignKey("dbo.EmployeeSkills", "Skill_SkillID", "dbo.Skill", "SkillID", cascadeDelete: true);
            AddForeignKey("dbo.EmployeeSkills", "Employee_EmployeeID", "dbo.Employee", "EmployeeID", cascadeDelete: true);
        }
    }
}
