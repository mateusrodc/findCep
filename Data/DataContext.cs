using System;
using System.Collections.Generic;
//using System.Data.Entity;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using desafioBackend.Entities;
using Microsoft.EntityFrameworkCore;

namespace desafioBackend.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public bool IgnoreSaveChangeAndUseTransaction { get; set; }

        public DbSet<Address> Address { get; set; }
        public override int SaveChanges()
        {
            if (!IgnoreSaveChangeAndUseTransaction)
                return base.SaveChanges();
            return 0;
        }
    }
}
