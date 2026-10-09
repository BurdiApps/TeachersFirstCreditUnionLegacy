using CreditUnion.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace CreditUnion.Api.Data;

public sealed class CreditUnionDbContext(DbContextOptions<CreditUnionDbContext> options) : DbContext(options)
{
    public DbSet<MemberAccount> Accounts => Set<MemberAccount>();
    public DbSet<AccountTransaction> Transactions => Set<AccountTransaction>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MemberAccount>()
            .Property(account => account.OpeningBalance)
            .HasPrecision(12, 2);

        modelBuilder.Entity<AccountTransaction>()
            .Property(transaction => transaction.Amount)
            .HasPrecision(12, 2);

        modelBuilder.Entity<MemberAccount>()
            .HasMany(account => account.Transactions)
            .WithOne(transaction => transaction.Account)
            .HasForeignKey(transaction => transaction.AccountId);
    }
}