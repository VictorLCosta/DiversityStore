using Api.Infrastructure.Persistence;
using Api.Web.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddWebServices(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(opt => {
        opt.SwaggerEndpoint("/swagger/v1/swagger.json", "Api v1");
        opt.RoutePrefix = String.Empty;
    });

    using (var scope = app.Services.CreateScope())
    {
        var initialiser = scope.ServiceProvider.GetRequiredService<ApplicationDbContextInitialiser>();
        await initialiser.InitialiseAsync();
        await initialiser.SeedAsync();
    }
}

app.UseMiddleware<ExceptionMiddleware>();
app.UseMiddleware<SaveChangesMiddleware>();

app.UseRouting();

app.UseCors();

app.UseHealthChecks("/health");
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
