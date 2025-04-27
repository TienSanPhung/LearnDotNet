namespace InterfaceLibrarySample;

public class UserManager: IUserStore
{
    public User GetUser()
    {
        return new User();
    }

    public void UpdateUser(User user)
    {
        
    }

    public void DeleteUser(User user)
    {
        
    }

}
