﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Stock_Manage_Server {
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
    internal class ServerResources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ServerResources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Stock_Manage_Server.ServerResources", typeof(ServerResources).Assembly);
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
        ///   Looks up a localized string similar to CREATE DATABASE IF NOT EXISTS `db_inventorymanagement` DEFAULT CHARACTER SET latin1 COLLATE latin1_swedish_ci;
        ///USE `db_inventorymanagement`;
        ///CREATE TABLE IF NOT EXISTS `tbl_orders` (
        ///  `PK_ID` int(11) NOT NULL,
        ///  `FK_OrderId` int(11) NOT NULL,
        ///  `FK_ProductId` int(11) NOT NULL,
        ///  `Product_Quantity` int(11) NOT NULL,
        ///  `Total_Cost` float NOT NULL
        ///) ENGINE=MyISAM AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;
        ///CREATE TABLE IF NOT EXISTS `tbl_products` (
        ///  `PK_ProductId` int(11) NOT NULL,
        ///  `Barcode` text, [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string CreateSqlDatabase {
            get {
                return ResourceManager.GetString("CreateSqlDatabase", resourceCulture);
            }
        }
    }
}
