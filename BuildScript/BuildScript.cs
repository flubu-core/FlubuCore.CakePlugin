using System;
using FlubuCore.Context;
using FlubuCore.Scripting;

namespace BuildScript
{
    public class BuildScript : DefaultBuildScript
    {
        protected override void ConfigureBuildProperties(IBuildPropertiesContext context)
        {
            context.Properties.Set(BuildProps.CompanyName, "Flubu");
            context.Properties.Set(BuildProps.CompanyCopyright, "Copyright (C) 2010-2018 Flubu");
            context.Properties.Set(BuildProps.ProductId, "FlubuCore.CakePlugin");
            context.Properties.Set(BuildProps.ProductName, "FlubuCore.CakePlugin");
            context.Properties.Set(BuildProps.BuildDir, "output");
            context.Properties.Set(BuildProps.SolutionFileName, "FlubuCore.CakePlugin.sln");
            context.Properties.Set(BuildProps.BuildConfiguration, "Release");
        }

        protected override void ConfigureTargets(ITaskContext context)
        {
            var buildVersion = context.CreateTarget("buildVersion")
                .SetAsHidden()
                .SetDescription("Fetches flubu version from FlubuCore.ProjectVersion.txt file.")
                .AddTask(x => x.FetchBuildVersionFromFileTask());

            var compile = context.CreateTarget("Compile")
                .AddCoreTask(x => x.Clean())
                .AddCoreTask(x => x.UpdateNetCoreVersionTask("FlubuCore.CakePlugin/FlubuCore.CakePlugin.csproj"))
                .AddCoreTask(x => x.Build())
                .DependsOn(buildVersion);

            var nugetPublish = context.CreateTarget("Nuget.Publish")
                .DependsOn(compile)
                .AddCoreTask(x => x.Pack().Project("FlubuCore.CakePlugin")
                    .NoBuild()
                    .IncludeSymbols()
                    .OutputDirectory("../output"))
                .Do(PublishNuGetPackage);

            context.CreateTarget("Rebuild")
                .SetAsDefault()
                .DependsOn(compile, nugetPublish);
        }

        private static void PublishNuGetPackage(ITaskContext context)
        {
            var version = context.Properties.GetBuildVersion();
            var nugetVersion = version.ToString(3);

            context.CoreTasks().NugetPush($"output\\FlubuCore.CakePlugin.{nugetVersion}.nupkg")
                .ForMember(x => x.ApiKey("Not provided"), "nugetKey", "Nuget api key.")
                .ServerUrl("https://www.nuget.org/api/v2/package")
                .Execute(context);
        }
    }
}
