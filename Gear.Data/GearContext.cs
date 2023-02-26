using Gear.Data.DataModels;
using Microsoft.EntityFrameworkCore;


namespace Gear.Data
{
    public class GearContext : DbContext
    {
        public GearContext(DbContextOptions<GearContext> options) : base(options)
        {

        }
        public DbSet<GearPage> Pages { get; set; }
        public DbSet<UserModel> UserModels { get; set; }
        public DbSet<UserModelProperty> UserProperties { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GearPage>().ToTable("GearPage");
            modelBuilder.Entity<UserModel>().ToTable("UserModel");
            modelBuilder.Entity<UserModelProperty>().ToTable("UserModelProperties");
        }
    }

}