﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Biblioteka
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Library_Entities : DbContext
    {
        public Library_Entities()
            : base("name=Library_Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Autorzy> Autorzies { get; set; }
        public virtual DbSet<Czytelnicy> Czytelnicies { get; set; }
        public virtual DbSet<HistoriaWypozyczenia> HistoriaWypozyczenias { get; set; }
        public virtual DbSet<Ksiazki> Ksiazkis { get; set; }
        public virtual DbSet<Wypozyczenia> Wypozyczenias { get; set; }
    }
}