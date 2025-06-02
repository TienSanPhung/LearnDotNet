using AutoMapper;
using MiniATM.Infrastructure.SqlServer.Repository.DataContext;
using MiniATM.UseCases.Repositories;
using Transaction = MiniATM.Entities.Transaction;

namespace MiniATM.Infrastructure.SqlServer.Repository.MapperProfile;

public class SqlServerTransactionRepository : ITransactionRepository
{
    readonly MiniATMContext _context;
    readonly IMapper _mapper;

    public SqlServerTransactionRepository(MiniATMContext context, IMapper mapper)
    {
        this._context = context ?? throw new ArgumentNullException(nameof(context));
        this._mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public Task Add(Transaction transaction)
    {
        var dbTransaction = _mapper.Map<DataContext.Transaction>(transaction);
        
        _context.Transactions.Add(dbTransaction);
        return _context.SaveChangesAsync();
    }
}