using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace vidly.Models
{
    public class Customer
    {
        
        public int Id { get; set; }
        [Required(ErrorMessage ="please enter customer name.")]
        [StringLength(255)]
       public string Name { get; set; }
        public bool IsSubscribeToNewsLetter { get; set; }
        public MembershipType membershipType { get; set; }

        [Display(Name = "Membership Type")]
        [Required]
        public byte MembershipTypeId { get; set; }
        [Display(Name ="Date Of Birth")]
        [Min18YearsIsMember]
        public DateTime? BirthDate { get; set; }
    }
}