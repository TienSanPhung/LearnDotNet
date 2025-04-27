namespace InterfaceLibrarySample;

public interface IPasswordAuthentication
{
    User? Authenticate(string username, string password);
}