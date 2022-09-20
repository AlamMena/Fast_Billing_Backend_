using API.DbModels.Core;
using API.DbModels.System.Branches;
using API.DbModels.System.Companies;
using API.DbModels.Users;
using API.Dtos.Request;
using Microsoft.EntityFrameworkCore;
using API.DbModels.Inventory.Brands;
using API.DbModels.Inventory.Categories;

namespace API.DbModels.Contexts
{
    public class FbContext : DbContext
    {
        private readonly TenantRequest _tenantRequest;

        public FbContext() { }

        public FbContext(TenantRequest tenantRequest)
        {
            _tenantRequest = tenantRequest;
        }


        public virtual Company Companies { get; set; } = null!;
        public virtual Branch Branches { get; set; } = null!;
        public virtual User Users { get; set; } = null!;
        public virtual Brand Brands { get; set; } = null!;
        public virtual Category Categories { get; set; } = null!;


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=LAPTOP-DES11/SQLEXPRESS;DataBase=FastBillingDB; trusted_connection=true;");
            }
        }

        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess,
            CancellationToken cancellationToken = new CancellationToken())
        {
            var entries = ChangeTracker.Entries().ToList();

            foreach (var entrie in entries)
            {
                var entity = (CoreModel)entrie.Entity;

                if (entity.CreatedBy == 0)
                {
                    entity.IsDeleted = false;
                    entity.CreatedBy = _tenantRequest.UserId;
                    entity.CreationDate = DateTime.Now;
                }
                else
                {
                    entity.UpdatedBy = _tenantRequest.UserId;
                    entity.UpdatedDate = DateTime.Now;
                }
            }
            return await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // system 
            modelBuilder.Entity<Company>();
            modelBuilder.Entity<Branch>();

            // inventory
            modelBuilder.Entity<Brand>();
            modelBuilder.Entity<Category>();


        }
    }
}
