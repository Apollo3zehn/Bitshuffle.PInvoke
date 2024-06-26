Write-Host "Updating Git submodule."
git submodule update --init --recursive --quiet

# x86
Write-Host "Creating native x86 project."
$path = "$($PSScriptRoot)/artifacts/bin32"
New-Item -Force -ItemType directory -Path $path
Set-Location -Path $path

if ($IsLinux)
{
	# do nothing
}
elseif ($IsWindows)
{
    cmake ../../ -DCMAKE_CONFIGURATION_TYPES:STRING="Debug;Release" -G "Visual Studio 16 2019" -A "Win32"
}
else 
{
    throw [System.PlatformNotSupportedException]
}

# x64
Write-Host "Creating native x64 project."
$path = "$($PSScriptRoot)/artifacts/bin64"
New-Item -Force -ItemType directory -Path $path
Set-Location -Path $path

if ($IsLinux)
{
    cmake ../../ -DCMAKE_BUILD_TYPE=Release -DCMAKE_C_FLAGS=-m64 -DCMAKE_CXX_FLAGS=-m64
}
elseif ($IsWindows)
{
    cmake ../../ -DCMAKE_CONFIGURATION_TYPES:STRING="Debug;Release" -G "Visual Studio 16 2019" -A "x64"
}
else 
{
    throw [System.PlatformNotSupportedException]
}

# return
Set-Location -Path $PSScriptRoot