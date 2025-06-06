using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MiniATM.Infrastructure.SqlServer.Repository.DataContext;
using MiniATM.UseCases.Repositories;
using BankAccount = MiniATM.Entities.BankAccount;

namespace MiniATM.Infrastructure.SqlServer.Repository;

public class SqlServerBankAccountRepository : IBankAccountRepository
{
    readonly MiniATMContext _context;
    readonly IMapper _mapper;

    public SqlServerBankAccountRepository(MiniATMContext context, IMapper mapper)
    {
        this._context = context ?? throw new ArgumentNullException(nameof(context));
        this._mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<BankAccount> FindByIdAsync(string accountId)
    {
        var dbAccount = await _context.BankAccounts.Where(ba => ba.Id == accountId).FirstOrDefaultAsync();
        return _mapper.Map<Entities.BankAccount>(dbAccount);
    }

    public async Task<IEnumerable<Entities.BankAccount>> FindByCustomerIdAsync(Guid customerId)
    {
        var dbAccount = await _context.BankAccounts.Where(cus => cus.CustomerId == customerId).ToListAsync();
        return _mapper.Map<IEnumerable<Entities.BankAccount>>(dbAccount);
    }

    public async Task UpdateAsync(Entities.BankAccount bankAccount)
    {
        var dbAccount = await _context.BankAccounts.Where(ba => ba.Id == bankAccount.Id).FirstOrDefaultAsync();
        if (dbAccount != null)
        {
            _mapper.Map(bankAccount, dbAccount);
        }
        
        await _context.SaveChangesAsync();
    }
}