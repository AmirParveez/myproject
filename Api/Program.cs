using api.Helpers;
using api.BLL;

var builder = WebApplication.CreateBuilder(args);

// 1️⃣ Connection string
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
                       ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

// 2️⃣ Register SqlHelper (VERY IMPORTANT)
builder.Services.AddSingleton<SqlHelper>(sp => new SqlHelper(connectionString));

// 3️⃣ Register BLL services
builder.Services.AddScoped<UserLoginBLL>();
builder.Services.AddScoped<ClassesBLL>();
builder.Services.AddScoped<SectionsBLL>();
builder.Services.AddScoped<StudentsBLL>();
builder.Services.AddScoped<TransportBLL>();
builder.Services.AddScoped<BusStopBLL>();
builder.Services.AddScoped<StudentBLL>();



// 4️⃣ Controllers + swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 5️⃣ CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

app.UseRouting();
app.UseCors("AllowAll");
app.UseAuthorization();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();
app.MapGet("/", () => "API is running");

app.Run();
