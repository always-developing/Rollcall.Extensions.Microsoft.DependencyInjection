using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rollcall.Extensions.Microsoft.DependencyInjection
{
    public class RollcallProvider : IRollcallProvider
    {
        public readonly IServiceProvider _serviceProvider;

        public RollcallProvider(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public TInterface GetService<TInterface>(string name) where TInterface : class
        {
            return _serviceProvider.GetService<TInterface>(name);
        }
    }
}
