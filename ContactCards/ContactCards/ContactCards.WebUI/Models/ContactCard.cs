﻿using System;
using System.ComponentModel.DataAnnotations;

namespace ContactCards.WebUI.Models
{
    public class ContactCard
    {
        public int Id { get; set; }

        [Required, Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }

        [Required, Display(Name = "Last Name")]
        public string LastName { get; set; }

        public string Address { get; set; }
        public string Town { get; set; }
        public string City { get; set; }
        public string Pincode { get; set; }

        public string Photo { get; set; }

        [Display(Name = "Mobile No")]
        public string MobileNo { get; set; }

        [Display(Name = "Home No")]
        public string HomeNo { get; set; }

        [Display(Name = "Email ID"), DataType(DataType.EmailAddress)]
        public string EmailId { get; set; }

        [Display(Name = "Date Of Birth")]
        public DateTime? BirthDate { get; set; }

        [Display(Name = "Nirvan Tithi")]
        public DateTime? NirvanTithi { get; set; }

        [Display(Name = "Blood Group")]
        public string BloodGroup { get; set; }

        public string Education { get; set; }

        [Display(Name = "Interested In")]
        public string InterestedIn { get; set; }

        [Display(Name = "Relationship with Gurukul Sanstha")]
        public string GurukulSanstha { get; set; }

        [Display(Name = "Relationship with Swaminarayan Sampradaay")]
        public string SwaminarayanSampradaay { get; set; }

        [Display(Name = "Relationship with saints")]
        public string RWSanints { get; set; }

        [Display(Name = "Political connections")]
        public string PoliticalConnections { get; set; }

        [Display(Name = "Known Saints")]
        public string KnownSaints { get; set; }

        [Display(Name = "Known religious places")]
        public string ReligiousPlaces { get; set; }

        [Display(Name = "Devotee Catagory")]
        public string DevoteeCategory { get; set; }

        [Display(Name = "Seva Sahyog")]
        public string SevaSahyog { get; set; }

        public int? RId { get; set; }
        public string Relation { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }
    }
}