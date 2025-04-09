using ConsoleApp1.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ConsoleApp1.DAL.Data
{
    public class AppDbContext : DbContext
    {
        private string _connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=UA;Integrated Security=True;Connect Timeout=30;";

        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);

        }
    }
}
