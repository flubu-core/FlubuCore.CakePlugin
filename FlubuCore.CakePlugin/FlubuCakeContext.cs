using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using Cake.Core;
using Cake.Core.Configuration;
using Cake.Core.Diagnostics;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace FlubuCore.CakePlugin
{
    class FlubuCakeContext : ICakeContext
    {
        public IFileSystem FileSystem => new FileSystem();

        public ICakeLog Log => new FlubuCakeLog();
        
        public IRegistry Registry => new WindowsRegistry();

        public ICakeEnvironment Environment => new CakeEnvironment(new CakePlatform(), new CakeRuntime(), Log);

        public IGlobber Globber => new Globber(FileSystem, Environment);

        public IProcessRunner ProcessRunner => new ProcessRunner(FileSystem, Environment, Log, Tools, Configuration);

        public IToolLocator Tools => new ToolLocator(Environment, Repository, new ToolResolutionStrategy(FileSystem, Environment, Globber, new CakeConfiguration(new ConcurrentDictionary<string, string>())));

        public IToolRepository Repository => new ToolRepository(Environment);

        public ICakeArguments Arguments => new FlubuCakeArguments();
       
        public ICakeDataResolver Data => new FlubuCakeDataResolver();

        public ICakeConfiguration Configuration => new CakeConfiguration(new Dictionary<string, string>());
    }
}
