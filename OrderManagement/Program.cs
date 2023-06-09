using Microsoft.EntityFrameworkCore;
using OrderManagement.API.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer("name=LocalConnection"));

var app = builder.Build();

//SeedDb(app);
//void SeedDb(WebApplication app)
//{
//    IServiceScopeFactory? scopedFactory = app.Services.GetService<IServiceScopeFactory>();

//    using (IServiceScope? scope = scopedFactory!.CreateScope())
//    {
//        SeedDb? service = scope.ServiceProvider.GetService<SeedDb>();
//        service!.SeedAsync().Wait();
//    }

//}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true)
    .AllowCredentials());

app.Run();