---
theme : "white"
transition: "slide"
highlightTheme: "monokai"
logoImg: "avatar.png"
slideNumber: false
title: "VSCode Reveal intro"
---

![logo](/avatar.png)

---

# Wat is NUKE build?
- Het is een build automation tool. 
- Vergelijkbare andere tools:
  - Cake (C# met een smaakje)
  - Psake (powershell)
  - Gulp, grunt (javascript)

---

# Waarom NUKE build
- Gebruikt C#
- Gewone console applicatie
- Debugging
- Makkelijk op te zetten met de nuke global tool
- Parameters
- Makkelijk omgaan met paden

---

# Demo opzetten NUKE build.md

NUKE is makkelijk op te zetten met `nuke :setup`
```
PS C:\git\NukePresentation\Demo\3> nuke :setup
NUKE Global Tool version 0.24.11 (Windows,.NETCoreApp,Version=v2.1)
Could not find root directory. Falling back to working directory.
How should the build project be named?
¬  _build                                                                                                                                                                                                                                                       
Where should the build project be located?
¬  ./build                                                                                                                                                                                                                                                      
Which NUKE version should be used?
¬  0.24.11 (latest release)
Which solution should be the default?                                                                                                                                                                                                                           
¬  None                                                                                                                                                                                                                                                         
Touching file 'C:\git\NukePresentation\Demo\3\.nuke'...
Creating directory 'C:\git\NukePresentation\Demo\3\.\build'...
```

---

## Wat zijn `build.cmd`, `build.ps1` en `build.sh`??
In principe kan je direct `dotnet run` aanroepen op het project echter deze scripts zorgen ervoor dat de `dotnet cli` altijd geinstalleerd is mocht dit nog niet zo zijn.