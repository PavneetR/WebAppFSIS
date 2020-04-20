using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using FSISSystem.ENTITIES;

namespace FSISSystem.DAL
{
    internal class StarTed : DbContext
    {
        public StarTed() : base("StarTEDDB")
        {

        }

        public DbSet<Position> Positions{ get; set; }
        public DbSet<Program> Programs { get; set; }
        public DbSet<Employee> Employees { get; set; }





    }
}
