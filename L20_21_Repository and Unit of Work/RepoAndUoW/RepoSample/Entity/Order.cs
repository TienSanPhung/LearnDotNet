namespace RepoSample.Entity;

public class Order
{
   public required Guid Id {set;get;}
   public required Guid CustomerId {set;get;}
   public required string OrderReference {set;get;}
   
   public  List<OrderItem> OrderItems {set;get;} = [];
}