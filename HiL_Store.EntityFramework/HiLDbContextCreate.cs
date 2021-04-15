using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HiL_Store.EntityFramework
{
    public class HiLDbContextCreate
    {
        private readonly string _connectionString;

        public HiLDbContextCreate(string connectionString)
        {
            _connectionString = connectionString;
        }

        public HiLDbContext CreateDbContext()
        {
            DbContextOptionsBuilder<HiLDbContext> options = new DbContextOptionsBuilder<HiLDbContext>();

            options.UseSqlServer(_connectionString);

            return new HiLDbContext(options.Options);
        }
    }
}
