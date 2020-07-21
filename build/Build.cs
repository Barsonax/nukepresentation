using System;
using System.Linq;
using Nuke.Common;
using Nuke.Common.Execution;
using Nuke.Common.IO;
using Nuke.Common.ProjectModel;
using Nuke.Common.Tooling;
using Nuke.Common.Tools.GitVersion;
using Nuke.Common.Utilities.Collections;
using static Nuke.Common.EnvironmentInfo;
using static Nuke.Common.IO.FileSystemTasks;
using static Nuke.Common.IO.PathConstruction;

[UnsetVisualStudioEnvironmentVariables]
class Build : NukeBuild
{
    /// Support plugins are available for:
    ///   - JetBrains ReSharper        https://nuke.build/resharper
    ///   - JetBrains Rider            https://nuke.build/rider
    ///   - Microsoft VisualStudio     https://nuke.build/visualstudio
    ///   - Microsoft VSCode           https://nuke.build/vscode

    public static int Main() => Execute<Build>(x => x.DefaultTarget);

    [Solution] readonly Solution Solution;

    [Parameter("Configuration to build - Default is 'Debug' (local) or 'Release' (server)")]
    readonly Configuration Configuration = IsLocalBuild ? Configuration.Debug : Configuration.Release;

    private AbsolutePath ThisPresentation => RootDirectory / "nukepresentation.md";

    // Also needs the project to reference GitVersion.Tool!
    [PackageExecutable("GitVersion.Tool", @"tools\netcoreapp2.1\any\GitVersion.dll")]
    private static Tool GitVersionTool;

    [GitVersion] readonly GitVersion GitVersion;

    [Parameter]
    private readonly string SomeParameter;

    Target DefaultTarget => _ => _
        .Executes(() => {
            Logger.Info("This is the default target");
        });

    Target ListProjects => _ => _
        .Executes(() => {
            Logger.Info("Listing projects..");
            foreach (var project in Solution.AllProjects)
            {
                Logger.Info(project);
            }
        });

    Target GitVersionHard => _ => _
        .Executes(() =>
        {
            GitVersionTool();
        });

    Target GitVersionEasy => _ => _
        .Executes(() =>
        {
            Logger.Info($"NugetVersion is {GitVersion.NuGetVersion}");
        });


    Target Foo => _ => _
        .Executes(() =>
        {

        });

    Target Bar => _ => _
    .DependsOn(Foo)
        .Executes(() =>
        {

        });

    Target AfterFoo => _ => _
    .After(Foo)
        .Executes(() =>
        {

        });

    Target BeforeFoo => _ => _
    .Before(Foo)
        .Executes(() =>
        {

        });

    Target Trigger => _ => _
        .Executes(() =>
        {

        });

    Target TriggeredBy => _ => _
        .TriggeredBy(Trigger)
        .Executes(() =>
        {

        });

    Target ParameterDemo => _ => _
        .Executes(() =>
        {
            Logger.Info($"SomeParameter value: {SomeParameter}");
        });

}
