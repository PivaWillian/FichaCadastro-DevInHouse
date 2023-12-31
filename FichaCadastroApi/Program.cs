using FichaCadastroRabbitMQ;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IFactoryConnectionRabbitMQ, FactoryConnectionRabbitMQ>();
builder.Services.AddScoped<IMessageRabbitMQ, MessageRabbitMQ>();

builder.Services.AddRouting(options =>
{
    options.LowercaseUrls = true;           //Faz Endpoints e querys serem minúsculas
    options.LowercaseQueryStrings = true;
});

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
