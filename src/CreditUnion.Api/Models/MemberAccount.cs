namespace CreditUnion.Api.Models;

public sealed class MemberAccount
{
    public int Id { get; set; }
    public string MemberId { get; set; } = string.Empty;
    public string MemberName { get; set; } = string.Empty;
    public string AccountType { get; set; } = string.Empty;
    public string MaskedAccountNumber { get; set; } = string.Empty;
    public string Currency { get; set; } = "USD";
    public decimal OpeningBalance { get; set; }
    public ICollection<AccountTransaction> Transactions { get; set; } = new List<AccountTransaction>();
}