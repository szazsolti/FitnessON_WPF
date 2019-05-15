namespace FitnessON.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DatabaseFitness : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CardNumber = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Leases",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MixLeases_Id = c.Int(nullable: false),
                        Card_Id = c.Int(nullable: false),
                        StartValidity = c.String(),
                        EndValidity = c.String(),
                        NumberOfEntries = c.Int(nullable: false),
                        inUse = c.Boolean(nullable: false),
                        Card_Id1 = c.Int(),
                        MixLease_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cards", t => t.Card_Id1)
                .ForeignKey("dbo.MixLeases", t => t.MixLease_Id)
                .Index(t => t.Card_Id1)
                .Index(t => t.MixLease_Id);
            
            CreateTable(
                "dbo.MixLeases",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PeriodLease_Id = c.Int(nullable: false),
                        StartHour = c.Int(nullable: false),
                        EndHour = c.Int(nullable: false),
                        Days = c.String(),
                        NumberOfEntriesLease_Id = c.Int(nullable: false),
                        Enter_day = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                        Name = c.String(),
                        NumberOfEntriesLease_Id1 = c.Int(),
                        PeriodLease_Id1 = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.NumberOfEntriesLeases", t => t.NumberOfEntriesLease_Id1)
                .ForeignKey("dbo.PeriodLeases", t => t.PeriodLease_Id1)
                .Index(t => t.NumberOfEntriesLease_Id1)
                .Index(t => t.PeriodLease_Id1);
            
            CreateTable(
                "dbo.NumberOfEntriesLeases",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PeriodLeases",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NumberOfDays = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Logs",
                c => new
                    {
                        Log_Id = c.Int(nullable: false, identity: true),
                        Time = c.String(),
                        User_Id = c.Int(nullable: false),
                        Lease_Id = c.Int(nullable: false),
                        Message = c.String(),
                        Lease_Id1 = c.Int(),
                        User_Id1 = c.Int(),
                    })
                .PrimaryKey(t => t.Log_Id)
                .ForeignKey("dbo.Leases", t => t.Lease_Id1)
                .ForeignKey("dbo.Users", t => t.User_Id1)
                .Index(t => t.Lease_Id1)
                .Index(t => t.User_Id1);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                        Card_Id = c.Int(nullable: false),
                        Picture = c.String(),
                        Permission = c.String(),
                        Card_Id1 = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cards", t => t.Card_Id1)
                .Index(t => t.Card_Id1);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Logs", "User_Id1", "dbo.Users");
            DropForeignKey("dbo.Users", "Card_Id1", "dbo.Cards");
            DropForeignKey("dbo.Logs", "Lease_Id1", "dbo.Leases");
            DropForeignKey("dbo.Leases", "MixLease_Id", "dbo.MixLeases");
            DropForeignKey("dbo.MixLeases", "PeriodLease_Id1", "dbo.PeriodLeases");
            DropForeignKey("dbo.MixLeases", "NumberOfEntriesLease_Id1", "dbo.NumberOfEntriesLeases");
            DropForeignKey("dbo.Leases", "Card_Id1", "dbo.Cards");
            DropIndex("dbo.Users", new[] { "Card_Id1" });
            DropIndex("dbo.Logs", new[] { "User_Id1" });
            DropIndex("dbo.Logs", new[] { "Lease_Id1" });
            DropIndex("dbo.MixLeases", new[] { "PeriodLease_Id1" });
            DropIndex("dbo.MixLeases", new[] { "NumberOfEntriesLease_Id1" });
            DropIndex("dbo.Leases", new[] { "MixLease_Id" });
            DropIndex("dbo.Leases", new[] { "Card_Id1" });
            DropTable("dbo.Users");
            DropTable("dbo.Logs");
            DropTable("dbo.PeriodLeases");
            DropTable("dbo.NumberOfEntriesLeases");
            DropTable("dbo.MixLeases");
            DropTable("dbo.Leases");
            DropTable("dbo.Cards");
        }
    }
}
