namespace CreditUnion.Api.Contracts;

using System.ComponentModel.DataAnnotations;

/// <summary>Summary for the signed-in demo member's checking account.</summary>
public sealed record AccountSummaryResponse(
    int Id,
    string MemberName,
    string AccountType,
    string MaskedAccountNumber,
    string Currency,
    decimal AvailableBalance);

/// <summary>A posted transaction in the demo account's activity history.</summary>
public sealed record TransactionResponse(
    int Id,
    string Description,
    string Category,
    decimal Amount,
    DateTimeOffset PostedAt);

/// <summary>Indicates whether the browser has an active demo session.</summary>
public sealed record SessionResponse(bool IsAuthenticated, string? DisplayName);

/// <summary>Credentials for the fictional demo member account.</summary>
public sealed record DemoLoginRequest
{
    [Required, StringLength(32)]
    public required string UserId { get; init; }

    [Required, StringLength(64)]
    public required string Password { get; init; }
}