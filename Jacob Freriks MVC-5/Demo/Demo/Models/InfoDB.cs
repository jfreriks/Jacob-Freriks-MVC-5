using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace Demo.Models
{
    public class InfoDB
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Birthdate { get; set; }

    }
    public class InfoDBContext : DbContext
    {
        public DbSet<InfoDB> Info { get; set; }
    }
}