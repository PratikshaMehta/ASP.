namespace EmployeeSkillsManager.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Department", "EmployeeID", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Department", "EmployeeID");
        }
    }
}
