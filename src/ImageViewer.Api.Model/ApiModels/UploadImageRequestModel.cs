using Microsoft.AspNetCore.Http;

namespace ImageViewer.Api.Model.ApiModels;

public class UploadImageRequestModel
{
	public string Name { get; set; }
	public string Description { get; set; }

	public IFormFile Content { get; set; }
}