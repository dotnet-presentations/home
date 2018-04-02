## Note: Work in progress

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
    1. CLI
    2. VS Code
    3. Visual Studio
2. File / New Project
3. Solution overview
    1. Program.cs
    2. Startup.cs
    3. Pages
        1. Home
        2. Layout
4. Run the application

<a name="Exercise2" ></a>
### Exercise 2: Working with Razor Pages in ASP.NET Core ###

(20 minutes)
1. Create a new basic page
2. Create a model class (Person: Name, Age)
3. Scaffold pages for class
4. Advanced Razor Pages features

<a name="Exercise3" ></a>
### Exercise 3: New Features in ASP.NET Core 2.1 ###

(25 minutes) - sample app, light up all the new features
1. Overview (2 minutes)
2. HttpClientFactory
3. HTTPS / GDPR
4. Razor / Identity UI as a library
5. Web API

<a name="Exercise4" ></a>
### Exercise 4: Building Real-time ASP.NET Core applications with SignalR ###

(20 minutes)
1. Intro - https://blogs.msdn.microsoft.com/webdev/2018/02/27/asp-net-core-2-1-0-preview1-getting-started-with-signalr/
2. Advanced - https://github.com/aspnet/SignalR/tree/dev/samples
