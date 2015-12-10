# UniVersionManager

## Overview
Simple Version Getter for Unity, it can be used for iOS, Android and unity editor platform.
It can also get build version.

## Usage
To get application version
```cs
UniVersionManager.GetVersion();
```
To compare version
```cs
var newVersion = "1.0.1";
if(UniVersionManager.IsNewVersion(newVersion)){
    // Update your application
}
```
To get application build version
```cs
UniVersionManager.GetBuildVersion();
```

## Install
Use unitypackage under dist folder.

## Licence

[MIT](https://github.com/tcnksm/tool/blob/master/LICENCE)

## Author

[sanukin39](https://github.com/sanukin39)
