﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1008
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Ciklum.WpfApplication.Properties
{
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
    public class Resources
    {

        private static global::System.Resources.ResourceManager resourceMan;

        private static global::System.Globalization.CultureInfo resourceCulture;

        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        public Resources()
        {
        }

        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager
        {
            get
            {
                if (object.ReferenceEquals(resourceMan, null))
                {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Ciklum.WpfApplication.Properties.Resources", typeof(Resources).Assembly);
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
        public static global::System.Globalization.CultureInfo Culture
        {
            get
            {
                return resourceCulture;
            }
            set
            {
                resourceCulture = value;
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to All Contacts.
        /// </summary>
        public static string AllContactsViewModel_DisplayName
        {
            get
            {
                return ResourceManager.GetString("AllContactsViewModel_DisplayName", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to E-mail address is invalid.
        /// </summary>
        public static string Contact_Error_InvalidEmail
        {
            get
            {
                return ResourceManager.GetString("Contact_Error_InvalidEmail", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to E-mail address is missing.
        /// </summary>
        public static string Contact_Error_MissingEmail
        {
            get
            {
                return ResourceManager.GetString("Contact_Error_MissingEmail", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to First name is missing.
        /// </summary>
        public static string Contact_Error_MissingFirstName
        {
            get
            {
                return ResourceManager.GetString("Contact_Error_MissingFirstName", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to Last name is missing.
        /// </summary>
        public static string Contact_Error_MissingLastName
        {
            get
            {
                return ResourceManager.GetString("Contact_Error_MissingLastName", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to Phone number is missing.
        /// </summary>
        public static string Contact_Error_MissingPhoneNumber
        {
            get
            {
                return ResourceManager.GetString("Contact_Error_MissingPhoneNumber", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to New Contact.
        /// </summary>
        public static string ContactViewModel_DisplayName
        {
            get
            {
                return ResourceManager.GetString("ContactViewModel_DisplayName", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to Cannot save an invalid contact..
        /// </summary>
        public static string ContactViewModel_Exception_CannotSave
        {
            get
            {
                return ResourceManager.GetString("ContactViewModel_Exception_CannotSave", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to Add new contact.
        /// </summary>
        public static string MainWindowViewModel_Command_CreateNewContact
        {
            get
            {
                return ResourceManager.GetString("MainWindowViewModel_Command_CreateNewContact", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to View contacts.
        /// </summary>
        public static string MainWindowViewModel_Command_ViewAllContacts
        {
            get
            {
                return ResourceManager.GetString("MainWindowViewModel_Command_ViewAllContacts", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to Ciklum Wpf Application.
        /// </summary>
        public static string MainWindowViewModel_DisplayName
        {
            get
            {
                return ResourceManager.GetString("MainWindowViewModel_DisplayName", resourceCulture);
            }
        }
    }
}