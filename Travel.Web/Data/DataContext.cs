using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Travel.Web.Data.Entities;

namespace Travel.Web.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<TravelEntity> Travels { get; set; }

        public DbSet<ExpenseEntity> Expenses { get; set; }

        public DbSet<UserEntity> Users { get; set; }

        
    }
}
