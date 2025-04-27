namespace InterfaceLibrarySample;

public interface IUserStore
{
    User GetUser();
    void UpdateUser(User user);
    void DeleteUser(User user);
}