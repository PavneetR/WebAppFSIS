﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FSISSystem.ENTITIES
{
    [Table("Player")]

    public class Player
    {
        public int PlayerID { get; set; }
        public int? GuardianID { get; set; }
        public int? TeamID { get; set; }


        public string FirstName { get; set; }

        public string LastNameName { get; set; }
        public int Age { get; set; }
        public string Gender{ get; set; }

        public int AlbertaHealthCareNumber { get; set; }

        public string MedicalAlertDetails { get; set; }

        public string EmailAddress { get; set; }
    }
}
