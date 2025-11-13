namespace Backend.Endpoints;
using Backend.Services.ProductServices;
public static class ProjectEndpoint
{
    public static void MapEndpoint(this WebApplication app)
    {
        var Group = app.MapGroup("/api/project");
        Group.MapGet("/", async (ProjectCRUD crud) =>
        {
            var services = await crud.CrudServices("Francis");
            return Results.Ok(services);
        });
    }
}