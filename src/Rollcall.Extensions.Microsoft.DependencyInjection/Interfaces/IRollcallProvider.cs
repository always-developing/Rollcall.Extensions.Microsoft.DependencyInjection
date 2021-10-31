using System;
using System.Collections.Generic;
using System.Text;

namespace Rollcall.Extensions.Microsoft.DependencyInjection
{
    public interface IRollcallProvider
    {
        TInterface GetService<TInterface>(string name) where TInterface : class;
    }
}
