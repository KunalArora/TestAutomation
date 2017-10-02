using System;
using System.Globalization;
using Brother.Tests.Specs;

namespace Brother.Tests.Specs.Services
{
    public class ExpectedTranslationService : ITranslationService
    {
        public string GetInstallationPackText(string name, string culture)
        {
            var cultureInfo = new CultureInfo(culture);
            return GetText(Resources.InstallationPack.InstallationPack.ResourceManager, name, cultureInfo);
        }

        public string GetServicePackText(string name, string culture)
        {
            var cultureInfo = new CultureInfo(culture);
            return GetText(Resources.ServicePack.ServicePack.ResourceManager, name, cultureInfo);
        }

        private string GetText(System.Resources.ResourceManager resourceManager, string name, CultureInfo cultureInfo)
        {
            string result = string.Empty;
            try
            {
                result = resourceManager.GetString(name, cultureInfo);
            } catch (Exception ex){
                //TODO: re-throw and categorise this
                var message = ex.Message;
            }
            return result;
        }
    }
}
