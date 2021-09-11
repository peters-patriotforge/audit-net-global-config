namespace AuditNetGlobalConfig.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AuditLogs",
                c => new
                    {
                        AuditLogId = c.Int(nullable: false, identity: true),
                        AuditData = c.String(),
                        EntityType = c.String(),
                        AuditDate = c.DateTime(nullable: false),
                        AuditUserId = c.Int(),
                        TablePk = c.String(),
                        Comment = c.String(),
                    })
                .PrimaryKey(t => t.AuditLogId);
            
            CreateTable(
                "dbo.ShopOrderNotes",
                c => new
                    {
                        ShopOrderNoteId = c.Int(nullable: false, identity: true),
                        DataValue = c.String(),
                        CreatedDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ShopOrderNoteId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ShopOrderNotes");
            DropTable("dbo.AuditLogs");
        }
    }
}
