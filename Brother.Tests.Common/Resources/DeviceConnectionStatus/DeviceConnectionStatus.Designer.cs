﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Brother.Tests.Common.Resources.DeviceConnectionStatus {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class DeviceConnectionStatus {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal DeviceConnectionStatus() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Brother.Tests.Common.Resources.DeviceConnectionStatus.DeviceConnectionStatus", typeof(DeviceConnectionStatus).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to NotConnected.
        /// </summary>
        internal static string NOT_CONNECTED {
            get {
                return ResourceManager.GetString("NOT_CONNECTED", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Responding.
        /// </summary>
        internal static string RESPONDING {
            get {
                return ResourceManager.GetString("RESPONDING", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Silent.
        /// </summary>
        internal static string SILENT {
            get {
                return ResourceManager.GetString("SILENT", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Swapped.
        /// </summary>
        internal static string SWAPPED {
            get {
                return ResourceManager.GetString("SWAPPED", resourceCulture);
            }
        }
    }
}
