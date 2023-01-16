﻿using EduSync_Admin_Portal.Model;
using Microsoft.EntityFrameworkCore;

namespace EduSync_Admin_Portal.Data
{
    public class EduSyncDbContext : DbContext
    {
        public EduSyncDbContext(DbContextOptions<EduSyncDbContext> options) : base(options) { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Gender> Gender { get; set; }
    }
}
