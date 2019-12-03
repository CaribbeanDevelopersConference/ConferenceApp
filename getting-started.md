# Carribean Develoepers Conference App

## Project Structure

This project is structured using the concept of [CentralPackageVersions](https://github.com/microsoft/MSBuildSdks/tree/master/src/CentralPackageVersions).  The `common.build.targets` file at the root of the directory controls all the package versions for the application.  Therefore adding and removing of nuget packages should be observed in the target project and the common.build.targets file.

#### The version goes in the `common.build.targets`

```xml
<Project>
    <ItemGroup>
        <PackageReference Update="Serilog" Version="2.*" />
    </ItemGroup>
</Project>
```

#### A reference is then added with no version as the central version restores a common across all projects.

```xml

<Project>
    <ItemGroup>
        <PackageReference Include="Serilog" />
    </ItemGroup>
</Project>
```

**Note:** The central version uses `Updated` while the project reference uses `Include`.

## dotnet version

The dotnet version of this project are controlled through the `global.json` file in the root of the directory.  Find the json node marked `"sdk"` and make sure you have installed the appropriate version for this project.

You can find out what dotnet versions you have installed by executing the following command:

`dotnet --list-sdks`

If the specified version isn't listed, then you need to install it to build this project.

### Feature Slices
Even though there are multiple projects, we try and group logical pieces together in the folder structure.  So a given List View, View Cell, Detail View and their corresponding view models will be found in that features folder.  The same will hold true for the services.  For simplicity, we kept everything in one project, which makes the silces more beenficial.

### Analyzers

The analyzers provided here are a based on the [ReactiveUI Style Guid](https://github.com/reactiveui/rfcs/blob/master/reactiveui/0002-code-analyzers.md).  They will enforce the rules at compile time.
