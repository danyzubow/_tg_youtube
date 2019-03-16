using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Npgsql;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            using (ApplicationContext db=new ApplicationContext())
            {
                 db.Guy.Load();
                var qwe = db.Guy.ToList();
            }
        }
    }
    public class ApplicationContext : DbContext
    {
        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        public DbSet<Guy> Guy { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseNpgsql("Host=ec2-54-228-224-37.eu-west-1.compute.amazonaws.com;" +
            //                         //"Port=5432;" +
            //                         "Database=dc93eerj50iep9;" +

            //                         "Username=rfttmmtzqdmzhz;" +
            //                         "Password=4f8b6967b50fdbd17916c5ef73d854572ed8ac6c0d9617e5e584ba3a1507099e;" +
            //                         "mode=require;");

            var connectionString = new NpgsqlConnectionStringBuilder
            {
                Host = "ec2-54-228-224-37.eu-west-1.compute.amazonaws.com",
                Database = "dc93eerj50iep9",
                Username = "rfttmmtzqdmzhz",
                Password = "4f8b6967b50fdbd17916c5ef73d854572ed8ac6c0d9617e5e584ba3a1507099e",

                SslMode = SslMode.Prefer,
                TrustServerCertificate = true
            };
            optionsBuilder.UseNpgsql(connectionString.ConnectionString);

        }
    }

    public class Guy
    {
        
        public int Id { get; set; }
        public Guy()
        {

        }

        public string name { get; set; }
    }

}
