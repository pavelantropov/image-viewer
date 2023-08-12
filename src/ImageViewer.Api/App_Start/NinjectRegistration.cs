using System.Reflection;
using Ninject;

namespace ImageViewer.Api.App_Start;

public class NinjectRegistration
{
	public static void RegisterAllModules(IKernel kernel)
	{
		kernel.Load(Assembly.GetExecutingAssembly());

		kernel.Bind<>
	}
}