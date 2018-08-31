using System;
using System.Collections.Generic;
using System.Text;
using Cake.Core.Diagnostics;

namespace FlubuCore.CakePlugin
{
    public class FlubuCakeLog : ICakeLog
    {
        public void Write(Verbosity verbosity, LogLevel level, string format, params object[] args)
        {
            if (LogLevel.Error < level)
            {
                Console.Write(format, args);
            }
            else
            {
                Console.Error.Write(format, args);
            }
        }

        public Verbosity Verbosity { get; set; }
    }
}
