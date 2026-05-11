using IoT.Models.Devices;
using IoT.Models.DeviceTelemetry;
using IoT.Models.Hubs;
using IoT.Models.Robots;
using IoT.Models.RobotTelemetry;
using IoT.Models.Users;
using Microsoft.EntityFrameworkCore;
namespace IoT.Persistence

{
    public class ApplicationDbContext : DbContext 

    {
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<HubEntity> Hubs { get; set; }
        public DbSet<DeviceEntity> Devices { get; set; } 
        public DbSet<RobotEntity> Robots { get; set; }
        public DbSet<DevTelemetryEntity> DeviceTelemetries { get; set; }
        public DbSet<RobTelemetryEntity> RobotTelemetries { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base( options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            


        }
    }
}
