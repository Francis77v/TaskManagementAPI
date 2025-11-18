namespace Backend.DTO.AuthDTO;

public class APIResponseDTO<T>
{
    public bool success { get; set; }
    public int statusCode { get; set; }
    public string message { get; set; }
    public T? data { get; set; }
    public List<ErrorDetailDTO>? Errors { get; set; } = new();
}