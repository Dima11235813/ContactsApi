﻿using ContactsApi.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace CityInfo.API.Entities
{
    public class ContactContext : DbContext
    {
        public ContactContext(DbContextOptions<ContactContext> options): base(options)
        {
            //var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            ////use this for code first db creation
            //if (env == "production")
            //{
            //    Database.EnsureCreated();
            //}
            //if (env == "development")
            //{
            //   //this will seed the database and create it if doesn't exist
            //}
            Database.EnsureCreated();
            Database.Migrate();


        }

        public DbSet<Contact> Contacts { get; set; }
    }
}