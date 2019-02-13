using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prisoner.Test
{
    public class TestContext : DbContext
    {
        private readonly string _databasePath;

        public DbSet<Question> Questions { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<Answer> Answers { get; set; }

        public TestContext()
        {
            _databasePath = @"C:\Xamarin Projects\Prisoner\Prisoner.DataBase.Mirgration\db.sqlite";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={_databasePath}");
        }
    }
}
