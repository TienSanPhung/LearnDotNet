namespace AttributeSample;

[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
public class DbMethodAttribute : Attribute
{
    public DbMethodAttribute(string msg)
    {
        this.Message = msg;
    }

    public string Message ;
}