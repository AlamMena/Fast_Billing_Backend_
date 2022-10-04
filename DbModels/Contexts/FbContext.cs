using API.DbModels.Core;
using API.DbModels.System.Branches;
using API.DbModels.System.Companies;
using API.DbModels.Users;
using API.Dtos.Core;
using Microsoft.EntityFrameworkCore;
using API.DbModels.Inventory.Brands;
using API.DbModels.Inventory.Categories;
using API.DbModels.Products;
using API.DbModels.Contacts;
using API.DbModels.Invoices;
using API.DbModels.Accounts.AccountsPayable;
using API.DbModels.AccountsReceivable;
using API.DbModels.Ncf;
using API.DbModels.Inventory.SubCategories;
using API.DbModels.Inventory.Warehouses;
using API.Enums;
using API.DbModels.Payments;
using API.DbModels.Inventory.Products;

namespace API.DbModels.Contexts
{
    public class FbContext : DbContext
    {
        public readonly TenantRequest tenant = null!;
        private readonly IConfiguration _configuration = null!;

        public FbContext(DbContextOptions<FbContext> options, IConfiguration configuration)
           : base(options)
        {
            _configuration = configuration;
        }
        public FbContext(DbContextOptions<FbContext> options, TenantRequest tenantRequest)
                : base(options)
        {
            tenant = tenantRequest;
        }
        // ----- system ----- 
        public virtual DbSet<Company> Companies { get; set; } = null!;
        public virtual DbSet<Branch> Branches { get; set; } = null!;

        // ----- users -----
        public virtual DbSet<User> Users { get; set; } = null!;

        // ----- inventory -----
        public virtual DbSet<Brand> Brands { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<SubCategory> SubCategories { get; set; } = null!;
        // ----- prodcuts -----
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<ProductImage> ProductImages { get; set; } = null!;
        public virtual DbSet<ProductPrice> ProductPrices { get; set; } = null!;
        public virtual DbSet<ProductStock> ProductStocks { get; set; } = null!;
        public virtual DbSet<ProductTransaction> ProductTransactions { get; set; } = null!;

        // ----- contacts -----
        public virtual DbSet<Client> Clients { get; set; } = null!;
        public virtual DbSet<ClientAddresses> ClientAddresses { get; set; } = null!;
        public virtual DbSet<ClientCard> ClientCards { get; set; } = null!;
        public virtual DbSet<ClientContacts> ClientContacts { get; set; } = null!;
        public virtual DbSet<ClientType> ClientTypes { get; set; } = null!;


        // ----- invoices -----
        public virtual DbSet<Invoice> Invoices { get; set; } = null!;
        public virtual DbSet<InvoiceDetail> InvoiceDetails { get; set; } = null!;
        public virtual DbSet<InvoiceType> InvoiceTypes { get; set; } = null!;

        // ---- accounts -----

        // ----- accounts receivable -----
        public virtual DbSet<AccountReceivable> AccountsReceivable { get; set; } = null!;
        public virtual DbSet<AccountReceivableTransaction> AccountReceivableTransactions { get; set; } = null!;

        // ----- accounts payable -----
        public virtual DbSet<AccountPayable> AccountsPayable { get; set; } = null!;
        public virtual DbSet<AccountPaybleTransaction> AccountsPaybleTransactions { get; set; } = null!;

        // ----- ncf ------
        public virtual DbSet<NcfType> NcfTypes { get; set; } = null!;
        public virtual DbSet<NcfSequence> NcfSequences { get; set; } = null!;

        // --- payments ---
        public virtual DbSet<PaymentType> PaymentTypes { get; set; } = null!;

        // --- warehouse ---
        public virtual DbSet<Warehouse> Warehouses { get; set; } = null!;


        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     if (!optionsBuilder.IsConfigured)
        //     {
        //         optionsBuilder.UseSqlServer("Server=LAPTOP-DES11\\SQLEXPRESS;DataBase=FastBillingDB;trusted_connection=true;");
        //         //optionsBuilder.UseSqlServer("Server=fastbillingdb.database.windows.net;Initial Catalog=FastBillingDB;Persist Security Info=False;User ID=fb2701;Password=FastBilling2701.;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        //     }
        // }

        private void SetTenantValue(CoreModel entity)
        {
            var companyIdField = entity.GetType().GetProperty("CompanyId");
            var branchIdField = entity.GetType().GetProperty("branchId");

            if (companyIdField is not null)
            {
                if (companyIdField.GetValue(entity) is null)
                {
                    entity.GetType()?.GetProperty("CompanyId")?.SetValue(entity, tenant.CompanyId);
                }
            }
            else if (branchIdField is not null)
            {
                if (branchIdField.GetValue(entity) is null)
                {
                    entity.GetType()?.GetProperty("branchId")?.SetValue(entity, tenant.BranchId);
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
                    entity.CreatedBy = tenant.UserId;
                    entity.CreationDate = DateTime.Now;
                }
                else
                {
                    entity.UpdatedBy = tenant.UserId;
                    entity.UpdatedDate = DateTime.Now;
                }

                SetTenantValue(entity);
            }
            return await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SetQueryFilters(modelBuilder);

            SetPrecision(modelBuilder);

            // .HasForeignKey(d => d.ReferenceId);
            //modelBuilder.Entity<AccountsReceivable>().HasDiscriminator<Invoice>("value").HasValue<int>(0);
        }

        public void SetTenant<T>(ModelBuilder modelBuilder) where T : class
        {

            if (typeof(T) == typeof(Company))
            {
                modelBuilder.Entity<T>()
                            .HasQueryFilter(e => EF.Property<int>(e, "Id") == tenant.CompanyId && EF.Property<bool>(e, "IsDeleted") == false);
            }
            else
            {
                modelBuilder.Entity<T>()
                            .HasQueryFilter(e => EF.Property<int>(e, "CompanyId") == tenant.CompanyId && EF.Property<bool>(e, "IsDeleted") == false);

            }
        }

        public static void SetPrecision(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetProperties())
                .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?)))
            {
                property.SetColumnType("decimal(18,4)");
            }
        }
        public void SetQueryFilters(ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (!typeof(TenantModel).IsAssignableFrom(entityType.ClrType))
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
