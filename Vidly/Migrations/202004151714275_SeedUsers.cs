namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'7663a722-0771-4ebd-a506-0a0a3f77788f', N'guest@vidly.com', 0, N'AJO5cpFLxnlNYKMl+6EQw4r7XNPjGbMI6fb5oNFwBZYDMf7zLLsiH2TPyDp89TVCtQ==', N'67aebe36-283c-48ba-ad60-3b7d927c7122', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'aa09d53d-a513-4d0f-bdc1-8d65b46de30f', N'admin@vidly.com', 0, N'APtCDtXJj1v9hWLiDXmWIlQHj0duYnm8wWFh7O7FPHCjQEmlMyMQfCIF0I3mVU3etQ==', N'4cdb9c70-1e20-430e-99ce-b1132b23718f', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')

                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'61087c86-570c-4f25-af6a-23ea7a92d6b4', N'CanManageMovies')
                
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'aa09d53d-a513-4d0f-bdc1-8d65b46de30f', N'61087c86-570c-4f25-af6a-23ea7a92d6b4')
            ");
        }

        public override void Down()
        {
        }
    }
}
