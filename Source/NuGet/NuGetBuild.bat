msbuild MarvelousApi\MarvelousApi.csproj /p:Configuration=Release
powershell NuGet\UpdateNuspecFile.ps1 ""
msbuild MarvelSMarvelousApiharp\MarvelousApi.csproj /p:Configuration=Release
powershell NuGet\CreateNuGetPackage.ps1