using Azure.Identity;

var builder = WebApplication.CreateBuilder(args);
var keyVault = builder.Configuration["KeyVaultName"];
if (!string.IsNullOrEmpty(keyVault))
    builder.Configuration.AddAzureKeyVault(
    new Uri($"https://{keyVault}.vault.azure.net/"),
    new DefaultAzureCredential() // we can use a prefexer here !!
    );
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapGet("/", () =>
{
    return "hello from API";
})
.WithOpenApi();
app.Run();
