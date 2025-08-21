using MagicTheGatheringAPI.Managers;
using MagicTheGatheringAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register the HttpClient for ScryfallService
builder.Services.AddHttpClient<IScryfallService, ScryfallService>(client =>
{
	client.BaseAddress = new Uri("https://api.scryfall.com/");
	client.DefaultRequestHeaders.Add("User-Agent", "MagicTheGatheringAPI/1.0-s.s.sanazaro91");
	client.DefaultRequestHeaders.Add("Accept", "application/json");
});


// Register the Scryfall manager
builder.Services.AddScoped<IScryfallManager, ScryfallManager>();

// Configure named CORS policy for your Blazor app
builder.Services.AddCors(options =>
{
	options.AddPolicy("BlazorAppPolicy", policy =>
	{
		policy.WithOrigins("https://localhost:7149") // Blazor HTTPS port
			  .AllowAnyHeader()
			  .AllowAnyMethod();
	});
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Use named CORS policy
app.UseCors("BlazorAppPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
