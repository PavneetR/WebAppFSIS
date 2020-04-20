using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using FSISSystem.DAL;
using FSISSystem.ENTITIES;

namespace FSISSystem.BLL
{
    public class ProgramsController
    {
        public List<Program> List()
        {
            using(var context = new StarTed())
            {
                return context.Programs.ToList();
            }
        }
    }
}
