namespace CreditUnion.Api.Models;

public sealed class AccountTransaction
{
    public int Id { get; set; }
    public int AccountId { get; set; }
    public MemberAccount Account { get; set; } = null!;
    public string Description { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public DateTimeOffset PostedAt { get; set; }
}