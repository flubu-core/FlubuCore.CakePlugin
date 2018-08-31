using System;
using Cake.Docker;
using FlubuCore.Context;
using Xunit;

namespace FlubuCore.CakePlugin.Tests
{
    public class Class1
    {
        [Fact]
        public void Test()
        {
            ITaskContext context = new TaskContext(null, null, null, null, null, null);
            context.CakeTasks().DockerBuild(new DockerImageBuildSettings
            {
            }, "C:\\img");
        }
    }
}
