﻿using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Ninject;
using Ninject.Web.Common;
using Ninject.Web.Common.WebHost;

namespace ImageViewer.Api.App_Start;

public class NinjectWebCommon
{
	private static readonly Bootstrapper Bootstrapper = new Bootstrapper();

	public static void Start()
	{
		DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
		DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
		Bootstrapper.Initialize(CreateKernel);
	}

	public static void Stop()
	{
		Bootstrapper.ShutDown();
	}

	private static IKernel CreateKernel()
	{
		var kernel = new StandardKernel();
		kernel.BindMediatR();

		try
		{
			kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
			kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
			RegisterServices(kernel);
			return kernel;
		}
		catch
		{
			kernel.Dispose();
			throw;
		}
	}

	private static void RegisterServices(IKernel kernel)
	{
		NinjectRegistration.RegisterAllModules(kernel);
	}
}