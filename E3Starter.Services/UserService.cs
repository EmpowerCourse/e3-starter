using AutoMapper;
using E3Starter.Contracts.Persistence;
using E3Starter.Contracts.Services;
using E3Starter.Dtos;
using E3Starter.Models;

namespace E3Starter.Services;

public class UserService : IUserService
{
    private readonly ICryptoService _cryptoService;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UserService(ICryptoService cryptoService, IUserRepository userRepository, IMapper mapper)
    {
        _cryptoService = cryptoService;
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<UserDto?> AuthenticateAsync(string email, string password)
    {
        var user = await _userRepository.GetByEmailAsync(email);
        if (user == null) return null;
        var isPasswordValid = _cryptoService.VerifyPassword(password, user.HashedPassword, user.PasswordSalt);
        if (!isPasswordValid) return null;

        return _mapper.Map<UserDto>(user);
    }

    public async Task<List<UserDto>> GetAllAsync()
    {
        var users = await _userRepository.GetAllAsync();
        return _mapper.Map<List<UserDto>>(users);
    }

    public async Task<UserDto?> GetByIdAsync(int id)
    {
        var user = await _userRepository.GetAsync<User>(id);
        return _mapper.Map<UserDto>(user);
    }
}
