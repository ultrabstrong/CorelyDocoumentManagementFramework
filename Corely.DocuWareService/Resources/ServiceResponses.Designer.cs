﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Corely.DocuWareService.Resources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class ServiceResponses {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ServiceResponses() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Corely.DocuWareService.Resources.ServiceResponses", typeof(ServiceResponses).Assembly);
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
        ///   Looks up a localized string similar to Failed to get list for search.
        /// </summary>
        internal static string failGetList {
            get {
                return ResourceManager.GetString("failGetList", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Failed to get user information.
        /// </summary>
        internal static string failGetUserInfo {
            get {
                return ResourceManager.GetString("failGetUserInfo", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Failed to check if all users are out of office for role name.
        /// </summary>
        internal static string failGetUserOOOForRole {
            get {
                return ResourceManager.GetString("failGetUserOOOForRole", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Failed to get roles for user.
        /// </summary>
        internal static string failGetUserRoles {
            get {
                return ResourceManager.GetString("failGetUserRoles", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Failed to get users in role.
        /// </summary>
        internal static string failGetUsersInRole {
            get {
                return ResourceManager.GetString("failGetUsersInRole", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to No search dialog found for cabinet id.
        /// </summary>
        internal static string noSearchForCabId {
            get {
                return ResourceManager.GetString("noSearchForCabId", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Query settings are invalid. Format as DWField1,One of [=&lt;&gt;],&quot;Value1&quot;;DWField2,One of [=&lt;&gt;],&quot;Value2&quot;.
        /// </summary>
        internal static string querySettingsInvalid {
            get {
                return ResourceManager.GetString("querySettingsInvalid", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Role not found for role name.
        /// </summary>
        internal static string roleNotFound {
            get {
                return ResourceManager.GetString("roleNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Roles not found for username.
        /// </summary>
        internal static string rolesNotFoundForUser {
            get {
                return ResourceManager.GetString("rolesNotFoundForUser", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to User not found for username.
        /// </summary>
        internal static string userNotFound {
            get {
                return ResourceManager.GetString("userNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Users not found for role name.
        /// </summary>
        internal static string usersNotFoundForRole {
            get {
                return ResourceManager.GetString("usersNotFoundForRole", resourceCulture);
            }
        }
    }
}
