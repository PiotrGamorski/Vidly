using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.CustomValidations;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Display(Name = "Subscribed to Newsletter?")]
        public bool IsSubscribedToNewletter { get; set; }

        [Required]
        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }

        public MembershipType MembershipType { get; set; }
        
        [Display(Name = "Date of Birth")]
        [Customer18YearsOld]
        public DateTime? Birthdate { get; set; }
    }
}