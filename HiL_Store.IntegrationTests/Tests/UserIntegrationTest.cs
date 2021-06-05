using HiL_Store.EntityFramework;
using Microsoft.AspNet.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HiL_Store.IntegrationTests.Tests
{

    [TestFixture()]
    public class UserIntegrationTest
    {
        private readonly HiLDbContext _context;
        public UserIntegrationTest()
        {
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkSqlServer()
                .BuildServiceProvider();

            var builder = new DbContextOptionsBuilder<HiLDbContext>();


            builder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=HIL_TEST_DB.MDF;Trusted_Connection=True;");

            _context = new HiLDbContext(builder.Options);
            _context.Database.Migrate();
        }

        [Test]
        public void User_AddUser_UsersIncreased()
        {

            _context.Users.Add(new Domain.Entities.User
            {
                Username = "testUser",
                Email = "test@gmail.com",
                DatedJoined = DateTime.Now,
                UserRole = "Admin",
                PasswordHash = "testPassword"
            });

            _context.SaveChanges();

            var a = _context.Users.ToList().FirstOrDefault(x => x.Username == "testUser");

            Assert.IsTrue(a.Username == "testUser");

            Dispose();
            _context.SaveChanges();
        }

        [Test]
        public void User_AddFourUsers_UsersIsAdded()
        {

            _context.Users.Add(new Domain.Entities.User
            {
                Username = "testUser",
                Email = "test@gmail.com",
                DatedJoined = DateTime.Now,
                UserRole = "Admin",
                PasswordHash = "testPassword"
            });

            _context.Users.Add(new Domain.Entities.User
            {
                Username = "testUser2",
                Email = "test@gmail.com",
                DatedJoined = DateTime.Now,
                UserRole = "Admin",
                PasswordHash = "testPassword"
            });

            _context.Users.Add(new Domain.Entities.User
            {
                Username = "testUser3",
                Email = "test@gmail.com",
                DatedJoined = DateTime.Now,
                UserRole = "Admin",
                PasswordHash = "testPassword"
            });

            _context.Users.Add(new Domain.Entities.User
            {
                Username = "testUser4",
                Email = "test@gmail.com",
                DatedJoined = DateTime.Now,
                UserRole = "Admin",
                PasswordHash = "testPassword"
            });

            _context.SaveChanges();

            var count = _context.Users.ToList().Count;

            Assert.IsTrue(count == 4);

            Dispose();

        }


        [Test]
        public void User_DeleteUser_OneLessUser()
        {

            _context.Users.Add(new Domain.Entities.User
            {
                Username = "testUser",
                Email = "test@gmail.com",
                DatedJoined = DateTime.Now,
                UserRole = "Admin",
                PasswordHash = "testPassword"
            });

            _context.Users.Add(new Domain.Entities.User
            {
                Username = "testUser2",
                Email = "test@gmail.com",
                DatedJoined = DateTime.Now,
                UserRole = "Admin",
                PasswordHash = "testPassword"
            });

            _context.SaveChanges();

            var countBeforeDelete = _context.Users.ToList().Count;

            var objectForDelete = _context.Users.ToList().FirstOrDefault(x => x.Username == "testUser2");

            _context.Users.Remove(objectForDelete);

            _context.SaveChanges();

            var countAfterDelete = _context.Users.ToList().Count;

            Assert.IsTrue(countAfterDelete == countBeforeDelete - 1);

            Dispose();

        }


        [Test]
        public void Quiz_UpdateUser_ChangedUserRole()
        {

            _context.Users.Add(new Domain.Entities.User
            {
                Username = "testUser",
                Email = "test@gmail.com",
                DatedJoined = DateTime.Now,
                UserRole = "Admin",
                PasswordHash = "testPassword"
            });

            _context.SaveChanges();

            var updatedCategory = _context.Users
                .Where(c => c.Username == "testUser")
                .FirstOrDefault();

            updatedCategory.UserRole = "User";

            _context.SaveChanges();

            Assert.IsTrue(updatedCategory.UserRole != "Admin");

            Dispose();

        }


        public void Dispose()
        {
            _context.Database.EnsureDeleted();

            _context.SaveChanges();
        }
    }
}
