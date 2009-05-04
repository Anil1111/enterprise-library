﻿//===============================================================================
// Microsoft patterns & practices Enterprise Library
// Caching Application Block QuickStart
//===============================================================================
// Copyright © Microsoft Corporation.  All rights reserved.
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE.
//===============================================================================

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.1433
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CachingQuickStart.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "2.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("CachingQuickStart.Properties.Resources", typeof(Resources).Assembly);
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
        ///   Looks up a localized string similar to The item is expected to change and should be refreshed at a defined time..
        /// </summary>
        internal static string AbsoluteTimeExpirationMessage {
            get {
                return ResourceManager.GetString("AbsoluteTimeExpirationMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Item added to cache
        ///Key: {0}
        ///Product Name: {1}
        ///Product Price: {2}
        ///Expiration: {3}
        ///Priority: {4}.
        /// </summary>
        internal static string AddItemToCacheMessage {
            get {
                return ResourceManager.GetString("AddItemToCacheMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Item read from cache
        ///Key: {0}
        ///Name: {1}
        ///Price: {2}.
        /// </summary>
        internal static string CacheSourceMessage {
            get {
                return ResourceManager.GetString("CacheSourceMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Data in storage was updated.
        /// </summary>
        internal static string DataSavedMessage {
            get {
                return ResourceManager.GetString("DataSavedMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The item has a particular lifetime, and should be expired upon completion of that lifetime..
        /// </summary>
        internal static string ExtendedFormatExpirationMessage {
            get {
                return ResourceManager.GetString("ExtendedFormatExpirationMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The item&apos;s lifetime is tied to a particular file. When that file changes, the item will be considered to be expired..
        /// </summary>
        internal static string FileDependencyExpirationMessage {
            get {
                return ResourceManager.GetString("FileDependencyExpirationMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cache has been flushed by user.
        /// </summary>
        internal static string FlushCacheMessage {
            get {
                return ResourceManager.GetString("FlushCacheMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The following fields are required: Key, Product Name, Product Price..
        /// </summary>
        internal static string InvalidInputMessage {
            get {
                return ResourceManager.GetString("InvalidInputMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The following field is required: Key.
        /// </summary>
        internal static string InvalidKeyMessage {
            get {
                return ResourceManager.GetString("InvalidKeyMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Please select an item.
        /// </summary>
        internal static string InvalidSelectionMessage {
            get {
                return ResourceManager.GetString("InvalidSelectionMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Item is no longer available.
        /// </summary>
        internal static string ItemNotAvailableMessage {
            get {
                return ResourceManager.GetString("ItemNotAvailableMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Item not found in cache
        ///Key: {0}.
        /// </summary>
        internal static string ItemNotFoundMessage {
            get {
                return ResourceManager.GetString("ItemNotFoundMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Item read from master and added to cache
        ///Key: {0}
        ///Name: {1}
        ///Price: {2}.
        /// </summary>
        internal static string MasterSourceMessage {
            get {
                return ResourceManager.GetString("MasterSourceMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The master copy of the item is not expected to change and the item will never be expired..
        /// </summary>
        internal static string NeverExpiredExpirationMessage {
            get {
                return ResourceManager.GetString("NeverExpiredExpirationMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The cache has been loaded with entire set of data.
        /// </summary>
        internal static string ProactiveLoadMessage {
            get {
                return ResourceManager.GetString("ProactiveLoadMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Caching Quick Start.
        /// </summary>
        internal static string QuickStartTitleMessage {
            get {
                return ResourceManager.GetString("QuickStartTitleMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Item read from cache
        ///Key: {0}
        ///Name: {1}
        ///Price: {2}.
        /// </summary>
        internal static string ReadItemFromCacheMessage {
            get {
                return ResourceManager.GetString("ReadItemFromCacheMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Items are retrieved from the cache by their key. Enter the key of the item you would like to retrieve from the cache..
        /// </summary>
        internal static string ReadItemMessage {
            get {
                return ResourceManager.GetString("ReadItemMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Read Item from Cache.
        /// </summary>
        internal static string ReadItemTitleMessage {
            get {
                return ResourceManager.GetString("ReadItemTitleMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Remove operation complete..
        /// </summary>
        internal static string RemoveItemFromCacheMessage {
            get {
                return ResourceManager.GetString("RemoveItemFromCacheMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Items are removed from the cache by their key. Enter the key of the item you would like to remove from the cache..
        /// </summary>
        internal static string RemoveItemMessage {
            get {
                return ResourceManager.GetString("RemoveItemMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Remove Item from Cache.
        /// </summary>
        internal static string RemoveItemTitleMessage {
            get {
                return ResourceManager.GetString("RemoveItemTitleMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Whenever the item is not accessed for a specified time, it should be considered stale, and expired..
        /// </summary>
        internal static string SlidingTimeExpirationMessage {
            get {
                return ResourceManager.GetString("SlidingTimeExpirationMessage", resourceCulture);
            }
        }
    }
}