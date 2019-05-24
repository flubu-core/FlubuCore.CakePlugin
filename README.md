# FlubuCore.CakePlugin

[![NuGet](https://img.shields.io/nuget/v/FlubuCore.CakePlugin.svg)](https://www.nuget.org/packages/FlubuCore.Cakeplugin/)
[![Gitter](https://img.shields.io/gitter/room/FlubuCore/Lobby.svg)](https://gitter.im/FlubuCore/Lobby?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)
[![License](https://img.shields.io/github/license/flubu-core/flubuCore.CakePlugin.svg)](https://github.com/flubu-core/FlubuCore.CakePlugin/blob/master/LICENSE)

FlubuCore.CakePlugin is a [FlubuCore](https://github.com/flubu-core/flubu.core) plugin that allows you to use any of the Cake addin
in FlubuCore. 

Plugin adds Cake addins to FlubuCore ``` ITaskContext ``` interface:  ``` context.CakeTasks() ```
    
Following FlubuCore example uses Cake.Docker addin which is added as nuget package. This is just an example you should not use Cake addin for docker as FlubuCore has it's own tasks for docker.    

    [NugetPackage("Cake.FileHelpers", "3.1.0")]
    [NugetPackage("FlubuCore.CakePlugin", "1.1.0")]
    public class BuildScript : DefaultBuildScript
    {
        private void CakeAddinExample(ITaskContext context)
        {
           context.CakeTasks().DockerBuild(new DockerImageBuildSettings
           {
           }, "centosImg");
          
    }

Full example that uses cake addin can be found [here](https://github.com/flubu-core/examples/blob/master/UsingCakeAddinInFlubuExample/BuildScript/BuildScript.cs) 

[Cake addins can be found here](https://www.nuget.org/packages?q=cake)
 
 ## Have a question?

 [![Join the chat at https://gitter.im/FlubuCore/Lobby](https://badges.gitter.im/mbdavid/LiteDB.svg)](https://gitter.im/FlubuCore/Lobby?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)

## Contributing

Please see [CONTRIBUTING.md](https://github.com/flubu-core/flubu.core/blob/master/CONTRIBUTING.md).
       
