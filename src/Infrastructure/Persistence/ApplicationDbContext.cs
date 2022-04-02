using Application.Common.Errors;
using Application.Common.Interfaces;
using Application.Common.Models;
using CSharpFunctionalExtensions;
using Domain.Common;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<MoneyCategory> MoneyCategories { get; set; }
        public DbSet<MoneyEntry> MoneyEntries { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<RowVersionEntity>())
            {
                if (entry.State == EntityState.Modified)
                {
                    var property = entry.Property("RowVersion");
                    property.OriginalValue = property.CurrentValue;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }

        public async Task<Maybe<BaseError>> CommitChangesAsync(
            string conflictErrorMessage,
            string serverErrorMessage = Constants.UnhandledServerErrorMessage,
            CancellationToken cancellationToken = default)
        {
            try
            {
                await SaveChangesAsync(cancellationToken);
                return Maybe.None;
            }
            catch (DbUpdateConcurrencyException)
            {
                return Maybe.From<BaseError>(new ConflictError(conflictErrorMessage));
            } 
            catch (DbUpdateException)
            {
                return Maybe.From<BaseError>(new UnhandledServerError(Constants.DbUpdateErrorMessage));
            }
            catch (OperationCanceledException)
            {
                return Maybe.From<BaseError>(new UnhandledServerError(Constants.OperationCancelledErrorMessage));
            }
            catch (Exception)
            {
                return Maybe.From<BaseError>(new UnhandledServerError(serverErrorMessage));
            }
        }
    }
}
