﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.Core;
using System.ComponentModel.DataAnnotations;

namespace SquadClock.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        //Foreign Keys
        public int? CompanyId { get; set; }
        public int? DepartmentId { get; set; }
        public int? ManagerId { get; set; }
        public int? JobId { get; set; }

        //Constructor
        public Employee()
        {
            this.Shifts = new HashSet<Shift>();
            //FUTUREthis.Schedules = new HashSet<Schedule>();
        }

        [Display(Name = "First Name")]
        [StringLength(50, ErrorMessage = "{0} cannot be longer than 50 characters.")]
        public string FirstName { get; set;}
        [Display(Name = "Last Name")]
        [StringLength(50, ErrorMessage = "{0} cannot be longer than 50 characters.")]
        public string LastName { get; set; }
        [EmailAddress]
        [Display(Name = "Your Email/Login")]
        [StringLength(50, ErrorMessage = "{0} cannot be longer than 50 characters.")]
        public string Email { get; set; }
        public bool Active { get; set; }
        [Display(Name = "Your Password")]
        [StringLength(30, ErrorMessage = "{0} cannot be longer than 30 characters.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public double Timezone { get; set; }
        public bool AllowChangePassword { get; set; }
        
        //Navigation Properties
        public virtual Company Company { get; set; }
        public virtual Department Department { get; set; }
        public virtual Manager Manager { get; set; }
        public virtual Job Job { get; set; }
        public virtual ICollection<Shift> Shifts { get; set; }
        //FUTUREpublic virtual ICollection<Schedule> Schedules { get; set; }

        //Methods
        public string FullName()
        {
            return FirstName + " " + LastName;
        }
    }
}