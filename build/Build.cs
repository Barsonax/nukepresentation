using System;
using System.Linq;
using Nuke.Common;
using Nuke.Common.Execution;
using Nuke.Common.IO;
using Nuke.Common.ProjectModel;
using Nuke.Common.Tooling;
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

    public static int Main() => Execute<Build>(x => x.ParameterDemo);

    [Parameter("Configuration to build - Default is 'Debug' (local) or 'Release' (server)")]
    readonly Configuration Configuration = IsLocalBuild ? Configuration.Debug : Configuration.Release;

    private AbsolutePath ThisPresentation => RootDirectory / "nukepresentation.md";

    [Parameter]
    private readonly string SomeParameter;
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
