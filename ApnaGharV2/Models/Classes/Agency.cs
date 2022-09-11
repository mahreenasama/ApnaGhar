﻿using ApnaGharV2.Models.Classes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApnaGharV2.Models.Classes
{
    public class Agency: FullAuditModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }    //name should be unique
        public string? ServicesDescription { get; set; }
        public string? CompanyPhone { get; set; }
        public string? CompanyAddress { get; set; }
        public string? CompanyEmail { get; set; }
        public string LogoPath { get; set; }    //path of logo will save

        //--------- relations------------
        //--- with user---
        public int UserId { get; set; }
        public virtual User User { get; set; }

    }
}
