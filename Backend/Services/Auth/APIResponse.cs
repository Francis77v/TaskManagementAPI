using Backend.DTO.AuthDTO;

namespace Backend.Services.Auth;

public class APIResponse
{
    public static APIResponseDTO<T> SuccessResponse<T>(T data)
    {
        return new APIResponseDTO<T>
        {
            success = true,
            statusCode = 200,
            message = "Success",
            data = data,
        };
    }

    public static APIResponseDTO<T> ErrorResponse<T>(string errorMessage, int status)
    {
        return new APIResponseDTO<T>
        {
            success = false,
            statusCode = status,
            message = errorMessage,
            data = default(T),
        };
    }
}