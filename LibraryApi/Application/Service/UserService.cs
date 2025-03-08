using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace LibraryApi.Application.Service;

using Application.Interfaces;
using global::Application.Interfaces;
using LibraryApi.Models;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        return await _userRepository.GetAllAsync();
    }

    public async Task<User?> GetByIdAsync(int id)
    {
        return await _userRepository.GetByIdAsync(id);
    }

    public async Task<User> CreateAsync(User user)
    {
        return await _userRepository.CreateAsync(user);
    }

    public async Task<User> UpdateAsync(int id, User user)
    {
        var existingUser = await _userRepository.GetByIdAsync(id);
        if (existingUser == null) throw new KeyNotFoundException("Usuário não encontrado.");

        existingUser.Name = user.Name;
        existingUser.Email = user.Email;
        existingUser.Password = user.Password;
        existingUser.Username = user.Username;

        return await _userRepository.UpdateAsync(existingUser);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _userRepository.DeleteAsync(id);
    }
}
