Install MongoDb.Driver Nuget package
For Ninject in MVC:
	For each project that contains dependencies that ninejct should load and inject, create a new class that inherits from NinjectModule and bind each dependeable class using the syntax:
		Bind<Type>().To<Type>()
	Install Ninject.MVC5 in Presentation
	In the NinjectWebCommon that gets added, there are errors in the using statements for Ninject and Ninject.Web.Common. Just replace these lines:
		using global::Ninject;
		using global::Ninject.Web.Common;
	Load the NinjectModules in the RegisterServices method.
