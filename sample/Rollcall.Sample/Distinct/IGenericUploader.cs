using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rollcall.Sample
{
    //https://blog.rsuter.com/dotnet-dependency-injection-way-to-work-around-missing-named-registrations/
    public interface IGenericUploader<T> : IFileUploader where T : IFileUploader
    {

    }
}
