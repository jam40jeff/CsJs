CsJs
====

A C# MVVM Framework using the Saltarelle compiler to generate JavaScript code.

Features
--------

CsJs is built to be a strongly-typed MVVM framework which allows all coding to be in C#, while retaining the benefits of running the application on the client.  To accomplish this, the framework is built upon the Saltarelle Runtime and uses the Saltarelle Compiler to transpile to JavaScript.

The Views are written by combining Controls together to form Pages.  The Pages are registered with an Application.  The Application lives within a single ASPX page, making this a Single-Page Application framework.

Views may be coded in C# or using a markup model similar to ASPX.  Bindings are always done in the code of the Control.  (All Controls have code.  Markup is simply run through a custom tool which generates the code to create the Control.)  This allows for an easy, strongly-typed, and less error-prone method of binding than the declarative binding found in so many other frameworks.

ViewModels are also written in C# but transpiled into JavaScript to run in the browser.  A base framework has been started, including IObservable<T> objects such as ObservableProperty<T>, CalculatedProperty<T>, AsyncCalculatedProperty<T> and more.

A SOAP Client is included so that the ViewModels may communicate through web service to a business layer running on a web server.  Also, CsJs includes a custom tool which reads a web service's WSDL to generate a typed client class to make it effortless to call these web services.

Why?
----

CsJs was created to fill a void in web development.  Currently, much web development is done such that the UI runs on the server, just spitting HTML to the browser to run.  Any actions are sent back to the server and then more HTML is rendered back.  JavaScript is only used when absolutely necessary.  Obviously, this is less efficient than having the UI logic run directly in the browser.

On the other hand, some applications leverage JavaScript more heavily.  However, many (such as myself) feel that JavaScript does not scale well with large teams and the developer experience is subpar when compared to a language such as C#.  Many developers are comfortable with C#, love the Visual Studio IDE, and find things like strongly-typed code, compilation errors, and real IntelliSense to drastically cut down development time and produce a more stable, maintainable, self-documenting application, especially when combined with a development pattern such as MVVM.

To try to merge the best of both worlds together, CsJs was created.  The goal is to provide the benefits C# brings with the benefits of running code in the browser through JavaScript, such that no plugin is required and virtually every browser in use today will be able to run the code.

Status
------

Currently, CsJs is as alpha as can be.  If an alpha version is 0.1, this is 0.01.  However, the ideas are firmly in place and waiting to be expanded upon.  A proof-of-concept application is included to show the ease with which applications may be built using this framework.

The SOAP Client is fully working as well as the web service client generator.  There are likely to be some bugs found, but it works pretty well and covers most use cases that would be involved with calling a WCF service.  Support still needs to be added for XML attributes, which would more likely be found with an ASMX web service or a web service written in a non-.NET language.

The building blocks for ViewModels are pretty well in place as well.

The Control suite is where the framework shows its infancy.  Currently, there are only a few controls ready for use.  However, many more are planned for development.  Since this is open source, feel free to add any Controls you would like to see and make a Pull Request.
