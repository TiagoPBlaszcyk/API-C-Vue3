﻿using Microsoft.EntityFrameworkCore;

namespace API.Model.Context
{
    public class MySQLContext : DbContext
    {
        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options)
        {

        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Permission> Permissions { get; set; }

    }
}
