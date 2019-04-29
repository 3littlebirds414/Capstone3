namespace ChoreChartThree.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Thing : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ChallengeRounds",
                c => new
                    {
                        ChallengeRoundId = c.Int(nullable: false, identity: true),
                        GuardianApproval = c.Boolean(nullable: false),
                        ChallengeWinner = c.Int(nullable: false),
                        DependentId = c.Int(),
                        ImageId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ChallengeRoundId)
                .ForeignKey("dbo.Dependents", t => t.DependentId)
                .ForeignKey("dbo.Images", t => t.ImageId, cascadeDelete: true)
                .Index(t => t.DependentId)
                .Index(t => t.ImageId);
            
            CreateTable(
                "dbo.Dependents",
                c => new
                    {
                        DependentId = c.Int(nullable: false, identity: true),
                        ChildAge = c.Int(nullable: false),
                        DependentName = c.String(),
                        ToDoList = c.String(),
                        BonusTask = c.String(),
                        CompletedSubmissionFilePath = c.String(),
                        PendingGuardianApproval = c.Boolean(nullable: false),
                        GuardianId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DependentId)
                .ForeignKey("dbo.Guardians", t => t.GuardianId, cascadeDelete: true)
                .Index(t => t.GuardianId);
            
            CreateTable(
                "dbo.Guardians",
                c => new
                    {
                        GuardianId = c.Int(nullable: false, identity: true),
                        GuardianName = c.String(nullable: false),
                        TaskApproval = c.Boolean(nullable: false),
                        ApplicationId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.GuardianId)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationId)
                .Index(t => t.ApplicationId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        ImageId = c.Int(nullable: false, identity: true),
                        ImageCatagory = c.String(),
                        ImageDescription = c.String(),
                        ImageTimeStamp = c.DateTime(nullable: false),
                        ImageFilePath = c.String(),
                    })
                .PrimaryKey(t => t.ImageId);
            
            CreateTable(
                "dbo.Chores",
                c => new
                    {
                        ChoreId = c.Int(nullable: false, identity: true),
                        ChoreName = c.String(),
                        Description = c.String(),
                        ChorePointValue = c.Int(nullable: false),
                        ExpCompletionDate = c.DateTime(nullable: false),
                        GuardianApproved = c.Boolean(nullable: false),
                        ChoreType = c.String(),
                        DependentId = c.Int(nullable: false),
                        ImageId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ChoreId)
                .ForeignKey("dbo.Dependents", t => t.DependentId, cascadeDelete: true)
                .ForeignKey("dbo.Images", t => t.ImageId, cascadeDelete: true)
                .Index(t => t.DependentId)
                .Index(t => t.ImageId);
            
            CreateTable(
                "dbo.RewardPlans",
                c => new
                    {
                        RewardPlanId = c.Int(nullable: false, identity: true),
                        AgeRange = c.String(),
                        AdjustmentFactor = c.Int(nullable: false),
                        AdjustedEarnings = c.Double(nullable: false),
                        GuardianId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RewardPlanId)
                .ForeignKey("dbo.Guardians", t => t.GuardianId, cascadeDelete: true)
                .Index(t => t.GuardianId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.RewardPlans", "GuardianId", "dbo.Guardians");
            DropForeignKey("dbo.Chores", "ImageId", "dbo.Images");
            DropForeignKey("dbo.Chores", "DependentId", "dbo.Dependents");
            DropForeignKey("dbo.ChallengeRounds", "ImageId", "dbo.Images");
            DropForeignKey("dbo.ChallengeRounds", "DependentId", "dbo.Dependents");
            DropForeignKey("dbo.Dependents", "GuardianId", "dbo.Guardians");
            DropForeignKey("dbo.Guardians", "ApplicationId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.RewardPlans", new[] { "GuardianId" });
            DropIndex("dbo.Chores", new[] { "ImageId" });
            DropIndex("dbo.Chores", new[] { "DependentId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Guardians", new[] { "ApplicationId" });
            DropIndex("dbo.Dependents", new[] { "GuardianId" });
            DropIndex("dbo.ChallengeRounds", new[] { "ImageId" });
            DropIndex("dbo.ChallengeRounds", new[] { "DependentId" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.RewardPlans");
            DropTable("dbo.Chores");
            DropTable("dbo.Images");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Guardians");
            DropTable("dbo.Dependents");
            DropTable("dbo.ChallengeRounds");
        }
    }
}
