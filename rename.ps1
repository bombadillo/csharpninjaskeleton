param(
    [string]$projectName
)

if (!$projectName) {
    Write-Host "parameter -projectName is missing"
    exit
}

$textToFind = "(CsharpNinjaSkeleton|csharpninjaskeleton)"
$projectSolutionName = "csharpninjaskeleton"
$include = @("*.cs", "*.config", "*.csproj")
$projectFiles = Get-ChildItem 'csharpninjaskeleton\*' -Recurse -Include $include -Exclude $exclude | ?{ $_.fullname -notmatch "\\obj\\|\\bin\\?" }

function ReplaceInFile($file, $find, $replace) {
    try {
    (Get-Content $file.PSPath) |
        Foreach-Object { $_ -replace $find, $replace } |
        Set-Content $file.PSPath    
        Write-Host "Replacing $find with $replace in $file"    
    }
    catch [System.Exception] 
    {
        Write-Host "Unable to replace in file"
    }
    
}

function ProcessDirectory($files) {    
    foreach ($file in $files) {
        ReplaceInFile $file $textToFind $projectName
        Write-Host "Processed file $file"
    }
}

function RenameItems() {
    Rename-Item "$projectSolutionName.sln" "$projectName.sln"
    Rename-Item "$projectSolutionName\$projectSolutionName.cs" "$projectName.cs"
    Rename-Item "$projectSolutionName\$projectSolutionName.csproj" "$projectName.csproj"
    Rename-Item "$projectSolutionName" "$projectName"
}

function ReplaceOccurrencesInSln() {
    $solutionFile = Get-Item "$projectSolutionName.sln"
    ReplaceInFile $solutionFile $projectSolutionName $projectName    
}

ReplaceOccurrencesInSln
ProcessDirectory $projectFiles
RenameItems
