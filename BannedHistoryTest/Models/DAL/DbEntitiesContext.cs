using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BannedHistoryTest.Models.DAL
{
    public class DbEntitiesContext : DbContext
    {
        public DbEntitiesContext() : base("mysqlCon") { }
        public DbSet<BannedClientHistory> BannedClientsHistory { get; set; }
        protected override void OnModelCreating(DbModelBuilder builder)
        {
            builder.Entity<BannedClientHistory>().HasKey(w => w.ID);
        }
    }
}