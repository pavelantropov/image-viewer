using FluentValidation;
using Ninject;

namespace ImageViewer.Api.App_Start;

public class NinjectValidatorFactory : ValidatorFactoryBase
{
	private readonly IKernel _kernel;

	public NinjectValidatorFactory(IKernel kernel)
	{
		_kernel = kernel;
	}

	public override IValidator CreateInstance(Type validatorType) 
		=> _kernel.GetBindings(validatorType).Any() ? _kernel.Get(validatorType) as IValidator : null;
}