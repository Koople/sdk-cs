# Koople SDK for C#

More information in https://www.koople.io

Koople docs https://koople.gitbook.io/koople/

SDK documentation: https://koople.gitbook.io/koople/sdk-reference/csharp

## Build, pack and push
First of all, change the version in `sdk-cs.csproj` field `PackageVersion`.

After that, run the build

    dotnet build
    dotnet pack
    dotnet nuget push ./bin/Debug/sdk-cs.<NEW_VERSION>.nupkg --api-key <NUGET_API_KEY> --source https://api.nuget.org/v3/index.json

## Run the tests
    dotnet test

## API Interface
This code is under `sdk-cs-e2e` project:

    // Create user if needed, this will help you with the segmentations of the flags and remote configs
    var user = new KUser("oscar.galindo@csharp.test.com", new Dictionary<string, IKValue> 
    {
        {"country", IKValue.Create("spain")},
        {"age", IKValue.Create(18)}
    });
    
    // Get feature flag boolean for the user
    var single = _client.IsEnabled("someFeature", user);
    
    // Get feature flag boolean without any user (anonymous)
    var withoutUser = _client.IsEnabled("someFeature");
    
    // Get all the feature flags (used mostly for debug)
    var result = _client.EvaluatedFeaturesForUser(user); 
    
    // Get remote config value for the user
    var rc = _client.ValueOf("sap-user", user); 
    
    // Get remote config value for the user with default value
    var nonrc = _client.ValueOf("non-existing-host", user, "defaultValueOfNonExisting");
    
    // Same methods as above but without user aka DefaultValue of the remote config 
    var anonymous = _client.ValueOf("non-existing-host", "defaultValueOfNonExisting"); 
