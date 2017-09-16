Install MongoDb.Driver Nuget package
For Ninject in MVC:
	Install Ninject.MVC5 in Presentation
	In the NinjectWebCommon that gets added, there are errors in the using statements for Ninject and Ninject.Web.Common. Just replace these lines:
	using global::Ninject;
	using global::Ninject.Web.Common;