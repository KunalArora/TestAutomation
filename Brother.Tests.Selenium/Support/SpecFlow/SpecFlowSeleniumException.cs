using System;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;

namespace Brother.Tests.Selenium.Lib.Support
{
    public class SpecFlowSeleniumException : Exception
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="SpecFlowSeleniumException"/> class.
        /// </summary>
        public SpecFlowSeleniumException()
        {
        }

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="T:System.Exception" /> avec un message d'erreur spécifié.
        /// </summary>
        /// <param name="message">Message décrivant l'erreur.</param>
        public SpecFlowSeleniumException(string message)
            : base(message)
        {
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="SpecFlowSeleniumException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="ex">The ex.</param>
        public SpecFlowSeleniumException(string message, Exception ex)
            : base(message, ex)
        {
            Helper.MsgOutput(message, ex.Message);
            if (ex.InnerException != null)
            {
                Helper.MsgOutput("Inner Exception", ex.InnerException.Message);
            }
        }
    }
}
