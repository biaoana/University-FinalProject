using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using University.AppLogic.Models;

namespace University.DataAccess
{
    public class UniversityDbContext : DbContext
    { 
        public UniversityDbContext(DbContextOptions<UniversityDbContext> options)
          : base(options)
        {
        }
        public DbSet<Classroom> Classroom { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Require> Requires { get; set; }
        public DbSet<Assignments> Assignments { get; set; }
        public DbSet<Homework> Homeworks { get; set; }
        public DbSet<Grades> Grades  { get; set; }

    }
}

