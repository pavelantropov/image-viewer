using ImageViewer.Api.ServiceCollectionExtensions;
using ImageViewer.UseCases.ApiModels;
using ImageViewer.UseCases.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddNHibernate(builder.Configuration);
builder.Services.AddUseCases();

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
	async ([FromQuery] string filter, IGetListOfImagesUseCase useCase, CancellationToken cancellationToken) =>
	{
		try
		{
			return Results.Ok(await useCase.Invoke(filter, cancellationToken));
		}
		catch (Exception ex)
		{
			return Results.Problem(ex.Message, statusCode: StatusCodes.Status500InternalServerError);
		}
	})
	.WithName("GetListOfImages")
	.WithOpenApi();

app.MapGet(
	"api/images/{id:int}",
	async ([FromRoute] int id, IGetImageUseCase useCase, CancellationToken cancellationToken) =>
	{
		try
		{
			return Results.Ok(await useCase.Invoke(id, cancellationToken));
		}
		catch (FileNotFoundException)
		{
			return Results.NotFound();
		}
		catch (Exception ex)
		{
			return Results.Problem(ex.Message, statusCode: StatusCodes.Status500InternalServerError);
		}
	})
	.WithName("GetImage")
	.WithOpenApi();

app.MapPost(
	"api/images",
	async ([FromBody] UploadImageRequestModel request, IUploadImageUseCase useCase, CancellationToken cancellationToken) =>
	{
		try
		{
			return Results.Ok(await useCase.Invoke(request, cancellationToken));
		}
		catch (Exception ex)
		{
			return Results.Problem(ex.Message, statusCode: StatusCodes.Status500InternalServerError);
		}
	})
	.WithName("PostImage")
	.WithOpenApi();

app.MapDelete(
	"api/images/{id:int}",
	async ([FromRoute] int id, IDeleteImageUseCase useCase, CancellationToken cancellationToken) =>
	{
		try
		{
			await useCase.Invoke(id, cancellationToken);
			return Results.Ok();
		}
		catch (FileNotFoundException)
		{
			return Results.NotFound();
		}
		catch (Exception ex)
		{
			return Results.Problem(ex.Message, statusCode: StatusCodes.Status500InternalServerError);
		}
	})
	.WithName("DeleteImage")
	.WithOpenApi();

app.Run();
