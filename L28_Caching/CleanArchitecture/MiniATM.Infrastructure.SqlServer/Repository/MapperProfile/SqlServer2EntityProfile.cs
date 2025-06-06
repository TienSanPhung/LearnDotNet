using AutoMapper;
using MiniATM.Entities;

namespace MiniATM.Infrastructure.SqlServer.Repository.MapperProfile;

public class SqlServer2EntityProfile : Profile
{
    public  SqlServer2EntityProfile() 
    {
        CreateMap<DataContext.Customer, Entities.Customer>();

        CreateMap<DataContext.BankAccount, Entities.BankAccount>();
        CreateMap<Entities.BankAccount, DataContext.BankAccount>();

        CreateMap<Entities.Transaction, DataContext.Transaction>();
    }
}