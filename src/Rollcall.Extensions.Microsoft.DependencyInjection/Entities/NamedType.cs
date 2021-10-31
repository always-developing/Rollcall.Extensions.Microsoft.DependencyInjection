using System;
using System.Collections.Generic;
using System.Text;

namespace Rollcall.Extensions.Microsoft.DependencyInjection
{
    public class NamedType<TInterface>
    {
        public NamedType(string _name, Type _implementation)
        {
            Name = _name;
            Implementation = _implementation;
        }

        public string Name { get; set; }

        public Type Implementation { get; set; }
    }
}
