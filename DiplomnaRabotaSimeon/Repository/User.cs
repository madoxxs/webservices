//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Repository
{
    using System;
    using System.Collections.Generic;
    
    public partial class User
    {
        public System.Guid Id { get; set; }
        public bool IsEnabled { get; set; }
        public Nullable<bool> CanChgPass { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string PassHash { get; set; }
        public System.DateTime PassDateChng { get; set; }
        public System.DateTime UserLastLogin { get; set; }
        public System.DateTime ModifiedAt { get; set; }
        public System.DateTime CreatedAt { get; set; }
        public int UserId { get; set; }
        public string Email { get; set; }
    }
}
