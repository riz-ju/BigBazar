using BigBazarData.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBazarData
{
    public  class ApiDbContext : DbContext
    {
        
        public virtual DbSet<wareHouse> wareHouse { get; set; }
        public virtual DbSet<store> store{ get; set; }

        public virtual DbSet<customer> customer { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer("Server = DESKTOP-1GNOQEQ\\SQLEXPRESS; Database = bigBazar; Trusted_Connection=True ");
        }
    }
}
