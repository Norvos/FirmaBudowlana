﻿using FirmaBudowlana.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace FirmaBudowlana.Infrastructure.EF
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }

}
