# Declare variables

$nuspecPath = 'MarvelousApi\MarvelousApi.csproj.nuspec'

$Id = 'MarvelousApi'
$Authors = 'Rhian Adams'
$Owners = 'Rhian Adams'
$Description = 'A C# library for the Marvel Comics API'
$ProjectUrl = 'https://github.com/reserved-words/MarvelousApi/wiki'
$Tags = 'Marvel Comics API'

# Create nuspec file

NuGet\NuGet.exe spec MarvelousApi\MarvelousApi.csproj

# Populate nuspec file with project details and remove unnecessary nodes

$xml = [xml](Get-Content $nuspecPath)

$metaDataNode = $xml.package.metadata

$childNodes = $metaDataNode.ChildNodes

($childNodes | where {$_.Name -eq 'id'}).set_InnerXML($Id)
($childNodes | where {$_.Name -eq 'authors'}).set_InnerXML($Authors)
($childNodes | where {$_.Name -eq 'owners'}).set_InnerXML($Owners)
($childNodes | where {$_.Name -eq 'description'}).set_InnerXML($Description)
($childNodes | where {$_.Name -eq 'projectUrl'}).set_InnerXML($ProjectUrl)
($childNodes | where {$_.Name -eq 'tags'}).set_InnerXML($Tags)

$nodeToRemove = $childNodes | where {$_.Name -eq 'iconUrl'}
$metaDataNode.RemoveChild($nodeToRemove)

$nodeToRemove = $childNodes | where {$_.Name -eq 'licenseUrl'}
$metaDataNode.RemoveChild($nodeToRemove)

$dependenciesNode = $childNodes | where {$_.Name -eq 'dependencies'}

foreach ($node in $dependenciesNode.ChildNodes){
	$dependenciesNode.RemoveChild($node)
}

$xml.Save((Resolve-Path $nuspecPath))