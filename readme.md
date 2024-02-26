---
marp: true
theme: gaia
_class: lead
paginate: true
backgroundColor: #fff
backgroundImage: url('https://marp.app/assets/hero-background.svg')

---

# .NET + C# Workshop
---
**Table of content:**

- [Basics](#item-1)
- [Working with the CLI](#item-2)
- [Dojo - Querying data (LINQ)](#item-3)
- [Testing (xunit)](#item-4)
- [Dojo - Writing test assertions](#item-5)
- [Implementing APIs](#item-6)

---
## Basics 

- .net and c# versioning and releases
    - https://versionsof.net/
- sdk and runtime downloads
    - https://dotnet.microsoft.com/en-us/download
- recommended IDEs
    - Jetbrains Rider
    - VS Code + C# Dev Kit

--- 

## Working with the CLI

- doc: https://learn.microsoft.com/de-de/dotnet/core/tools/dotnet
- Usefull commands:
  - Create files and projects with ``dotnet new``
  - add a reference or package with ``dotnet add``
  - Build your code with ``dotnet build``
  - Run your app with ``dotnet run`` or ``dotnet watch``


---
# Dojo - Querying data with LINQ

In this lesson you will learn to use the correct .net linq library methods 
to efficiently solve given business requirements

1. Open the console project ``employees_console`` in branch ``main``.
2. Take a quick look through the given project files to understand what is there and what is missing.
2. Implement the missing functions and print your results to the console by using the logging api.

Bonus ⭐: 
Find the performance bug by activating the debug log level
--- 

## Testing

- Creating a (xunit) test project
- dotnet test
- add it to the solution
- unit test explorer
- writing a first test
- improving test readability  with fluentvalidations

---
# Dojo - Writing test assertions

1. Open the prepared branch ``feature/tests``
2. Look into ``EmployeeService`` and try to write test assertions for each of the methods.
2.  Use the xunit test framework and the FluentAssertions library

Bonus ⭐: Use Theories

--- 

--- 

## Implementing APIs

- new webapi
    - minimalapi
    - core
- dependency injection
- configuration

--- 

## Bonus:

Fix issues