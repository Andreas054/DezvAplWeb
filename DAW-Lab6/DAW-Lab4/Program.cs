using DAW_Lab4.Data;
using DAW_Lab4.Helpers.Extensions;
using DAW_Lab4.Helpers.Seeders;
using DAW_Lab4.Repositories.UserRepository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<Lab4Context>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


/*// created eache time they requested
builder.Services.AddTransient<IUserRepository, UserRepository>();
//created once per client request
builder.Services.AddScoped<IUserRepository, UserRepository>();
// created on first request
builder.Services.AddSingleton<IUserRepository, UserRepository>();*/

builder.Services.AddRepositories();
builder.Services.AddServices();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

void SeedData(IHost app)
{
    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();
    using(var scope = scopedFactory.CreateScope())
    {
        var service = scope.ServiceProvider.GetService<UsersSeeder>();
        service.SeedInitialUsers
    }
}