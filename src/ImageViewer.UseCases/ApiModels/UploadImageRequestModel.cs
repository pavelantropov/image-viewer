using Microsoft.AspNetCore.Http;

namespace ImageViewer.UseCases.ApiModels;

public class UploadImageRequestModel
{
	public string Name { get; set; }
	public string Description { get; set; }

	public IFormFile Content { get; set; }
}