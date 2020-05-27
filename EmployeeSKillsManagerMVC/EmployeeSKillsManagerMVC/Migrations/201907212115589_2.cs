namespace EmployeeSKillsManagerMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.EmployeeSkillsMaster", "ModofiedDate", c => c.DateTime());
            AlterColumn("dbo.Employee", "CreatedDate", c => c.DateTime());
            DropColumn("dbo.Employee", "AcNo");
            DropColumn("dbo.Employee", "SSN");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employee", "SSN", c => c.String());
            AddColumn("dbo.Employee", "AcNo", c => c.String());
            AlterColumn("dbo.Employee", "CreatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.EmployeeSkillsMaster", "ModofiedDate", c => c.DateTime(nullable: false));
        }
    }
}
