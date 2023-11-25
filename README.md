# MAUI.Binding_Libraries_App_Size_Perfs

Git LFS is needed for this repo
https://git-lfs.com/

# Build the app

First, build the binding projects : 
  - ESignature/Sense-AAR-to-DONET/Sense-AAR-to-DONET.csproj
  - ESignature/SmartContract_xcframework_to_DOTNET/SmartContract_xcframework_to_DOTNET.csproj
  - ESignature/Wysiwys_framework_to_DOTNET/Wysiwys_framework_to_DOTNET.csproj
  - CommunicationTool/Unblu-AAR-to-DOTNET/Unblu-AAR-to-DOTNET.csproj

Then, build Binding_Libraries_App_Size_Perfs/Binding_Libraries_App_Size_Perfs.csproj. It will build its dependencies ESignature/ESignature/ESignature.csproj and CommunicationTool/CommunicationTool/CommunicationTool.csproj.

# Purpose

The purpose of this repo is to demonstrate an apk size issue with some of my binded libraries.

When the MAUI project does not have a dependency to a binded project :
Building the app in Debug gives a 10MB.
Building the app in Release gives a 30MB.

When the MAUI project has a dependency to the ESignature binded project : 
Building the app in Debug gives a 28MB.
Building the app in Release gives a 84MB.
