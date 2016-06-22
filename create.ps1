param($ProjectDemo,$NewProjectName)

if(($ProjectDemo -ne "owin-ddd") -and ($ProjectDemo -ne "owin-simple")){
    write "项目模板不存在";
    return;
}
if([System.String]::IsNullOrWhiteSpace($NewProjectName)){
    write "项目名称错误";    
    return;
}

cd projects;
New-Item -ItemType Directory -Name $NewProjectName;
cd ..
Copy-Item -Path .\base\$ProjectDemo\Ryan\* -Destination .\projects\$NewProjectName -Recurse; 

cd projects\$NewProjectName;

$location = Get-Location;

$files = [System.IO.Directory]::GetFiles($location.ToString(),"*.cs",[System.IO.SearchOption]::AllDirectories);
foreach($file in $files)
{
    $content = Get-Content $file;
    $content = $content.Replace("Ryan",$NewProjectName); 
    Set-Content -Path $file $content -Encoding UTF8;
}

$csprojfiles = [System.IO.Directory]::GetFiles($location,"*.csproj",[System.IO.SearchOption]::AllDirectories);
foreach($file in $csprojfiles)
{
    $content = Get-Content $file;
    $content = $content.Replace("Ryan",$NewProjectName); 
    Set-Content -Path $file $content -Encoding UTF8;
}

$directories = [System.IO.Directory]::GetDirectories($location,"Ryan*");
foreach($dir in $directories)
{
    $newdir = $dir.Replace("Ryan",$NewProjectName);

    write $newdir;
    write $dir;
    [System.IO.Directory]::Move($dir,$newdir);
}
$csprojfiles = [System.IO.Directory]::GetFiles($location,"Ryan*.csproj",[System.IO.SearchOption]::AllDirectories);
foreach($file in $csprojfiles)
{
    $newfile = $file.Replace("Ryan",$NewProjectName);
    [System.IO.File]::Move($file,$newfile);
}

$sln = [System.IO.Directory]::GetFiles($location,"Ryan.sln")[0];
$content = Get-Content $sln;
$content = $content.Replace("Ryan",$NewProjectName);
Set-Content -Path $sln $content  -Encoding UTF8;

$newsln = $sln.Replace("Ryan",$NewProjectName);
[System.IO.File]::Move($sln,$newsln);

cd ..\..\

write "创建完毕";