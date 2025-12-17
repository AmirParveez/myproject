using api.Helpers;
using api.BLL;

var builder = WebApplication.CreateBuilder(args);

// 🔹 Connection string
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Connection string not found");

// 🔹 SqlHelper
builder.Services.AddSingleton(new SqlHelper(connectionString));

// 🔹 BLLs
builder.Services.AddScoped<UserLoginBLL>();
builder.Services.AddScoped<TransportBLL>();
builder.Services.AddScoped<BusStopBLL>();

// 🔹 Controllers + Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 🔹 SESSION (🔥 REQUIRED)
builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromHours(8);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// 🔹 CORS (for React + session)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReact", policy =>
    {
        policy.WithOrigins("http://localhost:3000")
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials();
    });
});

var app = builder.Build();

app.UseRouting();
app.UseCors("AllowReact");

app.UseSession();      // 🔥 MUST BE HERE
app.UseAuthorization();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();
app.MapGet("/", () => "API is running");

app.Run();
