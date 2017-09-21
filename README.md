Gatherin provides the ability to organize meetups and gatherings.<br/>

Build using ASP.NET MVC, Microsoft Identity and MongoDB.

<b>Instructions to setup MongoDB</b>

Install MongoDb.Driver Nuget package
<br/>
For Ninject in MVC:<br/>
	- For each project that contains dependencies that ninejct should load and inject, create a new class that inherits from NinjectModule and bind each dependeable class using the syntax:<br/>
	- Bind<Type>().To<Type>()<br/>
	- Install Ninject.MVC5 in Presentation<br/>
	- In the NinjectWebCommon that gets added, there are errors in the using statements for Ninject and Ninject.Web.Common. Just replace these lines:<br/>
		- using global::Ninject;<br/>
		- using global::Ninject.Web.Common;<br/>

Load the NinjectModules in the RegisterServices method.
