# Bitshuffle.PInvoke

[![AppVeyor](https://ci.appveyor.com/api/projects/status/j3ci6s0ebf43ypfa/branch/main?svg=true)](https://ci.appveyor.com/project/Apollo3zehn/bitshuffle-pinvoke)
[![NuGet](https://img.shields.io/nuget/vpre/Bitshuffle.PInvoke.svg?label=Nuget)](https://www.nuget.org/packages/Bitshuffle.PInvoke)

This library is a lightweight wrapper around the [Bitshuffle](https://github.com/kiyo-masui/bitshuffle) library. The main class is `Bitshuffle` which provides access to the native Bitshffle methods.

The native Linux binary has been build with SSE2 support enabled and the Windows binary has no hardware acceleration enabled due difficulties with Visual Studio not setting proper constants for SSE2. 

AVX2 or AVX512 have not been enabled because the Bitshuffle code has no runtime detection of available instruction sets and so SSE2 has been selected with the hope that it will run on all modern CPUs.