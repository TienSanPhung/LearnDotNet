using AutoMapper;
using MiniATM.Infrastructure.SqlServer.Repository.DataContext;
using MiniATM.Infrastructure.SqlServer.Repository.MapperProfile;
using MiniATM.UseCases.Repositories;
using MiniATM.UseCases.UnitOfWork;

namespace MiniATM.Infrastructure.SqlServer.Repository;

public class SqlServerTransactionUnitOfWork : ITransactionUnitOfWork
{
    readonly MiniATMContext _context;
    readonly IMapper _mapper;

    public SqlServerTransactionUnitOfWork(MiniATMContext context, IMapper mapper)
    {
        this._context = context ?? throw new ArgumentNullException(nameof(context));
        this._mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        BankAccountRepository = new SqlServerBankAccountRepository(context, mapper);;
        TransactionRepository = new SqlServerTransactionRepository(context, mapper);
    }

    public IBankAccountRepository BankAccountRepository { get; }
    public ITransactionRepository TransactionRepository { get; }
    public Task BeginTransactionAsync()
    {
        return Task.CompletedTask;
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    public Task CancelAsync()
    {
        return Task.CompletedTask;
    }
}