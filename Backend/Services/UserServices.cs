namespace Backend.Services;
using Backend.Repository;
using Backend.DTO.AuthDTO;

public class UserServices
{
    private readonly UserRepository _repository;

    public UserServices(UserRepository repository)
    {
        _repository = repository;
    }

    public async Task<string> registerUser(RegisterDTO user)
    {
        var response = await _repository.AddUser(user);
        return response;
    }
}