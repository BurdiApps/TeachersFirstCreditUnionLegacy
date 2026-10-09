using System.Security.Claims;
using CreditUnion.Api.Contracts;
using CreditUnion.Api.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CreditUnion.Api.Controllers;

[ApiController]
[Authorize]
[Route("api/accounts")]
public sealed class AccountsController(CreditUnionDbContext database) : ControllerBase
{
    [HttpGet("mine")]
    [ProducesResponseType<AccountSummaryResponse>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<AccountSummaryResponse>> GetMyAccount(CancellationToken cancellationToken)
    {
        var memberId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var account = await database.Accounts
            .AsNoTracking()
            .Include(item => item.Transactions)
            .SingleOrDefaultAsync(item => item.MemberId == memberId, cancellationToken);

        if (account is null)
        {
            return NotFound();
        }

        var balance = account.OpeningBalance + account.Transactions.Sum(transaction => transaction.Amount);
        return Ok(new AccountSummaryResponse(
            account.Id,
            account.MemberName,
            account.AccountType,
            account.MaskedAccountNumber,
            account.Currency,
            balance));
    }

    [HttpGet("mine/transactions")]
    [ProducesResponseType<IReadOnlyList<TransactionResponse>>(StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyList<TransactionResponse>>> GetMyTransactions(CancellationToken cancellationToken)
    {
        var memberId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var transactions = await database.Transactions
            .AsNoTracking()
            .Where(transaction => transaction.Account.MemberId == memberId)
            .OrderByDescending(transaction => transaction.PostedAt)
            .Select(transaction => new TransactionResponse(
                transaction.Id,
                transaction.Description,
                transaction.Category,
                transaction.Amount,
                transaction.PostedAt))
            .ToListAsync(cancellationToken);

        return Ok(transactions);
    }
}