using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FSISSystem.ENTITIES
{
    [Table("Guardian")]

    public class Guardian
    {
        public int GuardianID { get; set; }

        public string FirstName { get; set; }

        public string LastNameName { get; set; }
        public int EmergencyPhoneNumber { get; set; }
        public string EmailAddress { get; set; }
    }

}
