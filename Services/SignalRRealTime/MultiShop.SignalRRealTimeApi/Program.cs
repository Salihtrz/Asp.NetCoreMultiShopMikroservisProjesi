using MultiShop.SignalRRealTimeApi.Hubs;
using MultiShop.SignalRRealTimeApi.Services.SignalRCommentServices;
using MultiShop.SignalRRealTimeApi.Services.SignalRMessageServices;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient();
// Add services to the container.

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("CorsPolicy", builder =>
    {
        builder.AllowAnyHeader() // Her t�rl� http ba�l���n� kabul eder
                .AllowAnyMethod() // T�m Http metodlar�na izin verir (Get,Post,Put,Delete)
                .SetIsOriginAllowed((host) => true) //Herhangi bir kaynaktan gelen isteklere izin verir.
                .AllowCredentials(); // Kimlik bilgilerini (�erezler, oturum bilgilerinin) i�eren isteklere izin verir.
    });
});

builder.Services.AddSignalR();

builder.Services.AddScoped<ISignalRMessageService , SignalRMessageService>();
builder.Services.AddScoped<ISignalRCommentService , SignalRCommentService>();

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

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapHub<SignalRHub>("/signalrhub"); // localhost://1234/ den sonra gelecek.

app.Run();
