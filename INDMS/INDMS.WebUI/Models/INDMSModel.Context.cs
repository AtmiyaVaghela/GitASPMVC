﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace INDMS.WebUI.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class INDMSEntities : DbContext
    {
        public INDMSEntities()
            : base("name=INDMSEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ParameterMaster> ParameterMasters { get; set; }
        public virtual DbSet<PolicyLetter> PolicyLetters { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Standard> Standards { get; set; }
        public virtual DbSet<StandingOrder> StandingOrders { get; set; }
        public virtual DbSet<GuideLine> GuideLines { get; set; }
        public virtual DbSet<GeneralBook> GeneralBooks { get; set; }
    }
}
