namespace ImageViewer.Validation;

/// <summary>
///		Wrapper для объекта типа <see cref="T"/>, содержащий его исходное и текущее значения.
/// </summary>
/// <typeparam name="T"></typeparam>
public class ValidatedObjectWrapper<T> where T : class
{
	/// <summary> Текущее значение </summary>
	public T Value { get; set; }
	
	/// <summary> Исходное значение </summary>
	public T? OriginalValue { get; set; }

	public ValidatedObjectWrapper(T value, T originalValue)
	{
		Value = value;
		OriginalValue = originalValue;
	}

	public ValidatedObjectWrapper(T value)
	{
		Value = value;
	}
}