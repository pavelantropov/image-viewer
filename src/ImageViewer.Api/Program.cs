using ImageViewer.UseCases;
using ImageViewer.UseCases.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
	options.SwaggerDoc("v1", new OpenApiInfo
	{
		Version = "v1",
		Title = "Image Viewer",
		Description = "Image Viewer Web Api by Pavel Antropov",
		Contact = new OpenApiContact
		{
			Name = "Pavel Antropov",
			Url = new Uri("https://www.linkedin.com/in/pavelantropov/")
		},
	});
	options.EnableAnnotations();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI(options => {
		options.SwaggerEndpoint("./swagger/v1/swagger.json", "Image Viewer Web Api");
		options.RoutePrefix = string.Empty;
	});
}

app.UseHttpsRedirection();

app.MapGet(
	"api/images",
	async ([FromQuery] string? filter, IGetListOfImagesUseCase useCase, CancellationToken cancellationToken) =>
		await useCase.Invoke(filter, cancellationToken))
	.WithName("GetImages")
	.WithOpenApi();

app.MapGet(
	"api/images/{id}",
	async ([FromRoute] string id, IGetImageUseCase useCase, CancellationToken cancellationToken) => 
		await useCase.Invoke(id, cancellationToken))
	.WithName("GetImage")
	.WithOpenApi();

app.MapPost(
	"api/images",
	async ([FromBody] ImageDto imageDto, IPostImageUseCase useCase, CancellationToken cancellationToken) =>
		await useCase.Invoke(imageDto, cancellationToken))
	.WithName("PostImage")
	.WithOpenApi();

app.MapDelete(
	"api/images/{id}",
	async ([FromRoute] string id, IDeleteImageUseCase useCase, CancellationToken cancellationToken) =>
		await useCase.Invoke(id, cancellationToken))
	.WithName("PostImage")
	.WithOpenApi();

app.Run();
