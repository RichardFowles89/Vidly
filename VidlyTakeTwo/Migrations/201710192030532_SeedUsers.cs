namespace VidlyTakeTwo.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'88558c04-2805-4c80-b9a1-e62e836e7a87', N'admin1@vidly.com', 0, N'AA/13R6uT6rnVy0mnR3RGyHdfUYJie1fjjZc8ts8clmzUkVlEgy8QWR0GBN/c5Oqkw==', N'a95bf9c1-a68c-4c8c-987a-396d178bec08', NULL, 0, 0, NULL, 1, 0, N'admin1@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'7bdcb598-5657-4f96-a85c-767591fbfe36', N'guest@vidly.com', 0, N'AIDRMlB2yGgtJ0RTkyk7NMT6GtDkZ8c9MuVEdUPU4uHZst9/bsIdb0pv7gVSkzajvg==', N'a709e161-ef3d-464c-9562-587630a0cbec', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'9a68b93c-cff4-4391-ad2d-4b7ab9751522', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'88558c04-2805-4c80-b9a1-e62e836e7a87', N'9a68b93c-cff4-4391-ad2d-4b7ab9751522')

");
        }

        public override void Down()
        {
        }
    }
}
