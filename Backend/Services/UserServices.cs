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

    public async Task<APIResponseDTO<LoginDTO>> registerUser(RegisterDTO user)
    {
        try
        {
            if (user.confirmPassword != user.password)
            {
                return new APIResponseDTO<LoginDTO>
                {
                    success = false,
                    statusCode = 404,
                    message = "Incorrect Password",
                    Errors = new List<string> {"Password mismatched."}
                };
            }
            var checkUser = await _repository.UserExists(user.username, user.email);
            if (checkUser)
            {
                return new APIResponseDTO<LoginDTO>
                {
                    success = false,
                    statusCode = 400,
                    message = "User already exists.",
                    Errors = new List<string> { "Username or email is already taken." }
                };
            }
            var response = await _repository.AddUser(user);
            return new APIResponseDTO<LoginDTO>
            {
                success = true,
                statusCode = 200,
                message = $"Welcome {user.username}. Account Created.",
                data = null
            };
            
        }
        catch (Exception e)
        {
            return new APIResponseDTO<LoginDTO>
            {
                success = false,
                statusCode = 500,
                message = e.Message,
                data = null
            };
        }
        
    }
}