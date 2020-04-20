using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FSISSystem.ENTITIES
{
   public class Employee
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateHired { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int? PostitionID { get; set; }
        public int? ProgramID { get; set; }
        public string LoginID { get; set; }

        public string FullName
        {
            get
            {
                return FirstName + "(" + LastName + ")";
            }
        }
    }
}
