using System;
using System.Collections.Generic;
using System.Text;
using Cake.Core;

namespace FlubuCore.CakePlugin
{
    public class FlubuCakeDataResolver : ICakeDataResolver
    {
        public TData Get<TData>() where TData : class
        {
            throw new NotSupportedException();
        }
    }
}
