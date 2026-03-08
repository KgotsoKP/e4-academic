using Academic.Api.Services.Students;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();
    builder.Services.AddScoped<IStudentService, StudentService>();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
}

var app = builder.Build();
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger(options =>
        {
            options.RouteTemplate = "/openapi/{documentName}.json";
        });
        app.MapScalarApiReference();
    }

    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();
    app.MapControllers();  
    app.Run();
}
