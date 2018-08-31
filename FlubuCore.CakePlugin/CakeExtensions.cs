using System;
using Cake.Core;
using Cake.Core.IO;
using FlubuCore.CakePlugin;
using FlubuCore.Context;

namespace FlubuCore.Context
{
    public static class CakeContext
    {
        public static ICakeContext CakeTasks(this ITaskContext context)
        {
            var cont = new FlubuCakeContext();
            return cont;
        }
    }
}
