//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FinalTemplate
{
    using System;
    using System.Collections.Generic;
    
    public partial class User
    {
        public User()
        {
            this.Invitations = new HashSet<Invitation>();
            this.Transactions = new HashSet<Transaction>();
            this.UserClaims = new HashSet<UserClaim>();
            this.UserLogins = new HashSet<UserLogin>();
            this.Roles = new HashSet<Role>();
        }
    
        public int Id { get; set; }
        public int HouseHoldId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<bool> IsLockedOut { get; set; }
        public string PasswordResetTocken { get; set; }
        public Nullable<System.DateTimeOffset> PasswordResetExpiry { get; set; }
        public Nullable<System.DateTimeOffset> LockoutEndDate { get; set; }
        public int AccessFailedCount { get; set; }
        public bool EmailConfirmed { get; set; }
        public bool LockoutEnabled { get; set; }
    
        public virtual Household Household { get; set; }
        public virtual ICollection<Invitation> Invitations { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
        public virtual ICollection<UserClaim> UserClaims { get; set; }
        public virtual ICollection<UserLogin> UserLogins { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
    }
}