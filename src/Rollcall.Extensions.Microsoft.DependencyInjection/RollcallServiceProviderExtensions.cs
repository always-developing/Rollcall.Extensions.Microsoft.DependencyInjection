using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rollcall.Extensions.Microsoft.DependencyInjection
{
    public static class RollcallServiceProviderExtensions
    {
        public static TInterface GetService<TInterface>(this IServiceProvider provider, string name) where TInterface : class
        {
            var namedTypes = provider.GetServices<NamedType<TInterface>>();
            var namedType = namedTypes.FirstOrDefault(x => x.Name == name);

            if (namedType == null)
            {
                var namedFuncs = provider.GetServices<NamedFunc<TInterface>>();
                var namedFunc = namedFuncs.FirstOrDefault(x => x.Name == name);

                if (namedFunc == null)
                {
                    throw new InvalidOperationException($"Unable to resolve dependency of type {typeof(TInterface).FullName} with the name '{name}'");
                }

                return (TInterface)namedFunc.Implementation.Invoke(provider);
            }

            return (TInterface)provider.GetService(namedType.Implementation);

        }
    }
}
