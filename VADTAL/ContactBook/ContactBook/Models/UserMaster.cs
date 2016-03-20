using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ContactBook.Models
{
    public class UserMaster
    {
        public int ID { get; set; }

        public int PID { get; set; }

        [Required, Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }

        [Required, Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Contact No")]
        public string ContactNo { get; set; }

        public string Address { get; set; }
        public string City { get; set; }

        [Display(Name = "Native Address")]
        public string NativeAddress { get; set; }

        public string Email { get; set; }
        public string Reference { get; set; }

        [Display(Name = "Birth Of Date")]
        public DateTime BirthOfDate { get; set; }
        public DateTime ExDate { get; set; }

        
        public bool IsActive { get; set; }
        public string Education { get; set; }
        public string Occupation { get; set; }
        public string Designation { get; set; }

        [Display(Name = "Companu Name")]
        public string CompanyName { get; set; }
        [Display(Name = "Work Address")]
        public string WorkAddress { get; set; }
        public string UID { get; set; }

    }
}