﻿using CalvaryOpebBibleWebsite.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace CalvaryOpebBibleWebsite.DAL
{
    public class CalvaryContext:  DbContext
    {
      public CalvaryContext()
      
            : base("CalvaryContext") { }

            public DbSet<Belief> Belief{ get; set; }
            public DbSet<Calendar> Calendar { get; set; }
            public DbSet<Event> Event { get; set; }
            public DbSet<Pastor> Pastor { get; set; }
            public DbSet<Image> Image { get; set; }
            public DbSet<Ministries> Ministries { get; set; }
            public DbSet<Contact> Contact { get; set; }

            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
                base.OnModelCreating(modelBuilder);
            }

            //public System.Data.Entity.DbSet<CalvaryOpebBibleWebsite.Models.Contact> Contact { get; set; }
        }
}