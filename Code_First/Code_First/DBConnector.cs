using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_First
{

    public class DBConnector : DbContext
    {
        public DbSet<Class> Subjects { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Professor> Professors { get; set; }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            try
            {
                optionsBuilder.UseMySql("Server=localhost;Database=testorm;User=Remote;Password=Kode1234!;",
                    new MySqlServerVersion(new Version(8, 0, 26)));
            }
            catch (Exception e) 
            { 
                Console.WriteLine(e);
            }
        }

    }

}
