$scriptName = $MyInvocation.MyCommand.Name

Write-Host "Owner ${Env:REPO_OWNER}"
Write-Host "Repository ${Env:REPO}"

$PROJECT_PATH = ".\$($Env:PROJECT_NAME)\$($Env:PROJECT_NAME).csproj"
$NUGET_PACKAGE_PATH = ".\artifacts\$($Env:PROJECT_NAME).*.nupkg"

Write-Host "Project Path ${PROJECT_PATH}"
Write-Host "Package Path ${NUGET_PACKAGE_PATH}"

if ($Env:REPO_OWNER -ne "BlaiseD") {
    Write-Host "${scriptName}: Only create packages on BlaiseD repositories."
} else {
    dotnet pack $PROJECT_PATH -c Release -o .\artifacts --no-build
    dotnet nuget push $NUGET_PACKAGE_PATH --skip-duplicate --source $Env:NUGET_URL --api-key $Env:NUGET_API_KEY
}
