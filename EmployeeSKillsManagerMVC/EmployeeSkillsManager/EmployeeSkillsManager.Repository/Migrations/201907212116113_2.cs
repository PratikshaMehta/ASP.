namespace EmployeeSkillsManager.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.EmployeeSkillsMaster", "ModofiedDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.EmployeeSkillsMaster", "ModofiedDate", c => c.DateTime(nullable: false));
        }
    }
}
