using Microsoft.EntityFrameworkCore;
using ProjectKztech.Entities;
using System.Linq.Expressions;

namespace ProjectKztech.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<AuditLog> AuditLogs => Set<AuditLog>();
        public DbSet<Contact> Contacts => Set<Contact>();
        public DbSet<Contract> Contracts => Set<Contract>();
        public DbSet<ContractAppendix> ContractAppendices => Set<ContractAppendix>();
        public DbSet<ContractType> ContractTypes => Set<ContractType>();
        public DbSet<Customer> Customers => Set<Customer>();
        public DbSet<Employee> Employees => Set<Employee>();
        public DbSet<PaymentTransaction> PaymentTransactions => Set<PaymentTransaction>();
        public DbSet<ProductCategory> ProductCategories => Set<ProductCategory>();
        public DbSet<Project> Projects => Set<Project>();
        public DbSet<Quotation> Quotations => Set<Quotation>();
        public DbSet<QuotationCategory> QuotationCategories => Set<QuotationCategory>();
        public DbSet<QuotationStatus> QuotationStatuses => Set<QuotationStatus>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            ConfigureDecimalPrecision(modelBuilder);
            ConfigureSoftDelete(modelBuilder);
            ConfigureUniqueIndexes(modelBuilder);
        }

        public override int SaveChanges()
        {
            ApplyAuditAndSoftDelete();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            ApplyAuditAndSoftDelete();
            return base.SaveChangesAsync(cancellationToken);
        }

        private static void ConfigureDecimalPrecision(ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var property in entityType.GetProperties())
                {
                    if (property.ClrType == typeof(decimal) || property.ClrType == typeof(decimal?))
                    {
                        property.SetPrecision(18);
                        property.SetScale(2);
                    }
                }
            }
        }

        private static void ConfigureSoftDelete(ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (entityType.IsOwned())
                {
                    continue;
                }

                modelBuilder.Entity(entityType.ClrType)
                    .Property<bool>("IsDeleted")
                    .HasDefaultValue(false);

                var parameter = Expression.Parameter(entityType.ClrType, "e");
                var isDeletedProperty = Expression.Call(
                    typeof(EF),
                    nameof(EF.Property),
                    new[] { typeof(bool) },
                    parameter,
                    Expression.Constant("IsDeleted"));
                var compareExpression = Expression.Equal(isDeletedProperty, Expression.Constant(false));
                var lambda = Expression.Lambda(compareExpression, parameter);

                modelBuilder.Entity(entityType.ClrType).HasQueryFilter(lambda);
            }
        }

        private static void ConfigureUniqueIndexes(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contract>()
                .HasIndex(x => x.ContractNo)
                .IsUnique();

            modelBuilder.Entity<Contract>()
                .HasIndex(x => x.ContractCode)
                .IsUnique();

            modelBuilder.Entity<Project>()
                .HasIndex(x => x.ProjectCode)
                .IsUnique();

            modelBuilder.Entity<Quotation>()
                .HasIndex(x => x.QuotationNo)
                .IsUnique();

            modelBuilder.Entity<Employee>()
                .HasIndex(x => x.EmployeeCode)
                .IsUnique();
        }

        private void ApplyAuditAndSoftDelete()
        {
            var utcNow = DateTime.UtcNow;

            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.State == EntityState.Added)
                {
                    if (entry.Metadata.FindProperty("CreatedAt") != null)
                    {
                        entry.CurrentValues["CreatedAt"] = utcNow;
                    }
                }

                if (entry.State == EntityState.Modified)
                {
                    if (entry.Metadata.FindProperty("UpdatedAt") != null)
                    {
                        entry.CurrentValues["UpdatedAt"] = utcNow;
                    }
                }

                if (entry.State == EntityState.Deleted)
                {
                    entry.State = EntityState.Modified;
                    entry.CurrentValues["IsDeleted"] = true;

                    if (entry.Metadata.FindProperty("UpdatedAt") != null)
                    {
                        entry.CurrentValues["UpdatedAt"] = utcNow;
                    }
                }
            }
        }
    }
}
