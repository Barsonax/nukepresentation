---
theme : "white"
transition: "slide"
highlightTheme: "vs2015"
slideNumber: true
logoImg: "https://github.com/Barsonax/nukepresentation/raw/master/images/nukeIcon.png"
title: "NUKE build presentation"
enableTitleFooter: false
---

## NUKE build

<a>
    <img style="border: unset; box-shadow: unset" data-src="https://github.com/Barsonax/nukepresentation/raw/master/images/nukeIcon.png">
</a>

---

## In deze presentatie
- Wat is NUKE?
- Waarom NUKE?
- De techniek in

---

## Wat is NUKE?
- https://nuke.build
- Build automation tool. 
- Vergelijkbare andere tools:
  - Cake (C# met een smaakje)
  - Psake (powershell)
  - Gulp, grunt (javascript)

---

## Waarom NUKE?
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

Via de global tool, met autocompletion!
```console
nuke [targets] [arguments]
```

Via de scripts werkt hetzelfde, handig op de CI
```console
.\build.ps1 [targets] [arguments]
```

--

## IDE integraties
- Visual studio https://marketplace.visualstudio.com/items?itemName=nuke.visualstudio
- VSCode https://marketplace.visualstudio.com/items?itemName=nuke.support
- Rider https://plugins.jetbrains.com/plugin/10803-nuke-support

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
- Via environment variabele
- Via commandline parameter

```csharp
[Parameter]
readonly string SomeParameter;
```

```console
nuke ParameterDemo --someparameter blabla
```

--

## Type conversie
- string
- int
- bool
- arrays
- enums
- TypeConverter voor complexe types

---

## File system paden
- Custom types om hier makkelijk mee om te gaan
- Platform agnostisch
- RootDirectory property, de directory waar `.nuke` zich bevindt

```csharp
AbsolutePath ThisPresentation => RootDirectory / "nukepresentation.md";
```

---

## Third party cli tools
- [PackageExecutable] attribuut
- [LocalExecutable] attribuut
- [PathExecutable] attribuut

```csharp
// Also needs the project to reference GitVersion.Tool!
[PackageExecutable("GitVersion.Tool", @"tools\netcoreapp2.1\any\GitVersion.dll")]
private static Tool GitVersionTool;
```

---

## Solutions en projecten
- [Solution] attribuut

---

## Documentatie
https://nuke.build/docs/getting-started/philosophy.html

## Chat
https://slofile.com/slack/nukebuildnet
---

## Vragen
