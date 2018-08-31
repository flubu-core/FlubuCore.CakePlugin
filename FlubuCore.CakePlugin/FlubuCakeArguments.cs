using System;
using System.Collections.Generic;
using System.Text;
using Cake.Core;

namespace FlubuCore.CakePlugin
{
    class FlubuCakeArguments : ICakeArguments
    {
        public bool HasArgument(string name)
        {
            return false;
        }

        public string GetArgument(string name)
        {
            return null;
        }
    }
}
