using NewAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpClient<ApiService>(c =>
{
    c.BaseAddress = new Uri("https://catfact.ninja");    //TODO inserire URL API
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//var handler = new SocketsHttpHandler
//{
//    PooledConnectionLifetime = TimeSpan.FromMinutes(15) // Recreate every 15 minutes
//};
//var sharedClient = new HttpClient(handler);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
