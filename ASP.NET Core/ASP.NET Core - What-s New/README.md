## What You'll Learn
This workshop is a 75-90 minute introduction to ASP.NET Core 2.1. It begins with a quick overview of ASP.NET Core fundamentals (including tools and solution structure). It then digs into some specific ASP.NET Core 2.1 features, with a deep dive into real-time communications with SignalR.

 * Getting started with ASP.NET Core
     * Creating a new ASP.NET Core application
     * Understanding how ASP.NET Core source code is organized
 * Razor Pages
 * New Features in the ASP.NET Core 2.1 release
 * Feature overview
    * HttpClientFactory
    * HTTPS / GDPR
    * Razor / Identity UI as a library
    * Web API
 * SignaR: real-time communications for ASP.NET Core
 * Getting started
 * Exploring an advanced SignalR Sample Application

## Prerequisites
  1. .NET Core SDK (version 2.1.300-preview1 or higher) [[download](https://www.microsoft.com/net/download)]
  2. Visual Studio *or* Visual Studio Code (latest public release) [[download](https://www.visualstudio.com/)] 

## Setup
>  Note: For BUILD Instructor Led Labs, all setup steps have been completed on the lab virtual machine.

---

## Exercises

1. [Getting Started](#Exercise1)
1. [Razor Pages](#Exercise2)
1. [ASP.NET Core 2.1 Features](#Exercise3)
1. [SignalR](#Exercise4)

<a name="Exercise1" ></a>
### Exercise 1: Getting Started with ASP.NET Core ###

(10 minutes)
1. Tools overview by instructor(2 minutes)
    1. SDK
    2. CLI
    2. Visual Studio Code
    3. Visual Studio

    >Note: The instructor will give a quick overview of the tools from slides and dot.net website.
2. File / New Project
    1. Open Visual Studio 2017 and select File / New Project from the menu.
    !IMAGE[ex1-new-project.png](ex1-new-project.png)
    2. Select **Visual C#** / **Web** / **.NET Core** / **ASP.NET Core Web Application** as the project type. Pick a name for the application (e.g. *Build2018*) and press **OK**.
    !IMAGE[ex1-name-the-project.png](ex1-name-the-project.png)
    3. Ensure **ASP.NET Core 2.1** is selected at the top of the project options dialog. Select **Web Application**, ensure the other options are as shown in the screenshot below, and press **OK**.
    !IMAGE[ex1-project-options.png](ex1-project-options.png)

3. Solution overview
    1. Program.cs
    
        Open the `Program.cs` file in the root of the project. An ASP.NET Core Application is a console application that creates its own web server in the [`Main`](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/?tabs=aspnetcore2x) method. The `Program.cs` code is short and generic, as the application specific code is placed in a separate `Startup` class.
    2. Startup.cs

        The [`Startup`](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/startup) class prepares the the web application to start by configuring services and the app's request pipeline.
        
        >Note: If you have worked with previous versions of ASP.NET, you've configured applications using a combination of C# code (in `global.asax`) and XML (in `web.config`). In ASP.NET Core, the application's configuration is code-based, giving you much more control: you can debug it, add conditional logic, etc.
    3. Pages
        1. Home
        
            Expand the `Pages` folder and open the `Index.cshtml` file. This is the home page of the site, built using Razor Pages. Razor Pages is a new feature of ASP.NET Core MVC that makes coding page-focused scenarios easier and more productive.
            
            >Note: If you have previously used ASP.NET MVC, you'll notice a lot of similarities and a few differences. Razor Pages are an abstraction that is built on top of ASP.NET MVC. It allows for a page focused web development model, with a backing page model class and methods that map to HTTP verbs, like `OnGet` and `OnPost`. However, the view code is similar to MVC views, and is written using Razor syntax.
        2. Layout
        
            Open the `Pages\Shared\_Layout.cshtml` file. This layout defines common page elements, such as page headers and footers.
4. Run the application

    1. Run the application by pressing `Ctrl+F5` or using the *Debug* | *Start Without Debugging* menu in Visual Studio.
    2. You will be prompted to install a certificate to support HTTPS development on localhost as shown in the images below. Click **Yes** on both prompts. !IMAGE[ex1-https-prompt-1.png](ex1-https-prompt-1.png)
    !IMAGE[ex1-https-prompt-2.png](ex1-https-prompt-2.png)
    3. The new web application should be displayed in the browser as shown below.
    !IMAGE[ex1-running-the-new-application.png](ex1-running-the-new-application.png)
    4. Close the browser and stop application in Visual Studio.

<a name="Exercise2" ></a>
### Exercise 2: Working with Razor Pages in ASP.NET Core ###

(20 minutes)
1. Create a new basic page
  1. Right-click on the **Pages** directory in the **Solution Explorer** and select **Add** / **Razor Page...**.
  !IMAGE[ex2-add-razor-page.png](ex2-add-razor-page.png)
  2. On the resulting dialog, leave **Razor Page** selected and click **Add**.
  3. On the **Add Razor Page** dialog, name the page *CurrentTime* and press the **Add** button.
  !IMAGE[ex2-name-razor-page.png](ex2-name-razor-page.png)
  4. Add a `string Message` property to the `CurrentTime.cshtml.cs` class and initilize it show the current time as shown in the code block below, then save the file:
    ```C#
    namespace Build2018.Pages
    {
        public class CurrentTimeModel : PageModel
        {
            public string Message { get; set; }
    
            public void OnGet()
            {
                Message = $"The current time is {System.DateTime.Now}";
            }
        }
    }
    ```

  5. Add the following to the bottom of `CurrentTime.cshtml`:
    ```C#
    <p>
        @Model.Message
    </p>
    ```
  6. Run the application using **Ctrl-F5** and browse to `/CurrentTime`. You should see a the message displayed as shown below: !IMAGE[ex2-current-time.png](ex2-current-time.png)

2. Create a model class (Project: Name, GithubUrl)
    1. Right-click on the project and select **Add** / **Class...**. Name the class `GitHubProject.cs` and click **Add**.
    2. Add a `string Name` and `string GitHubPage` property to the class as shown below:
    ```C#
    namespace Build2018
    {
        public class GitHubProject
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public string GitHubPage { get; set; }
        }
    }
    ```

3. Scaffold pages for class
    1. Right-click on the **Pages** folder and select **Add** / **New Scaffolded Item...**. Select **Razor Pages using Entity Framework (CRUD)** and press the **Add** button.
    2. Select **GitHubProject** as the Model Class. 
    3. Click the **+** button to add a new *Data Context class*. Leave the default name and click the **Add** button. Select the newly created data context class from the dropdown, then click the **Add** button at the bottom of the dialog. When prompted to replace the **Index** and **Index.cshtml.cs** files, select **Yes**.
        > Note: In the following steps, we will be manually creating and running a database migration using Entity Framework. The following steps are only required because we selected a project template with *No Authentication* selected. The project templates which include authentication include a web-based UI for running our first Entity Framework Migration. We intentionally left authentication for later to show off some new features in ASP.NET Core 2.1, but keep in mind that these steps are not normally required.

    4. Open the **Package Manager** window using the **View** / **Other Windows** / **Package Manager** menu.
    5. In the **Package Manager** windows, type `Add-Migration Initial` and press enter.
    6. When the above command completes, type `Update-Database` and press enter.
    7. Run the application. The home page will now show an empty list of projects.

4. Examine the scaffolded pages (instructor will overview).

<a name="Exercise3" ></a>
### Exercise 3: New Features in ASP.NET Core 2.1 ###

(25 minutes) In this section, you will learn about some of the top new features for ASP.NET Core 2.1.
1. Overview (2 minutes)
2. HTTPS
    1. In `Startup.cs`, find the `app.UseHttpsRedirection();` command. This call to the HTTPS redirection middleware will automatically redirect HTTP requests to the HTTPS endpoint.
    2. Run the application and modify the URL to change `https` to `http`. Notice that you are automatically redirected back to the HTTPS endpoint.
    3. Right-click on the project and select view the project properties. Select the **Debug** tab. Note that **Enable SSL** is checked.
        
        > Note: You can read more about Improvements for using HTTPS in [this blog post](https://blogs.msdn.microsoft.com/webdev/2018/02/27/asp-net-core-2-1-https-improvements/).

3. GDPR

    ASP.NET Core 2.1 includes several features to help you build GDPR compliant web applications. These include HTTPS, Cookie Consent, and Data Control. HTTPS features have been described in the previous section. In this section, we will look at cookie consent and data control features.
    1. Run the application and notice the cookie consent dialog at the top of each page.!IMAGE[ex3-cookie-consent-prompt.png](ex3-cookie-consent-prompt.png)

        > Note: You can read more about GDPR Enhancements in ASP.NET Core 2.1 in [this blog post](https://blogs.msdn.microsoft.com/webdev/2018/03/04/asp-net-core-2-1-0-preview1-gdpr-enhancements/).

4. Identity UI as a library
5. Web API
6. HttpClientFactory

<a name="Exercise4" ></a>
### Exercise 4: Building Real-time ASP.NET Core applications with SignalR ###

(20 minutes)
1. Intro - https://blogs.msdn.microsoft.com/webdev/2018/02/27/asp-net-core-2-1-0-preview1-getting-started-with-signalr/
2. Advanced - https://github.com/aspnet/SignalR/tree/dev/samples
