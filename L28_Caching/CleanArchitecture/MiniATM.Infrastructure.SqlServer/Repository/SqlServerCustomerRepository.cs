using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MiniATM.Infrastructure.SqlServer.Repository.DataContext;
using MiniATM.UseCases.Repositories;
using Customer = MiniATM.Entities.Customer;

namespace MiniATM.Infrastructure.SqlServer.Repository;

public class SqlServerCustomerRepository : ICustomerRepository
{
    readonly MiniATMContext _context;
    readonly IMapper _mapper;

    public SqlServerCustomerRepository(MiniATMContext context, IMapper mapper)
    {
        this._context = context ?? throw new ArgumentNullException(nameof(context));
        this._mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<Entities.Customer?> FindByIdAsync(Guid id)
    {
        var dbcustomer = await _context.Customers.Where(cus => cus.Id == id).FirstOrDefaultAsync();
        return _mapper.Map<Customer>(dbcustomer);
    }
}