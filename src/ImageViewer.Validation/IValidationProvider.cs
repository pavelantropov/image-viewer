using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using FluentValidation;

namespace ImageViewer.Validation;

public interface IValidationProvider
{
	/// <summary>
	///		Асинхронная валидация типизированного объекта с возвратом результата.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="item">Текущее значение проверяемого объекта</param>
	/// <param name="ruleSet">Опционально: кодовое наименование набора правил</param>
	/// <param name="exceptionOnMinSeverity">
	///		Опционально: выдавать исключение при сообщениях с минимальным заданным уровнем (по умолчанию - Error)
	/// </param>
	/// <returns></returns>
	Task<IEnumerable<ValidationResult>> ValidateAsync<T>([NotNull] T item,
		CancellationToken cancellation = default,
		string? ruleSet = null,
		Severity? exceptionOnMinSeverity = Severity.Error);

	/// <summary>
	///		Асинхронная валидация типизированного объекта с возвратом результата.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="item">Текущее значение проверяемого объекта</param>
	/// <param name="originalItem">Исходное значение проверяемого объекта</param>
	/// <param name="ruleSet">Опционально: кодовое наименование набора правил</param>
	/// <param name="exceptionOnMinSeverity">
	///		Опционально: выдавать исключение при сообщениях с минимальным заданным уровнем (по умолчанию - Error)
	/// </param>
	/// <returns></returns>
	Task<IEnumerable<ValidationResult>> ValidateAsync<T>([NotNull] T item,
		T originalItem,
		CancellationToken cancellation = default,
		string? ruleSet = null,
		Severity? exceptionOnMinSeverity = Severity.Error);
}