msbuild MarvelSharp\MarvelSharp.csproj /p:Configuration=Release
powershell NuGet\UpdateNuspecFile.ps1 ""
msbuild MarvelSharp\MarvelSharp.csproj /p:Configuration=Release
powershell NuGet\CreateNuGetPackage.ps1