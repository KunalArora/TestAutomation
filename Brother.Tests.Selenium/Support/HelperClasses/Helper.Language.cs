using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Brother.Tests.Selenium.Lib.Support.HelperClasses
{
    public class Language : Helper
    {
        // Lookup tables for Language specific minor areas
        private static Dictionary<string, string> EmailSubjectsPassword = new Dictionary<string, string>
        {
            {"Spain", ""},
            {"Poland", "Zaloguj się / Utwórz konto"},
            {"United Kingdom", "Sign in / Create an account"},
            {"Ireland", "Sign in / Create an account"},
            {"France", ""},
        };

        private static Dictionary<string, string> EmailSubjectsRegistration = new Dictionary<string, string>
        {
            {"Spain", "registro"},
            {"Poland", "rejestracja"},
            {"United Kingdom", "Registration"},
            {"Ireland", "Registration"},
            {"France", "inscription"},
        };

        private static Dictionary<string, string> EmailSubjectsOrders = new Dictionary<string, string>
        {
            {"Spain", "Inicio de sesión / Cree una cuenta"},
            {"Poland", "Zaloguj się / Utwórz konto"},
            {"United Kingdom", "Sign in / Create an account"},
            {"Ireland", "Sign in / Create an account"},
        };

        private static Dictionary<string, string> EmailSubjectsUpdate = new Dictionary<string, string>
        {
            {"Spain", "Inicio de sesión / Cree una cuenta"},
            {"Poland", "Zaloguj się / Utwórz konto"},
            {"United Kingdom", "Sign in / Create an account"},
            {"Ireland", "Sign in / Create an account"},
        };

        private static Dictionary<string, string> EmailSubjectsImportant = new Dictionary<string, string>
        {
            {"Spain", "Inicio de sesión / Cree una cuenta"},
            {"Poland", "Zaloguj się / Utwórz konto"},
            {"United Kingdom", "Sign in / Create an account"},
            {"Ireland", "Sign in / Create an account"},
        };

        private static Dictionary<string, string> EmailSubjectsTrial = new Dictionary<string, string>
        {
            {"Spain", "Inicio de sesión / Cree una cuenta"},
            {"Poland", "Zaloguj się / Utwórz konto"},
            {"United Kingdom", "Sign in / Create an account"},
            {"Ireland", "Sign in / Create an account"},
        };

        public static object GetRegistrationEmailSubject(string locale, out string newEmailSubject)
        {
            return EmailSubjectsRegistration.TryGetValue(locale, out newEmailSubject) ? locale : string.Empty;
        }
    }
}
