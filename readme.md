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

Contents
### 1. Basics
### 2. Working with the CLI
### 3. HandsOn - Querying data (LINQ)
### 4. Testing (xunit)
### 5. HandsOn - Writing test assertions
### 6. Implementing APIs

--- 

## Basics 

- .net and c#
    - https://versionsof.net/
    - https://dotnet.microsoft.com/en-us/download
- IDE
    - Rider
    - VS Code + C# Dev Kit

--- 

## Working with the CLI

- doc: https://learn.microsoft.com/de-de/dotnet/core/tools/dotnet
- Create files and projects with ``dotnet new``
- add a reference or package with ``dotnet add``
- Build your code with ``dotnet build``
- Run your app with ``dotnet run`` or ``dotnet watch``
dotnet add


---
# HandsOn - Querying data with LINQ

Prepared console project ``employees_console`` in branch ``main``.
Open ``Program.cs`` and try to implement the commented requirements.

--- 

## Testing

- Creating a (xunit) test project
- dotnet test
- add it to the solution
- unit test explorer
- writing a first test
- improving test readability  with fluentvalidations

---
# HandsOn - Querying data with LINQ

Prepared branch ``feature/tests``

Write test assertions with xunit and FluentAssertions

Bonus: Theories

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