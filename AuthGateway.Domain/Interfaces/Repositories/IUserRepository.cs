using AuthGateway.Domain.Entities;

namespace AuthGateway.Domain.Interfaces.Repositories;

public interface IUserRepository
{
    public bool Insert(User user);
    public User? GetById(string id);
    public User? GetByEmail(string email);
    public User? GetByUsername(string username);
    public bool Update(string id, User user);
    public bool Delete(string id);
}