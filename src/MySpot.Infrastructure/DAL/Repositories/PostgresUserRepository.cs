using Microsoft.EntityFrameworkCore;
using MySpot.Core.Entities;
using MySpot.Core.Repositories;
using MySpot.Core.ValueObjects;

namespace MySpot.Infrastructure.DAL.Repositories;

internal sealed class PostgresUserRepository : IUserRepository
{
    private readonly DbSet<User> _users;

    public PostgresUserRepository(MySpotDbContext dbContext)
    {
        _users = dbContext.Users;
    }

    public Task<User> GetByIdAsync(UserId id)
        => _users.SingleOrDefaultAsync(x => x.Id == id);

    public Task<User> GetByEmailAsync(Email email)
        => _users.SingleOrDefaultAsync(x => x.Email == email);

    public Task<User> GetByUserNameAsync(UserName userName)
        => _users.SingleOrDefaultAsync(x => x.UserName == userName);

    public async Task AddAsync(User user)
        => await _users.AddAsync(user);
}