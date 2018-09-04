# FlubuCore.CakePlugin

[![NuGet](https://img.shields.io/nuget/v/FlubuCore.CakePlugin.svg)](https://www.nuget.org/packages/FlubuCore.Cakeplugin/)
[![Gitter](https://img.shields.io/gitter/room/FlubuCore/Lobby.svg)](https://gitter.im/FlubuCore/Lobby?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)
[![License](https://img.shields.io/github/license/flubu-core/flubuCore.CakePlugin.svg)](https://github.com/flubu-core/FlubuCore.CakePlugin/blob/master/LICENSE)

FlubuCore.CakePlugin is a [FlubuCore](https://github.com/flubu-core/flubu.core) plugin that allows you to use any Cake addins in FlubuCore. 

Plugin adds Cake tasks to FlubuCore ``` ITaskContext ``` interface:  ``` context.CakeTasks() ```
    
Following FlubuCore example uses Cake.Docker addin which is added with [nuget directive](https://github.com/flubu-core/flubu.core/wiki/2-Build-script-fundamentals#Referencing-nuget-packages) ``` //#nuget Cake.Docker, 0.9.6 ```.

```  //#nuget Cake.Core, 0.30.0 ``` has to be added because FlubuCore.CakePlugin has dependecy on it and flubu nuget directives doesn't resolve dependencies from nuget packages at the moment. 

If Cake addin would have any nuget dependencies that dependecy would have to be added with nuget directive(or any other directive) in build script as well. 

    
    //#nuget FlubuCore.CakePlugin, 1.0.0
    //#nuget Cake.Core, 0.30.0
    //#nuget Cake.Docker, 0.9.6
    public class BuildScript : DefaultBuildScript
    {
        private void CakeAddinExample(ITaskContext context)
        {
           context.CakeTasks().DockerBuild(new DockerImageBuildSettings
           {
           }, "centosImg");
          
    }
    
Full example that uses cake addin can be found [here](https://github.com/flubu-core/examples/blob/master/UsingCakeAddinInFlubuExample/BuildScript/BuildScript.cs) 
 
 ## Have a question?

 [![Join the chat at https://gitter.im/FlubuCore/Lobby](https://badges.gitter.im/mbdavid/LiteDB.svg)](https://gitter.im/FlubuCore/Lobby?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)

## Contributing

Please see [CONTRIBUTING.md](https://github.com/flubu-core/flubu.core/blob/master/CONTRIBUTING.md).
       
