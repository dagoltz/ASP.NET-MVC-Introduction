
# An introduction to ASP.NET MVC

## What’s a Web Application Framework
In the early days of the internet, when one wanted to develop a dynamic website, he would write **in CPP/Perl** or other languages, perform logic and join together strings that make up a valid HTML file. This script or executable would then be launched as a separate process by the operating system. This method was called **CGI – Common Gateway Interface**.
Later during the 90s, languages & frameworks suited specifically for Web development were created – such as **PHP, Classic ASP, ColdFusion**, and others. These languages operated on a ‘smart’ server that provided integrated modules for these languages, which allowed better performance. The languages themselves were more suited to working with Web projects.
A Web Application Framework is **designed to further reduce overhead costs**, by enforcing a development model of some sort and promote code reuse – and provide many capabilities built-in – such as security, session management, templating and database access.

## The MVC Pattern
The MVC model is made up from three different components – Model, Controller & View.
* **Model** – a simple class representing the data structure of our business object. For example, a Person class would contain a Name, Email, and other relevant properties. A typical Model class does not contain any methods.
* **View** – represents the actual interface the user sees. A view can be an HTML file in the Web context.
* **Controller** – a class which contains methods that implement the business logic of the application. Each method returns a specific View. Before returning the View, we perform the necessary operations – such as querying the database – to have everything we need in the View. 

It’s important to note that MVC is just a design pattern, and the implementation varies between every language and Web Application Framework.

## The Unfortunate Family of ASP.NET
Microsoft has had some troublesome decisions with naming its ASP.NET product family. 

Even though ASP.NET refers to an entire stack in the .NET Framework Class Library, which contains core components for Web Development in the .NET world, most developers think of ASP.NET Web Forms when they hear the name.

**ASP.NET Web Forms** is Microsoft’s older implementation of a Web Application Framework. It attempts to provide a WinForms-like development experience, by defining a subset of HTML, allowing developers to declare ‘controls’ and access them through a Code Behind file. In addition, Web Forms applications have had the ability to store state in them, which was performed by sending the state in a hidden part of the HTML document, back and forth from the client to the server. This created performance issues in larger applications that heavily relied on state.

**ASP.NET MVC** was created on top of the core ASP.NET stack, but differs a lot from the classic ASP.NET WebForms. It was introduced in 2008 and embraces many design standards and conventions that other MVC frameworks, primarily Ruby on Rails, have introduced over the years.

## ASP.NET MVC Components
### ASP.NET MVC Views

 - List item
- Served by the controller to the client
- Somewhat of an HTML page
Allows you to interact with C# models and generate HTML in order to display them
- Can be divided into parts:
	- Partial View – will be rendered within another view
	- Layout Page – will render another regular view within it (like a template)

### View Engines
ASP.NET MVC uses a technique called Templating, to allow us to embed normal, C# code inside our HTML pages. The code we use is interpreted at runtime  by the server, and thanks to the templating engine, ASP.NET MVC ‘knows’ how to replace parts of the HTML with the result of the .NET code interpretation. So if we add 1+1 inside this C# code block, we’ll get 2.
#### ASP.NET MVC allows you to select your own view engine:
- Web forms view engine  – has an ASP-like syntax. It is the default for ASP.NET MVC 1 and 2 applications.
- Razor  – ASP.NET MVC’s 3 and up default engine. Developed by Microsoft
- Spark  – open-source engine that aims to seamlessly integrate code and HTML
- NHaml – an open-source  port of the Ruby on Rails Haml  view engine. Aims to replace HTML tags with an easier to read and better organized syntax

While ASP.NET MVC supports different templating engines, the default and recommended one (that’s also under continued development), is Razor. Modern Razor has only two basic rules:
- The ‘@’ character outside of an HTML tag indicates that the Razor engine should run the code statement and ‘plant’ the result inside the tags that the statement is contained in.
- The ‘@ { }’  (note the curly braces) syntax indicates a block of code that is not to be printed. Within this block of code you can declare variables and perform calculations that can be accessed later in printing templates (of the first kind).

### Layout Page
The layout page system allow us to not repeat the structure of the website every time
- Menu
- Logo
- Footer
- …

The @RenderBody  method inside the Layout page is a placeholder for the specific view. By default, the Layout page is located in Views/Shared/_Layout.cshtml.

### Partial View
Partial views are regular views, without a model and without a Layout. They provide a way to brake up your view into reusable chunks. Simply call The @Html.Partial  method as a placeholder for a partial view.

### ASP.NET MVC Controllers
Unlike Views, Controllers are regular C# classes. Every controller inherits from “Controller”, which contains a basic set of properties & methods you can use:
- Create a new View instance and return it
- View the HTTP request in the current context
- Modify the response headers
- Authenticate and authorize the user

A public Controller method that returns a View (ActionResult) is called an Action. By default, every Action only responds to HTTP GET verbs.

### Session
The Session dictionary allow you to store state data for the current session. Keep in mind it is best to keep your application stateless.

### Sharing data between Controller & View
There are two basic ways to share data between the Controller and View.
#### Controller Model Binding
Bind a specific model instance to the View using a special syntax, and access it from the View using the Model keyword.
This is the best way, since it is more testable, and compiled – so you minimize runtime errors. In the second method, if you attempt to access a property on the dynamic object which doesn’t exist, you’ll get a runtime error since dynamic objects are resolved at runtime. In addition, it’s less efficient. However, there are times when we want to share small pieces of data that we don’t want to embed in our model classes, and this is when ViewBag and ViewData could be useful. You can also precompile your views and have your compiler fail on any error.

#### Shared Objects
Special properties that are shared between the Controller and View:
- ViewBag- a dynamic object
- ViewData – a dictionary object
- TempData, also a dictionary – will live to your next request

### ASP.NET MVC Routing
- Routing means translating a URL to an actual Controller Action.
- Default routing template: http://www.mysite.com/{controller}/{action}
- Routing also allows us to pass parameters to an Action, For example:
	- http://www.mysite.com/person/getall
	- http://www.mysite.com/person/getall?name=Daniel
- When there’s no Action specified, ASP.NET MVC will use Index
- You can customize routing in the RouteConfig.cs file

### Conventions, Conventions, Conventions
ASP.NET MVC has many built-in conventions to save boilerplate code. It’s not magic – it’s just conventions.
#### Structure Conventions
- Controllers, Models (ViewModels, not generic Models) and View always have to be in their respectively named folders.
- The Content folder is the only folder which has a special setting allowing it to serve content. For example, you’ll want to store your images and resources under this folder. If you try placing a file under another folder – for example, AppStart, you’ll get an error when trying to access it in the browser. IIS blocks this.
- App_Start contains all the settings. They are loaded by reflection so you cannot move them

#### Naming Conventions:
- If you want to use return new View(), you’ll need to put the View in the same folder structure and give it the same name as the Controller Action method. It’s possible to call an overload of this method and provide an explicit, different name – but I do not recommend you do this.
- Controllers always have to be named SomethingController, and when routing to a Controller, the URL will omit the Controller segment.

### Bundling in ASP.NET MVC
Your View will probably need a few CSS and JS files in your website. Requesting each resource individually take time and bandwidth.
ASP.NET MVC enables you to load more than one resource in a single request. You can create a ScriptBundle or a StyleBundle and define what resources will be brought when fetched.
The bundle can also be minified to optimize its size:
- Removing white space and comments
- Shortening variable names

Bundles are registered in the BundleConfig file, they are used in view, mostly the Layout page.

## Entity Framework CF & ASP.NET MVC
Entity Framework Code First is to ASP.NET MVC as what ActiveRecord is to Ruby On Rails. EF CF work together nicely with ASP.NET MVC, even though the technologies aren’t necessarily as coupled as they are as with AR and RoR (EF is a separate NuGeT package, though included with ASP.NET MVC).

When you use ASP.NET MVC with EF CF, it is extremely important you follow the best practices described in this presentation, otherwise bad things can happen.

### Best Practices with Entity Framework in MCV
- **Instantiate your DbContext in every Controller’s c’tor, separately**
Never create a singleton DbContext - DbContext classes are not built for concurrent calls.
It’s best to not declare the DbContext inside an Action
- **Dispose of the DbContext instance**
Override the Controller’s Dispose method and dispose of the DbContext instance.
If declared within an action: initialize it inside a “using” block.
Failure to dispose will leave an SqlConnection open for every HTTP request.
- **Enumerate data before passing it into View**
The DbContext will be disposed before the View is returned.
If the View is forced to enumerate a result from the DB, you’ll get an exception.

### ASP.NET MVC’s successor
Web pages + MVC + Web API = **MVC 6**

ASP.NET Core is an open-source re-implementation of ASP.NET as a modular web framework, together with other frameworks like Entity Framework.
The new framework uses the open-source .NET Compiler Platform (codename "Roslyn") and is cross platform.
