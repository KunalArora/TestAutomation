using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brother.Tests.Specs.Resolvers
{
    public interface IUrlResolver
    {
        string BaseUrl { get; }
        string CmsUrl { get; }
        string AtYourSideUrl { get; }
    }
}
