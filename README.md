# Logging (.Net MVC 5 project)


1. For database; please execute script.sql file in MS Sql Server 2012 or higher.
2. Configure your connection string in web.config file.

This project is developed to show Open/Closed Principle and Dependency Inversion Design Pattern using SimpleInjector IOC Container.
We have two logging mechanism in this project. log4Net and NLog. Both of them implement ILogManager interface. 
I used Adapter Design Pattern in ILogManager.

Log technologies are located at MSB.Core/CrossCuttingConcerns/Logging

You can use whatever Logging technology you want. 
All you need is uncommenting the binding at Global.asax file which is located at Northwind.MvcUI

              container.Register<ILogManager, Log4NetManager>(Lifestyle.Scoped);
            //container.Register<ILogManager, NLogManager>(Lifestyle.Scoped);

For now; I only used one Info logging. Please look at in Northwind.Business/Concrete/ProductManager.cs to the List<Product> GetAll() method.
As you can see _logManager.Info("Ürün Listesi getirildi") writes the output to the identified file in config files.
The config files are log4net.config and NLog.config.
They are located at Northwind.MvcUI project.
At this moment; log4net writes to log-file.txt and NLog writes to file.txt in Northwind.MvcUI folder.
