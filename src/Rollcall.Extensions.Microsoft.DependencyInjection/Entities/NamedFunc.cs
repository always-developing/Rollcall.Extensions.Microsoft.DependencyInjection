using System;
using System.Collections.Generic;
using System.Text;

namespace Rollcall.Extensions.Microsoft.DependencyInjection
{
    internal class NamedFunc<TInterface>
    {
        public NamedFunc(string _name, Func<IServiceProvider, object> _implementation)
        {
            Name = _name;
            Implementation = _implementation;
        }

        public string Name { get; set; }

        public Func<IServiceProvider, object> Implementation { get; set; }
    }
}
