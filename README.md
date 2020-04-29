# Gif Maker
[![License](https://img.shields.io/badge/license-MIT-green)](LICENSE)
[![Build Status](https://img.shields.io/badge/build-passing-brightgreen)](#)
[![NuGet](https://img.shields.io/badge/nuget-v1.0.0-blue)](#)

support `gif` for unity.

<!-- Badges: https://shields.io/ -->
<!-- Reference -->
<!-- https://kakakakakku.hatenablog.com/entry/2018/08/08/200903 -->

<!-- Code Quality: https://app.codacy.com/ -->
<!-- https://srz-zumix.blogspot.com/2018/07/cireview-codacy.html-->

<!-- OTHER LICENSE -->
<!-- BSD [![License](https://img.shields.io/badge/license-BSD--3%20clause-blue.svg)](LICENSE) -->
<!-- Apache2 [![License](https://img.shields.io/badge/license-Apache%202-blue.svg)](LICENSE) -->
<!-- GPL [![License](https://img.shields.io/badge/license-GPL-blue.svg)](LICENSE) -->

<!-- [![Coverity Scan](https://scan.coverity.com/projects/4884/badge.svg)](https://scan.coverity.com/projects/glfw-glfw) -->
<!-- [![chat](https://badges.gitter.im/LLGL-Project/LLGL.svg)]() -->

## ■ Documentation

* [Home](#gif-maker)
* [Documentation](#-documentation)
* [Introduction](#-introduction)
* [Build Status](#-build-status)
* [Install](#-directory-structure)
  * [from NuGet](#from-nuget)
  * [from Unity Package Manager](#from-unity-package-manager)
  <!--* [from unity package]()-->
* [Wiki]()
  * [ScriptReference]()
* [Dependencies](#-dependencies)
* [Directory Structure](#-directory-structure)
* [License](#-license)
* [Reference](#-reference)

## ■ Introduction

**Gif Maker** is a quick GIF replay recorder for Unity3D. It automatically records the last few seconds of gameplay and lets you save to a GIF file on demand, like the game [TowerFall Ascension](http://www.towerfall-game.com/) does.

Tested with Unity 4.6. The demo requires Unity 5+ (Personal or Pro).

## ■ Build Status

- `platform support`

<!-- | Platform | <img src="docu/Icons/windows.svg" height="20" />Windows | <img src="docu/Icons/macos.svg" height="20" />MacOS | <img src="docu/Icons/linux.svg" height="20" />Linux | <img src="docu/Icons/android.svg" height="20" /> Android | <img src="docu/Icons/ios.svg" height="20" />iOS |  <img src="docu/Icons/android.svg" height="20" />HTML5 | -->

| Platform | CI | D3D12 | D3D11 | Vulkan | OpenGL | OpenGLES 3 | Metal |
|----------|:--:|:-----:|:-----:|:------:|:------:|:----------:|:-----:|
| Windows | [![Windows Build](https://ci.appveyor.com/api/projects/status/j09x8n07u3byfky0?svg=true)](https://ci.appveyor.com/project/LukasBanana/llgl) | :heavy_check_mark: | :heavy_check_mark: | :heavy_check_mark: | :heavy_check_mark: | N/A | N/A |
| Linux | [![GNU/Linux Build Status](http://badges.herokuapp.com/travis/LukasBanana/LLGL?env=BADGE_LINUX=&label=build)](https://travis-ci.org/LukasBanana/LLGL) | N/A | N/A | :heavy_check_mark: | :heavy_check_mark: | N/A | N/A |
| MacOS | [![macOS Build Status](http://badges.herokuapp.com/travis/LukasBanana/LLGL?env=BADGE_MACOS=&label=build)](https://travis-ci.org/LukasBanana/LLGL) | N/A | N/A | N/A | :heavy_check_mark: | N/A | :heavy_check_mark: |
| iOS | [![iOS Build Status](http://badges.herokuapp.com/travis/LukasBanana/LLGL?env=BADGE_IOS=&label=build)](https://travis-ci.org/LukasBanana/LLGL) | N/A | N/A | N/A | N/A | :heavy_multiplication_x: | :heavy_check_mark: |
| Android | | N/A | N/A | :heavy_multiplication_x: | N/A | :heavy_check_mark: | N/A |
| HTML5 | | N/A | N/A | :heavy_multiplication_x: | N/A | :heavy_check_mark: | N/A |

| Platform | Windows | MacOS | Linux | Android | iOS | HTML5 |
|----------|:-----:|:-----:|:-----:|:-----:|:-----:|:-----:|:-----:|
| Test | [![Build Status](https://img.shields.io/badge/build-passing-brightgreen)](#) | [![Build Status](https://img.shields.io/badge/build-passing-brightgreen)](#) | [![Build Status](https://img.shields.io/badge/build-passing-brightgreen)](#) | [![Build Status](https://img.shields.io/badge/build-passing-brightgreen)](#) | [![Build Status](https://img.shields.io/badge/build-passing-brightgreen)](#) | [![Build Status](https://img.shields.io/badge/build-passing-brightgreen)](#) |
| CI | [![Build Status](https://img.shields.io/badge/build-passing-brightgreen)](#) | [![Build Status](https://img.shields.io/badge/build-passing-brightgreen)](#) | [![Build Status](https://img.shields.io/badge/build-passing-brightgreen)](#) | [![Build Status](https://img.shields.io/badge/build-passing-brightgreen)](#) | [![Build Status](https://img.shields.io/badge/build-passing-brightgreen)](#) | [![Build Status](https://img.shields.io/badge/build-passing-brightgreen)](#) | [![Build Status](https://img.shields.io/badge/build-passing-brightgreen)](#) |

## ■ Install

### from NuGet

- nuget package manager.

### from Unity Package Manager

- `manifest.json`

```
{
	"com.aria.unity.gifmaker": "https://github.com/TK-Aria/GifMaker.git#master" 
}
```

<!--## from unity package

- [download this here Releases](https://github.com/TK-Aria/Unity-IronPython/releases)

 <img src="https://pngimage.net/wp-content/uploads/2018/06/unity-logo-white-png-5.png" height="20" /> drag and drop or double click on unity package file.-->

## Wiki

- [ScriptReference](#)

## ■ Dependencies

- [Aria Runtime Utility](#)
- [Aria Network SDK](#)
- [GifMaker](#)

The documentation is generated with Doxygen if CMake can find that tool.

## ■ License
- [MIT License](./LICENSE)

## ■ Reference

- [original](https://github.com/Chman/Moments)
