using CreditUnion.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace CreditUnion.Api.Data;

public static class DemoDataSeeder
{
    public const string DemoMemberId = "demo-member-001";

    public static async Task SeedAsync(CreditUnionDbContext database)
    {
        if (await database.Accounts.AnyAsync(account => account.MemberId == DemoMemberId))
        {
            return;
        }

        var account = new MemberAccount
        {
            MemberId = DemoMemberId,
            MemberName = "James Burdick",
            AccountType = "Everyday Checking",
            MaskedAccountNumber = "**** 4821",
            Currency = "USD",
            OpeningBalance = 5_420.00m,
            Transactions =
            [
                new AccountTransaction { Description = "Payroll deposit", Category = "Income", Amount = 2_450.00m, PostedAt = DateTimeOffset.UtcNow.AddHours(-8) },
                new AccountTransaction { Description = "Valley Market", Category = "Groceries", Amount = -86.42m, PostedAt = DateTimeOffset.UtcNow.AddDays(-1) },
                new AccountTransaction { Description = "Fuel Stop #18", Category = "Transportation", Amount = -52.18m, PostedAt = DateTimeOffset.UtcNow.AddDays(-2) },
                new AccountTransaction { Description = "Kern Electric Utility", Category = "Utilities", Amount = -128.67m, PostedAt = DateTimeOffset.UtcNow.AddDays(-3) },
                new AccountTransaction { Description = "Monthly savings transfer", Category = "Transfer", Amount = -300.00m, PostedAt = DateTimeOffset.UtcNow.AddDays(-4) },
                new AccountTransaction { Description = "Coffee House", Category = "Dining", Amount = -8.75m, PostedAt = DateTimeOffset.UtcNow.AddDays(-5) },
                new AccountTransaction { Description = "Payroll deposit", Category = "Income", Amount = 2_450.00m, PostedAt = DateTimeOffset.UtcNow.AddDays(-14) },
                new AccountTransaction { Description = "Neighborhood Pharmacy", Category = "Health", Amount = -34.50m, PostedAt = DateTimeOffset.UtcNow.AddDays(-16) }
            ]
        };

        database.Accounts.Add(account);
        await database.SaveChangesAsync();
    }
}