using System;
using System.Linq;
using Nuke.Common;
using Nuke.Common.Execution;
using Nuke.Common.IO;
using Nuke.Common.ProjectModel;
using Nuke.Common.Tooling;
using Nuke.Common.Tools.DotNet;
using Nuke.Common.Tools.GitVersion;
using Nuke.Common.Utilities.Collections;
using static Nuke.Common.EnvironmentInfo;
using static Nuke.Common.IO.FileSystemTasks;
using static Nuke.Common.IO.PathConstruction;
using static Nuke.Common.Tools.DotNet.DotNetTasks;

[UnsetVisualStudioEnvironmentVariables]
class Build : NukeBuild
{
    #region Targets
    public static int Main() => Execute<Build>(x => x.DefaultTarget);
    Target DefaultTarget => _ => _
        .Executes(() =>
        {
            Logger.Info("This is the default target");
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

    #endregion

    #region Parameters
    [Parameter]
    private readonly string SomeParameter;

    Target ParameterDemo => _ => _
        .Executes(() =>
        {
            Logger.Info($"SomeParameter value: {SomeParameter}");
        });
    #endregion

    #region Paths
    private AbsolutePath ThisPresentation => RootDirectory / "nukepresentation.md";
    Target PrintThisPresentationPath => _ => _
        .Executes(() =>
        {
            Logger.Info($"This presentation is hosted at {ThisPresentation}");
        });
    #endregion

    #region ThirdPartyTools
    // Also needs the project to reference GitVersion.Tool!
    [PackageExecutable("GitVersion.Tool", @"tools\netcoreapp2.1\any\GitVersion.dll")]
    private static Tool GitVersionTool;
    Target GitVersionTheHardWay => _ => _
        .Executes(() =>
        {
            GitVersionTool();
        });

    [GitVersion] readonly GitVersion GitVersion;
    Target GitVersionTheEasyWay => _ => _
        .Executes(() =>
        {
            Logger.Info($"NugetVersion is {GitVersion.NuGetVersion}");
        });
    #endregion

    #region Solutions
    [Solution] readonly Solution Solution;
    Target Compile => _ => _
        .Executes(() =>
        {
            DotNetBuild(s => s.SetProjectFile(Solution));
        });

    Target ListProjects => _ => _
        .Executes(() =>
        {
            Logger.Info("Listing projects..");
            foreach (var project in Solution.AllProjects)
            {
                Logger.Info(project);
            }
        });
    #endregion
}
