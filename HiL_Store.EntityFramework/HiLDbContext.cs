using HiL_Store.Domain.Entities;
using HiL_Store.Domain.Entities.QuizEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HiL_Store.EntityFramework
{
    public class HiLDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<CategoryQuiz> CategoryQuizzes { get; set; }
        public DbSet<CountQuestions> CountOfQuestions { get; set; }
        public DbSet<UserResult> UserResults { get; set; }


        public HiLDbContext(DbContextOptions options) : base(options)
        {

        }

    }
}
