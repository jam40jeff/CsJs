CsJs
====

A C# MVVM Framework using the Saltarelle compiler to generate JavaScript code.

License
-------

The entire project is licensed under the Apache License 2.0, which is a permissive license, so there is no issue using the software in any kind of application, commercial or non-commercial.

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

Currently, CsJs is in an alpha stage.  However, the ideas are firmly in place and waiting to be expanded upon.  A proof-of-concept application is included to show the ease with which applications may be built using this framework.

The SOAP Client is fully working as well as the web service client generator.  There are likely to be some bugs found, but it works pretty well and covers most use cases that would be involved with calling a WCF service.  Support still needs to be added for XML attributes, which would more likely be found with an ASMX web service or a web service written in a non-.NET language.

The building blocks for ViewModels are pretty well in place as well.

The Control suite is where the framework shows its infancy.  Currently, there are only a few controls ready for use.  However, many more are planned for development.  Since this is open source, feel free to add any Controls you would like to see and make a Pull Request.

Building
--------

To build CsJs and run the sample solution, first build the VSIXExtension solution in the Tools folder in the Release configuration.  Then install the VSIX file in the ExtensionPackage\bin\Release folder.

Next, build the Core solution in Release configuration twice.  (The first build misses copying one of the ouput JavaScript files to the bin directory.  I am looking into why this happens and will correct it soon.)

Finally, build the CalculatorsAndStopwatch solution in the Examples folder, and start the Server.Web.UI project.

In order to successfully browse the site, you may need to assign the Read & execute, List folder contents, and Read permissions to the Application Pool user and the IIS Web Site anonymous user.  Usually, assigning these permissions to the Users group will suffice.

The sample application shows the functionality of the controls developed so far.  Switching pages (the button at the top) will allow you to see different portions of functionality in development, such as the grid control.  On the starting page, switching to Calculator 2 will cause the calculator to call through a web service to obtain its result rather than computing it on the client.  The Simulate Latency option will randomly sleep up to 5 seconds on the server to test the async functionality.  Setting this property to No showcases the speed with which web service calls may be made.

Feedback
--------

All feedback is welcome.  Feel free to open an Issue or contribute code to the project.
