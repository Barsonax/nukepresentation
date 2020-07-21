---
theme : "white"
transition: "slide"
highlightTheme: "vs2015"
slideNumber: false
title: "VSCode Reveal intro"
---

## Wat is NUKE?
- https://nuke.build
- Build automation tool. 
- Vergelijkbare andere tools:
  - Cake (C# met een smaakje)
  - Psake (powershell)
  - Gulp, grunt (javascript)

---

## Waarom NUKE
- Gebruikt C#
- Gewone console applicatie
- Debugging
- Makkelijk op te zetten met de nuke global tool
- En meer!...

---

## Installatie NUKE 
NUKE is beschikbaar als een dotnet global tool:
```console
dotnet tool install Nuke.GlobalTool --global
```

--

## NUKE toevoegen aan een project
Setup wizard met `nuke :setup`
```console
PS C:\git\NukePresentation> nuke :setup                                                                                                                                                                                                                                             
NUKE Global Tool version 0.24.11 (Windows,.NETCoreApp,Version=v2.1)
How should the build project be named?
¬  _build                                                                                                                                                                                                                                                                           
Where should the build project be located?
¬  ./build                                                                                                                                                                                                                                                                          
Which NUKE version should be used?
¬  0.24.11 (latest release)
Which solution should be the default?                                                                                                                                                                                                                                               
¬  NukePresentation.sln                                                                                                                                                                                                                                                             
Do you need help getting started with a basic build?                                                                                                                                                                                                                                
¬  No, I can do this myself...                                                                                                                                                                                                                                                      
Creating directory 'C:\git\NukePresentation\.\build'...       
```

--

## Wat zijn `build.cmd`, `build.ps1` en `build.sh`??
- In principe niet nodig, de NUKE global tool of gewoon `dotnet run` werkt ook
- Wel handig als NUKE of de `dotnet cli` nog niet geinstalleerd is.

--

## Wat is `.nuke`??
- Bepaalt de root folder
- Hier komt ook (optioneel) het pad naar de .sln in te staan

--

## Aanroepen NUKE

Global tool
```console
nuke [targets] [arguments]
```
Via de scripts werkt hetzelfde
```console
.\build.ps1 [targets] [arguments]
```

---

## Targets

```csharp
    Target Foo => _ => _
        .Executes(() =>
        {

        });
```
```console
nuke Foo
```

--

## Dependencies

DependsOn
```csharp
    Target Bar => _ => _
    .DependsOn(Foo)
        .Executes(() =>
        {

        });
```
```console
nuke Bar
```

--

## Trigger

TriggerBy
```csharp
    Target Trigger => _ => _
        .Executes(() =>
        {

        });

    Target TriggeredBy => _ => _
        .TriggeredBy(Trigger)
        .Executes(() =>
        {

        });
```
```console
nuke Trigger
```

--

## Ordering

After
```csharp
    Target AfterFoo => _ => _
    .After(Foo)
        .Executes(() => {
            
        });
```
```console
nuke Foo AfterFoo
```

Before
```csharp
    Target BeforeFoo => _ => _
    .Before(Foo)
        .Executes(() => {
            
        });
```
```console
nuke Foo BeforeFoo
```

---

## Parameters
- `[Parameter]` attribuut

```csharp
[Parameter]
readonly string SomeParameter;
```

```console
nuke ParameterDemo --someparameter blabla
```

--

## Conversie
- string
- int
- bool
- arrays
- enums
- TypeConverter voor complexe types

---

## Path
- RootDirectory property
- Types
- Operators

--

## Types
- AbsolutePath
- RelativePath
- WinRelativePath
- UnixRelativePath

--

## RootDirectory
- Type AbsolutePath
- De directory waar `.nuke` zich bevindt

--

## Voorbeeld

```csharp
AbsolutePath ThisPresentation => RootDirectory / "nukepresentation.md";
```

---

## Third party cli tools
- PackageExecutable
- LocalExecutable
- PathExecutable

---

## Solutions en projecten
- [Solution] attribuut

---

## Documentatie
https://nuke.build/docs/getting-started/philosophy.html

---

## Vragen
