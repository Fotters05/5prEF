﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Praktika5
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SUSHIBARSEntities : DbContext
    {
        public SUSHIBARSEntities()
            : base("name=SUSHIBARSEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Autorize> Autorize { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<OrderSushiSets> OrderSushiSets { get; set; }
        public virtual DbSet<PaymentMethods> PaymentMethods { get; set; }
        public virtual DbSet<QuantityIngredients> QuantityIngredients { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<StorageIngredients> StorageIngredients { get; set; }
        public virtual DbSet<Suppliers> Suppliers { get; set; }
        public virtual DbSet<Sushi> Sushi { get; set; }
        public virtual DbSet<SushiQuant> SushiQuant { get; set; }
        public virtual DbSet<SushiSets> SushiSets { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<SushiOrderSummary> SushiOrderSummary { get; set; }
    }
}
