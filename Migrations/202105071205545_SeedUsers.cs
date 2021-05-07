namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'129da7a9-d75b-4183-9cc3-c9acdcf40ecd', N'admin@vidly.com', 0, N'ANqK/2yELaafxJlBbL9bDD/wTn/hkGIQao1cEkxRQtegTy68ehWcaIXwbp3BXVji6Q==', N'40c10f7f-9c63-494c-8834-12bb838656b8', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'49a69611-c40f-416e-b11f-7b7c72b257d5', N'superuser@vidly.com', 0, N'AIZBN5w00nyWC8qDea/mj95n9hDL24yS70ad+tIkYEEEcti2G5JUywgLmYEL6oHYag==', N'14830f60-e430-4bb9-a0c0-d835bcab9ebb', NULL, 0, 0, NULL, 1, 0, N'superuser@vidly.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'87f9ecb4-8743-45b7-a818-e7718a682219', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'49a69611-c40f-416e-b11f-7b7c72b257d5', N'87f9ecb4-8743-45b7-a818-e7718a682219')

");
        }
        
        public override void Down()
        {
        }
    }
}
