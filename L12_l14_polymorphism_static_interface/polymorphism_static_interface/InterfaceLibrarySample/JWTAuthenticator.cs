namespace InterfaceLibrarySample;

public interface JWTAuthenticator
{
    User? Authenticate(string token);
}