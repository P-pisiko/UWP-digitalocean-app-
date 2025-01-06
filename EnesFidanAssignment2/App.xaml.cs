using EnesFidanAssignment2.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Xml.Linq;

namespace EnesFidanAssignment2
{
   /// <summary>
   /// Enes FİDAN
   /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string projectRoot = Directory.GetParent(baseDirectory).Parent.Parent.FullName;
            string appDataPath = Path.Combine(projectRoot, "AppData");

            if (!Directory.Exists(appDataPath))
            {
                Directory.CreateDirectory(appDataPath);
            }

            AppDomain.CurrentDomain.SetData("DataDirectory", appDataPath);

            try
            {
                //InsertAllProducts();
            }
            catch (Exception exciption)
            {
                MessageBox.Show($"ERROR {exciption.Message}");
            }
            
        }
        /// <summary>
        /// İNSERT THE DEFAULT TO DATABASE
        /// </summary>
        static void InsertAllProducts()
        {
            using (var icerik = new DigitalOcienDataSet())
            {
                icerik.Database.Initialize(force: true);
                if (!icerik.Products.Any())
                {
                    Insertitems(icerik, "Virtual machines", "DigitalOcean Droplets are simple, scalable virtual machines for all your web hosting and VPS hosting needs");
                    Insertitems(icerik, "Kubernetes", "DigitalOcean Kubernetes is a managed solution that is easy to scale and includes a 99.95% SLA and free control plane.");
                    Insertitems(icerik, "AI / ML", "Build, train, and deploy AI apps, and create AI agents with a suite of simple-to-use tools and GPU compute.");
                    Insertitems(icerik, "App Platform", "App Platform is our fully-managed PaaS solution to get your app to market fast thats super simple to set.");
                    Insertitems(icerik, "Managed databases", "Managed MongoDB, Kafka, MySQL, PostgreSQL and Caching let you focus on your apps.");
                    Insertitems(icerik, "Storage", "DigitalOcean Spaces object storage and Volumes block storage are business-ready storage solutions.");
                }
            }
        }







        /// <summary>
        /// İNSERT THE DEFAULT PRODUCTS TO DATABASE 
        /// </summary>



        private static void Insertitems(DigitalOcienDataSet icerik , string Title, string Descriptioon)
        {
            var existingItem = icerik.Products.SingleOrDefault(i => i.Title == Title);

            if (existingItem == null)
            {
                // İNSERT THE İTEM
                var item = new Productss
                {
                    Title = Title,
                    Descriptioon = Descriptioon
                };

                icerik.Products.Add(item);
            }
            else
            {
                // UPDATE THE İTEM
                existingItem.Title = Title;
                existingItem.Descriptioon = Descriptioon;

            }

            icerik.SaveChanges();
        }
    }
}
