using EnesFidanAssignment2.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace EnesFidanAssignment2
{
    public class DigitalOcienDataSet : DbContext
    {
        // Your context has been configured to use a 'DigitalOcienDataSet' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'EnesFidanAssignment2.DigitalOcienDataSet' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'DigitalOcienDataSet' 
        // connection string in the application configuration file.
        public DigitalOcienDataSet(): base("name=DigitalOcienDataSet")
        {
            
        }
        /// <summary>
        /// enes fidan
        /// </summary>
        public DbSet<Productss> Products { get; set; }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}