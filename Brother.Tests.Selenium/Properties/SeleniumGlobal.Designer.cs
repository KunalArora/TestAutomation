﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Brother.Tests.Selenium.Lib.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "11.0.0.0")]
    public sealed partial class SeleniumGlobal : global::System.Configuration.ApplicationSettingsBase {
        
        private static SeleniumGlobal defaultInstance = ((SeleniumGlobal)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new SeleniumGlobal())));
        
        public static SeleniumGlobal Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("127.0.0.1")]
        public string DriverIPAddress {
            get {
                return ((string)(this["DriverIPAddress"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("9134")]
        public string DriverPortNumber {
            get {
                return ((string)(this["DriverPortNumber"]));
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("CH")]
        public string CurrentDriverType {
            get {
                return ((string)(this["CurrentDriverType"]));
            }
            set {
                this["CurrentDriverType"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("IEOptions.log")]
        public string IEOptionsLog {
            get {
                return ((string)(this["IEOptionsLog"]));
            }
            set {
                this["IEOptionsLog"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("/Test/EmailConfirmationToken.aspx")]
        public string BrotherEmailConfirmationUrl {
            get {
                return ((string)(this["BrotherEmailConfirmationUrl"]));
            }
            set {
                this["BrotherEmailConfirmationUrl"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("ERROR")]
        public string PhantomJSLoggingLevel {
            get {
                return ((string)(this["PhantomJSLoggingLevel"]));
            }
            set {
                this["PhantomJSLoggingLevel"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("anthowell1")]
        public string BrowserStackUser {
            get {
                return ((string)(this["BrowserStackUser"]));
            }
            set {
                this["BrowserStackUser"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("uu64dsphJt6uAyz6Kj8q")]
        public string BrowserStackKey {
            get {
                return ((string)(this["BrowserStackKey"]));
            }
            set {
                this["BrowserStackKey"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("http://hub.browserstack.com/wd/hub/")]
        public string BrowserStackHubUri {
            get {
                return ((string)(this["BrowserStackHubUri"]));
            }
            set {
                this["BrowserStackHubUri"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("http://online65.{0}.cds.uat.brother.eu.com")]
        public string QASUrl65 {
            get {
                return ((string)(this["QASUrl65"]));
            }
            set {
                this["QASUrl65"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("http://online65.{0}.cds.test.brother.eu.com")]
        public string TestUrl65 {
            get {
                return ((string)(this["TestUrl65"]));
            }
            set {
                this["TestUrl65"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("http://{0}.cds.uat65.brother.eu.com")]
        public string MainSiteUAT65 {
            get {
                return ((string)(this["MainSiteUAT65"]));
            }
            set {
                this["MainSiteUAT65"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("http://{0}.cds.test65.brother.eu.com")]
        public string MainSiteTest65 {
            get {
                return ((string)(this["MainSiteTest65"]));
            }
            set {
                this["MainSiteTest65"] = value;
            }
        }
    }
}
