using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

using SimpleOrderApp.Application.Common.Interfaces;
using SimpleOrderApp.Domain.Entities;
using SimpleOrderApp.Domain.Entities.Referentials;
using SimpleOrderApp.Infrastructure.Persistence.Configurations.Seeding;

using System.Reflection;

namespace SimpleOrderApp.Infrastructure.Persistence
{
    //<inheritdoc/>
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public virtual DbSet<RefCurrency> RefCurrency { get; set; }

        public virtual DbSet<RefOrderType> RefOrderType { get; set; }

        public virtual DbSet<RefVehicleType> RefVehicleType { get; set; }

        public virtual DbSet<CurrencyRate> CurrencyRate { get; set; }

        public virtual DbSet<Order> Order { get; set; }

        public virtual DbSet<Vehicle> Vehicle { get; set; }

        public virtual DbSet<VehicleOrder> VehicleOrder { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            SeedData(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            ApplicationDbContextSeed.SeedStaticData(modelBuilder);
        }

        //<inheritdoc/>
        public IQueryable<TEnt> ReadSet<TEnt>() where TEnt : class
        {
            return Set<TEnt>().AsNoTracking();
        }

        //<inheritdoc/>
        public async Task<int> SaveChangesExAsync(CancellationToken token = default)
        {
            var allEntries = ChangeTracker.Entries().Where(e => e.Entity != null).ToList();

            try
            {
                return await SaveChangesAsync(token);
            }
            catch(Exception)
            {
                RejectChanges(allEntries);
                throw;
            }
        }

        //<inheritdoc/>
        public void RejectChanges(IList<EntityEntry> entries = null)
        {
            entries ??= ChangeTracker.Entries().Where(e => e.Entity != null).ToList();

            foreach (var entry in entries)
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                    case EntityState.Deleted:
                        entry.State = EntityState.Modified;
                        entry.State = EntityState.Unchanged;
                        break;
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                }
            }
        }

    }
}
