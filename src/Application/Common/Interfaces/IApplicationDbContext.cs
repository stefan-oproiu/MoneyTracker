using Application.Common.Errors;
using Application.Common.Models;
using CSharpFunctionalExtensions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        public DbSet<User> Users { get; }
        public DbSet<MoneyCategory> MoneyCategories { get; }
        public DbSet<MoneyEntry> MoneyEntries { get; }

        Task<Maybe<BaseError>> CommitChangesAsync(
            string conflictErrorMessage,
            string serverErrorMessage = Constants.UnhandledServerErrorMessage,
            CancellationToken cancellationToken = default);
    }
}
