using MiniATM.UseCases;

namespace MiniATM.Infrastructure.Models;

public class WithdrawResultModel : WithdrawModel
{
    public required TransactionResultCodes  ResultCode {get;set;}
    public required string Message {get;set;}
}