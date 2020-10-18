# Pataflags SDK for C#

More information in https://www.pataflags.com

## Build, pack and push
First of all, change the version in `fflags-sdk-cs.csproj` field `PackageVersion`.

After that, run the build

    dotnet build
    dotnet pack
    dotnet nuget push ./bin/Debug/pataflags-sdk-cs.<NEW_VERSION>.nupkg --api-key <NUGET_API_KEY> --source https://api.nuget.org/v3/index.json

## Run the tests
    dotnet test

