# Baseline for API Testing in CSharp

#### Architecture

NUnit (runner and tests) -> RestSharp clients -> DTOs (Data Transfer Objects)

#### What is this?

It's a baseline for API testing in C#, intended to be extended. The **Tests** and assertions are NUnit. The RestSharp **Clients** return **DTOs** (Data Transfer Objects) for the testing assertions.

#### How to set this up and run it?

1. Git clone
2. Assuming you're using the dotnet cli, build the project: `dotnet build`
3. Run the tests (this will trigger NUnit to run) `dotnet test`

#### ToDo:

1. Make this runnable from repository dashboard