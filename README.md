# KoboldSharp

A C# package for interfacing with [koboldcpp](https://github.com/LostRuins/koboldcpp)'s REST API

# Installation

## With .NET CLI
```
dotnet add package KoboldSharp
```

## With Package Manager
```
NuGet\Install-Package KoboldSharp -Version 0.0.2
```

# Usage

```csharp
using KoboldSharp;

// Replace 127.0.0.1 with the ip/hostname of the host running Koboldcpp
KoboldClient client = new KoboldClient("http://127.0.0.1:5001");

var parameters = new GenParams("Hello my name is ");

// multiple parameters can be adjusted, such as max length, temperature etc...
parameters.MaxLength = 10;

var result = await client.Generate(paramaters);

Console.WriteLine(result.Results[0].Text);
```