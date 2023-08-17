using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using FluentValidation;
using NLog;

namespace ImageViewer.Validation;

public class FluentValidationProvider : IValidationProvider
{
	private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

	private readonly IServiceProvider _serviceProvider;

	public FluentValidationProvider(IServiceProvider serviceProvider)
	{
		_serviceProvider = serviceProvider;
	}

	public async Task<IEnumerable<ValidationResult>> ValidateAsync<T>([NotNull] T item,
		CancellationToken cancellation = default,
		string? ruleSet = null,
		Severity? exceptionOnMinSeverity = Severity.Error)
	{
		throw new NotImplementedException();
	}

	public async Task<IEnumerable<ValidationResult>> ValidateAsync<T>([NotNull] T item,
		T originalItem,
		CancellationToken cancellation = default,
		string? ruleSet = null,
		Severity? exceptionOnMinSeverity = Severity.Error)
	{
		throw new NotImplementedException();
	}
}