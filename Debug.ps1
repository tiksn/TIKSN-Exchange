./Build.ps1

$trashFolders = Get-ChildItem ".trash"

$lastTrashFolder = $trashFolders | Select-Object -Last 1

Push-Location

Set-Location $lastTrashFolder
Set-Location "publish"

Import-Module ./TIKSN.Exchange.dll
