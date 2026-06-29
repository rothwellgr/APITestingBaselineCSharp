# restsharp-baseline

Baseline for testing RESTful APIs. Tests decoupled -> HTTP clients decoupled -> DTOs decoupled (Data Transfer Objects).

#### Usage

Docker needs to be running. Run tests against a local httpbin container by default:

```sh
make build        # Build the docker image
make test         # Run tests against local httpbin
```

Or run against the live site:

```sh
make build
make test-remote  # Run tests against remote httpbin - this is a public service and can be 503 service unavailable
```

Or run tests from inside the container against the httpbin container:

```sh
make build
make shell        # Open a shell in the container
dotnet test       # Run tests from inside
```

#### What's inside

- .NET 8.0 SDK on Debian
- NUnit as the test framework
- RestSharp for HTTP clients
- Local httpbin container for reliable offline testing
- DTOs (Data Transfer Objects) for assertions

#### ToDo

- [ ] tidy up Jenkins
- [ ] tidy up C# code
- [ ] tidy up readme