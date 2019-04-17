# NetWorthApi
This API allows users to input their current assets and liabilities.  It will then output the current and predicted future net worth of the use. It is built using .NET Core and Entity Framework Core.

The design of this API largely follows the Clean architecture and resembles a lot of the approaches outlined in this video:
[Clean Architecture with ASP.NET Core 2.1](https://www.youtube.com/watch?v=_lwCVE_XgqI&feature=youtu.be)

## Getting Started
Instructions for getting a copy of the project up and running on your local machine.

### Prerequisites
You will need the following tools:
- [Visual Studio Code](https://visualstudio.microsoft.com/downloads/)
- [.NET Core SDK 2.2](https://dotnet.microsoft.com/download/dotnet-core/2.2)

### Setup
These are the steps you'll need to get your environment set up:
1. Clone the repository
2. At the root directory, run the following command to restore required packages:
```
dotnet restore
```
3. In each of the project directories, run the following command to build:
```
dotnet build
```
4. Launch the API by running this command:
```
dotnet start
```
## Technologies
- .Net Core 2.2
- Entity Framework Core 2.2
