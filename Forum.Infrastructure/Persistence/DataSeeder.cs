using Forum.Core.Common.Enums;
using Forum.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Forum.Infrastructure.Persistence
{
    public static class DataSeeder
    {
        public static void SeedTopics(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Topic>().HasData(
                    new Topic
                    {
                        Id = 1,
                        Title = "Topic 1",
                        CreationDate = DateTime.Now,
                        State = State.Pending,
                        Status = Status.Active,
                        UserId = "D514EDC9-94BB-416F-AF9D-7C13669689C9"
                    },
                    new Topic
                    {
                        Id = 2,
                        Title = "Topic 2",
                        CreationDate = DateTime.Now.AddHours(1),
                        State = State.Pending,
                        Status = Status.Active,
                        UserId = "D514EDC9-94BB-416F-AF9D-7C13669689C9"
                    },
                    new Topic
                    {
                        Id = 3,
                        Title = "Topic 3",
                        CreationDate = DateTime.Now.AddHours(2),
                        State = State.Pending,
                        Status = Status.Active,
                        UserId = "87746F88-DC38-4756-924A-B95CFF3A1D8A"
                    }
                );
        }
        public static void SeedComments(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comment>().HasData(
                    new Comment()
                    {
                        Id = 1,
                        Text = "Comment 1",
                        CreationDate = DateTime.Now,
                        TopicId = 1,
                        UserId = "87746F88-DC38-4756-924A-B95CFF3A1D8A"
                    },
                    new Comment()
                    {
                        Id = 2,
                        Text = "Comment 2",
                        CreationDate = DateTime.Now.AddMinutes(20),
                        TopicId = 3,
                        UserId = "87746F88-DC38-4756-924A-B95CFF3A1D8A"
                    },
                    new Comment()
                    {
                        Id = 3,
                        Text = "Comment 3",
                        CreationDate = DateTime.Now.AddMinutes(50),
                        TopicId = 3,
                        UserId = "D514EDC9-94BB-416F-AF9D-7C13669689C9"
                    },
                    new Comment()
                    {
                        Id = 4,
                        Text = "Comment 4",
                        CreationDate = DateTime.Now.AddDays(1),
                        TopicId = 2,
                        UserId = "D514EDC9-94BB-416F-AF9D-7C13669689C9"
                    }
                );
        }
        public static void SeedRoles(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityRole>().HasData(
                    new IdentityRole
                    {
                        Id = "23E09CB1-2908-4335-9883-EAE4BA5447CE",
                        Name = "Admin",
                        NormalizedName = "ADMIN"
                    },
                    new IdentityRole
                    {
                        Id = "EF3EA9BD-EED4-4030-ACC6-D5EAB5AFCD2B",
                        Name = "Customer",
                        NormalizedName = "CUSTOMER"
                    }
                );
        }
        public static void SeedUsers(this ModelBuilder modelBuilder)
        {
            PasswordHasher<IdentityUser> hasher = new();
            modelBuilder.Entity<IdentityUser>().HasData(
                    new IdentityUser()
                    {
                        Id = "8716071C-1D9B-48FD-B3D0-F059C4FB8031",
                        UserName = "admin@gmail.com",
                        NormalizedUserName = "ADMIN@GMAIL.COM",
                        Email = "admin@gmail.com",
                        NormalizedEmail = "ADMIN@GMAIL.COM",
                        EmailConfirmed = false,
                        PasswordHash = hasher.HashPassword(null!, "Admin123!"),
                        PhoneNumber = "555337681",
                        PhoneNumberConfirmed = false,
                        TwoFactorEnabled = false,
                        LockoutEnd = null,
                        LockoutEnabled = true,
                        AccessFailedCount = 0
                    },
                    new IdentityUser()
                    {
                        Id = "D514EDC9-94BB-416F-AF9D-7C13669689C9",
                        UserName = "nika@gmail.com",
                        NormalizedUserName = "NIKA@GMAIL.COM",
                        Email = "nika@gmail.com",
                        NormalizedEmail = "NIKA@GMAIL.COM",
                        EmailConfirmed = false,
                        PasswordHash = hasher.HashPassword(null!, "Nika123!"),
                        PhoneNumber = "558490645",
                        PhoneNumberConfirmed = false,
                        TwoFactorEnabled = false,
                        LockoutEnd = null,
                        LockoutEnabled = true,
                        AccessFailedCount = 0
                    },
                    new IdentityUser()
                    {
                        Id = "87746F88-DC38-4756-924A-B95CFF3A1D8A",
                        UserName = "gio@gmail.com",
                        NormalizedUserName = "GIO@GMAIL.COM",
                        Email = "gio@gmail.com",
                        NormalizedEmail = "GIO@GMAIL.COM",
                        EmailConfirmed = false,
                        PasswordHash = hasher.HashPassword(null!, "Gio123!"),
                        PhoneNumber = "551442269",
                        PhoneNumberConfirmed = false,
                        TwoFactorEnabled = false,
                        LockoutEnd = null,
                        LockoutEnabled = true,
                        AccessFailedCount = 0
                    }
                );
        }
        public static void SeedUserRoles(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                    new IdentityUserRole<string> { RoleId = "23E09CB1-2908-4335-9883-EAE4BA5447CE", UserId = "8716071C-1D9B-48FD-B3D0-F059C4FB8031" },
                    new IdentityUserRole<string> { RoleId = "EF3EA9BD-EED4-4030-ACC6-D5EAB5AFCD2B", UserId = "D514EDC9-94BB-416F-AF9D-7C13669689C9" },
                    new IdentityUserRole<string> { RoleId = "EF3EA9BD-EED4-4030-ACC6-D5EAB5AFCD2B", UserId = "87746F88-DC38-4756-924A-B95CFF3A1D8A" }
                );
        }
    }
}
