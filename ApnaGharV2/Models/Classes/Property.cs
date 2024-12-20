﻿using ApnaGharV2.Models.Classes;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApnaGharV2.Models.Classes
{

    //defaultly, table creates of same name as
    //class name, but if you want to change name,
    //use this property, similarly, we can change 
    //column name by [Column("newname")]
    [Table("Properties")]
    public class Property: FullAuditModel
    {
        [Key]                   //for autoincrement
        public int Id { get; set; }


        [Column(TypeName="varchar(10)")]
        [Required(ErrorMessage = "This field is required")]
        public string? Purpose { get; set; } //sale, rent


        [Column(TypeName = "varchar(10)")]
        [Required(ErrorMessage = "This field is required")]
        public string? Type { get; set; } //house, plot, commercial


        //[Column(TypeName = "varchar(20)")]
        //[Required(ErrorMessage = "This field is required")]
        //public string? SubType { get; set; } //from each type there is a sub type


        [Column(TypeName = "varchar(10)")]
        [Required(ErrorMessage = "This field is required")]
        public string? City { get; set; } //in which city this property reside


        [Column(TypeName = "varchar(100)")]
        [Required(ErrorMessage = "This field is required")]
        public string? Area { get; set; } //where property is located


        [Required(ErrorMessage = "This field is required")]
        public string? Address { get; set; } //full address


        [Column(TypeName = "varchar(100)")]
        [Required(ErrorMessage = "This field is required")]
        [StringLength(100, ErrorMessage = "Title cannot be longer than 100 characters")]
        public string? Title { get; set; }


        [Required(ErrorMessage = "This field is required")]
        public string? Description { get; set; }


        [Required(ErrorMessage = "This field is required")]
        public int? Price { get; set; }   //save as 45
        public string? PriceUnit { get; set; }   //save as 45 lack 


        [Required(ErrorMessage = "This field is required")]
        public int? Size { get; set; }    //save as 12 Sqft
        public string? SizeUnit { get; set; }    //save as 12 Sqft

        public int? Bedrooms { get; set; } //full address
        public int? Bathrooms { get; set; } //full address


        //public string? ImagesPath { get; set; }
        public int? ImagesCount { get; set; }            //number of images of this property
        //[Keyless]
       // @Transient
        [NotMapped]
        [Required(ErrorMessage = "This field is required")]
        public List<IFormFile>? PropertyImages { get; set; }




        //-------------------- Relation ships-----------------

        //--- for users
        public int? UserId { get; set; }
        //public virtual User user { get; set; }

        //--- for equiries
        public virtual List<Enquiry> Enquiries { get; set; } = new List<Enquiry>();

        //--- for favourites
        public virtual List<User> FavouriteForUsers { get; set; } = new List<User>();
    }
}
