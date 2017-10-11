using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brother.Tests.Specs.Services
{
    public interface ITranslationService
    {
        string GetInstallationPackText(string name, string culture);
        string GetServicePackText(string name, string culture);
        string GetContractTypeText(string name, string culture);
    }
}
