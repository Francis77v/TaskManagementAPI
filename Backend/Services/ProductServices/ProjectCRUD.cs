namespace Backend.Services.ProductServices;

public class ProjectCRUD
{
    public async Task<string> CrudServices(string name)
    {
        await Task.Delay(100);
        return name;
    }
}