namespace Weather.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitalCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "appSchema.WeatherReports",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Location = c.String(nullable: false, maxLength: 255),
                        Timestamp = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "appSchema.Forecasts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Time = c.DateTime(nullable: false),
                        Weather = c.Int(nullable: false),
                        WeatherReport_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("appSchema.WeatherReports", t => t.WeatherReport_Id)
                .Index(t => t.WeatherReport_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("appSchema.Forecasts", "WeatherReport_Id", "appSchema.WeatherReports");
            DropIndex("appSchema.Forecasts", new[] { "WeatherReport_Id" });
            DropTable("appSchema.Forecasts");
            DropTable("appSchema.WeatherReports");
        }
    }
}
