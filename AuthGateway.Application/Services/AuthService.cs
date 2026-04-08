using AuthGateway.Domain.Entities;

namespace AuthGateway.Application.Services;

public class AuthService
{
    public bool Authenticate(string email, string password)
    {
        return true;
    }

    public bool Register(User user)
    {
        return true;
    }
}