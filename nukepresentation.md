---
theme : "white"
transition: "slide"
highlightTheme: "vs2015"
slideNumber: false
title: "VSCode Reveal intro"
---

## Wat is NUKE build?
- Build automation tool. 
- Vergelijkbare andere tools:
  - Cake (C# met een smaakje)
  - Psake (powershell)
  - Gulp, grunt (javascript)

---

## Waarom NUKE build
- Gebruikt C#
- Gewone console applicatie
- Debugging
- Makkelijk op te zetten met de nuke global tool
- Parameters
- Makkelijk omgaan met paden

---

## Opzetten NUKE build
NUKE is makkelijk op te zetten met `nuke :setup`
```console
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

--

## Wat zijn `build.cmd`, `build.ps1` en `build.sh`??
- Bootstrap scripts voor de `dotnet cli`
- In principe niet nodig, `dotnet run` werkt ook gewoon
- Handig als de `dotnet cli` niet geinstalleerd is

--

## Wat is `.nuke`??
- Bepaalt de root folder
- Hier komt ook (optioneel) het pad naar de .sln in te staan

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
- `[Parameter]` atribuut

Code
```csharp
[Parameter]
readonly string SomeParameter;
```

Input
```console
nuke ParameterDemo --someparameter blabla
```

--

## Path

```csharp
AbsolutePath ThisPresentation => RootDirectory / "nukepresentation.md";
```
