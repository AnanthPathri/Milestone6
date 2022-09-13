using FoodDonationManagementSystem.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDonationManagementSystem.DataAccess
{
    public class DonationDbContext : DbContext
    {
        public DonationDbContext(DbContextOptions<DonationDbContext> options) : base(options)
        {
        }
        public virtual DbSet<FoodDonationModel> studentModels { get; set; }

        //  add-migration Initialmigration
        //  update-database
    }
}
