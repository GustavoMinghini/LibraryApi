namespace LibraryApi.Infrastructure.Repositories;


using global::Application.Interfaces;
using LibraryApi.Data;
using LibraryApi.Models;
using Microsoft.EntityFrameworkCore;

public class UserRepository : IUserRepository
{
    private readonly LibraryDbContext _dbContext;

    public UserRepository(LibraryDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        return await _dbContext.Users.ToListAsync();
    }

    public async Task<User?> GetByIdAsync(int id)
    {
        return await _dbContext.Users.FindAsync(id);
    }

    public async Task<User> CreateAsync(User user)
    {
        var createdUser = await _dbContext.Users.AddAsync(user);
        await _dbContext.SaveChangesAsync();
        return createdUser.Entity;
    }

    public async Task<User> UpdateAsync(User user)
    {
        _dbContext.Users.Update(user);
        await _dbContext.SaveChangesAsync();
        return user;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var user = await _dbContext.Users.FindAsync(id);
        if (user == null) return false;

        _dbContext.Users.Remove(user);
        await _dbContext.SaveChangesAsync();
        return true;
    }
}
