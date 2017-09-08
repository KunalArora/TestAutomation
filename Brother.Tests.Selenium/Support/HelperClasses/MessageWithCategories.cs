using System;

namespace Brother.Tests.Selenium.Lib.Support.HelperClasses
{
    public class MessageWithCategories
    {
        private readonly string _separator = DefaultSeparator;

        public MessageWithCategories(string message, string separator = null)
        {
            Categories = new string[] { };

            if (!string.IsNullOrWhiteSpace(separator))
            {
                _separator = separator;
            }
            
            if (message.Contains(_separator))
            {
                var splitMessage = message.Split(new string[] {  _separator }, StringSplitOptions.RemoveEmptyEntries);
                Message = splitMessage[0];
                if (splitMessage.Length == 2)
                {
                    Categories = splitMessage[1].Split(',');
                }
            }
            else
            {
                Message = message;
            }
        }

        public string Message { get; set; }
        public string[] Categories { get; set; }
        public string Separator
        {
            get
            {
                return _separator;
            }
        }

        public static string DefaultSeparator
        {
            get
            {
                return "%CATEGORIES%";
            }
        }
    }
}
