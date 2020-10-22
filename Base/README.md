# Base Framework Setup Instructions

## Instructions

Below are the steps to add the base framework to a dotnet webapi project.

## Step 1. Install dotnet core SDK

Download and install dotnet core SDK from the following URL:

https://dotnet.microsoft.com/download

## Step 2. Create webapi Project

Run the following command to cerate a new webapi project:

```
dotnet new webapi -n ProjectName
```

Edit the `ProjectName.csproj` file to specify whether you will use `Oid` or `Id` as your key suffix.

```xml
<PropertyGroup>
  ...
  <!-- Use only one of the following settings for Oid or Id key suffix -->
  <DefineConstants>USE_KEY_SUFFIX_ID</DefineConstants> 
  <DefineConstants>USE_KEY_SUFFIX_OID</DefineConstants> 
</PropertyGroup>
```

Alos, add the following dependencies to the `ProjectName.csproj` file:

```xml
<ItemGroup>
  ...
  <!-- Add the following dependencies -->
  <PackageReference Include="PetaPoco.Compiled" Version="6.0.353" />
  <PackageReference Include="PetaPoco.SqlKata" Version="1.2.2" />
  <PackageReference Include="Swashbuckle.AspNetCore" Version="4.0.1" />
  <PackageReference Include="System.Data.SqlClient" Version="4.6.0" />
  <PackageReference Include="Npgsql" Version="4.0.4" />
</ItemGroup>
```

## Step 3. Copy Base Directory

Copy the `Base` framework directory to the root `ProjectName` directory.

## Step 4. Update Startup.cs

Locate and update the `Startup.cs` file with the following changes:

```csharp
using Base; // <-- Add line (TODO: update when namespace is finalized)

public void ConfigureServices(IServiceCollection services)
{
    var mvc = services.AddMvc();
    mvc.SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
    services.AddBaseFramework(mvc, Configuration); // <-- Add line
}

public void Configure(IApplicationBuilder app, IHostingEnvironment env)
{
    // ..
    app.UseBaseFramework(); // <-- Add line
}
```

## Step 5. Update appsettings.Development.json

Add the following to the `appsettings.json` file:

```json
"Api": {
  "Name": "ProjectName API",
  "Version": "v1"
},
"DataSource": {
  "ProviderName": "database_provider_name",
  "ConnectionString": "database_connection_string"
}
```

Add the following sections to the `appsettings.Development.json` file:

```json
"DataSource": {
  "ProviderName": "System.Data.SqlClient",
  "ConnectionString": "Data Source=192.168.56.102;Initial Catalog=PAS3_STEMILT;User ID=sa;Password=Abcd1234;Max Pool Size=10",
  "GeneratorSchema": "dbo",
  "GeneratorNamespace": "Horizon"
}
```

## Step 6. Run Generator

Run the following command to install support for running `csx` scripts. You may have to restart your command prompt after the installation completes.

```
dotnet tool install -g dotnet-script
```

Run the following command to run the generator:

```
dotnet script --no-cache .\Base\Generator\Generate.csx
```

If you want to run the generator from within Visual Studio, you can add an External Tool entry:

```
Visual Studio 2017 Menu > Tools > External Tools > Add
Title: Generate Server
Command: C:\Program Files\dotnet\dotnet.exe
Arguments: script --no-cache $(ProjectDir)\Base\Generator\Generate.csx
Use Output Window: Yes
```

## Step 7. Build and Run

Run the following command to build and run the webapi project:

```
dotnet watch run
```

Or, if you just want to build the project:

```
dotnet build
```