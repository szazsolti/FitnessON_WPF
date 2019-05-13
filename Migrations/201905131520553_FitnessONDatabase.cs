namespace FitnessON.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class FitnessONDB : DbMigration
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
                    StartValidity = c.Long(nullable: false),
                    EndValidity = c.Long(nullable: false),
                    NumberOfEntries = c.Int(nullable: false),

                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cards", t => t.Card_Id)
                .ForeignKey("dbo.MixLeases", t => t.MixLeases_Id)
                .Index(t => t.Card_Id)
                .Index(t => t.MixLeases_Id);

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

                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.NumberOfEntriesLeases", t => t.NumberOfEntriesLease_Id)
                .ForeignKey("dbo.PeriodLeases", t => t.PeriodLease_Id)
                .Index(t => t.NumberOfEntriesLease_Id)
                .Index(t => t.PeriodLease_Id);

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
                    Time = c.Long(nullable: false),
                    User_Id = c.Int(nullable: false),
                    Lease_Id = c.Int(nullable: false),
                    Message = c.String(),

                })
                .PrimaryKey(t => t.Log_Id)
                .ForeignKey("dbo.Leases", t => t.Lease_Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.Lease_Id)
                .Index(t => t.User_Id);

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

                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cards", t => t.Card_Id)
                .Index(t => t.Card_Id);

        }

        public override void Down()
        {
            DropForeignKey("dbo.Logs", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Users", "Card_Id", "dbo.Cards");
            DropForeignKey("dbo.Logs", "Lease_Id", "dbo.Leases");
            DropForeignKey("dbo.Leases", "MixLeases_Id", "dbo.MixLeases");
            DropForeignKey("dbo.MixLeases", "PeriodLease_Id", "dbo.PeriodLeases");
            DropForeignKey("dbo.MixLeases", "NumberOfEntriesLease_Id", "dbo.NumberOfEntriesLeases");
            DropForeignKey("dbo.Leases", "Card_Id", "dbo.Cards");
            DropIndex("dbo.Users", new[] { "Card_Id" });
            DropIndex("dbo.Logs", new[] { "User_Id" });
            DropIndex("dbo.Logs", new[] { "Lease_Id" });
            DropIndex("dbo.MixLeases", new[] { "PeriodLease_Id" });
            DropIndex("dbo.MixLeases", new[] { "NumberOfEntriesLease_Id" });
            DropIndex("dbo.Leases", new[] { "MixLeases_Id" });
            DropIndex("dbo.Leases", new[] { "Card_Id" });
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
