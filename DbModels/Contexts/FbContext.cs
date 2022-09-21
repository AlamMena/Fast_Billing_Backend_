using API.DbModels.Core;
using API.DbModels.System.Branches;
using API.DbModels.System.Companies;
using API.DbModels.Users;
using API.Dtos.Core;
using Microsoft.EntityFrameworkCore;
using API.DbModels.Inventory.Brands;
using API.DbModels.Inventory.Categories;

namespace API.DbModels.Contexts
{
    public class FbContext : DbContext
    {
        private readonly TenantRequest _tenantRequest = null!;
        private readonly IConfiguration _configuration = null!;

        public FbContext() { }

        public FbContext(DbContextOptions<FbContext> options, TenantRequest tenantRequest)
                : base(options)
        {
            _tenantRequest = tenantRequest;
        }
        public virtual DbSet<Company> Companies { get; set; } = null!;
        public virtual DbSet<Branch> Branches { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<Brand> Brands { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=LAPTOP-DES11\\SQLEXPRESS;DataBase=FastBillingDB; trusted_connection=true;");
            }
        }

        private void setTenantValue(CoreModel entity)
        {
            var companyIdField = entity.GetType().GetProperty("CompanyId");
            var branchIdField = entity.GetType().GetProperty("branchId");

            if (companyIdField is not null)
            {
                if (companyIdField.GetValue(entity) is null)
                {
                    entity.GetType()?.GetProperty("CompanyId")?.SetValue(entity, _tenantRequest.CompanyId);
                }
            }
            else if (branchIdField is not null)
            {
                if (branchIdField.GetValue(entity) is null)
                {
                    entity.GetType()?.GetProperty("branchId")?.SetValue(entity, _tenantRequest.BranchId);
                }
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

                setTenantValue(entity);
            }
            return await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // SetQueryFilters(modelBuilder);

            // users 
            modelBuilder.Entity<User>();

            // system 
            modelBuilder.Entity<Company>().HasQueryFilter(d => d.Id == _tenantRequest.CompanyId);
            modelBuilder.Entity<Branch>();

            // inventory
            modelBuilder.Entity<Brand>();
            modelBuilder.Entity<Category>();
        }

        public void SetTenant<T>(ModelBuilder modelBuilder) where T : class
        {
            modelBuilder.Entity<T>()
                .HasQueryFilter(e => EF.Property<int>(e, "CompanyId") == _tenantRequest.CompanyId && EF.Property<bool>(e, "IsDeleted") == false);
        }

        public void SetQueryFilters(ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (!typeof(CoreModel).IsAssignableFrom(entityType.ClrType))
                {
                    continue;
                }

                // getting method to set query filter
                GetType()
                    .GetMethod(nameof(SetTenant))
                    ?.MakeGenericMethod(entityType.ClrType)
                    .Invoke(this, new object[] { modelBuilder });
            }
        }
    }
}
