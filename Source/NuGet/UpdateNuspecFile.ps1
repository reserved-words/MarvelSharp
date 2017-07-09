param ([string]$releaseNotes) # Should be getting the version number from the assembly

# Declare variables

$nuspecPath = 'MarvelSharp\MarvelSharp.csproj.nuspec'

# Get project version number

$projectVersionFull = [System.Reflection.Assembly]::LoadFrom((Resolve-Path "MarvelSharp\bin\Release\MarvelSharp.dll")).GetName().Version
$projectVersion = $projectVersionFull.Major.ToString() + '.' + $projectVersionFull.Minor.ToString() + '.' + $projectVersionFull.Build.ToString()

# Update nuspec file

$xml = [xml](Get-Content $nuspecPath)

$metaDataNode = $xml.package.metadata

$childNodes = $metaDataNode.ChildNodes

($childNodes | where {$_.Name -eq 'releaseNotes'}).set_InnerXML($releaseNotes)
($childNodes | where {$_.Name -eq 'version'}).set_InnerXML($projectVersion)

$xml.Save((Resolve-Path $nuspecPath))

# Copy to the Builds directory

Copy-Item $nuspecPath ..\Builds
Rename-Item ..\Builds\MarvelSharp.csproj.nuspec ('MarvelSharp.' + $projectVersion + '.csproj.nuspec')