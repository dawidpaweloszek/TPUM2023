/* ========================================================================
 * Copyright (c) 2005-2021 The OPC Foundation, Inc. All rights reserved.
 *
 * OPC Foundation MIT License 1.00
 *
 * Permission is hereby granted, free of charge, to any person
 * obtaining a copy of this software and associated documentation
 * files (the "Software"), to deal in the Software without
 * restriction, including without limitation the rights to use,
 * copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the
 * Software is furnished to do so, subject to the following
 * conditions:
 *
 * The above copyright notice and this permission notice shall be
 * included in all copies or substantial portions of the Software.
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
 * EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
 * OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
 * NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
 * HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
 * WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
 * FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
 * OTHER DEALINGS IN THE SOFTWARE.
 *
 * The complete license agreement can be found here:
 * http://opcfoundation.org/License/MIT/1.00/
 * ======================================================================*/

using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Xml;
using System.Runtime.Serialization;
using Data;
using Opc.Ua;

namespace Data
{
    #region ObjectType Identifiers
    /// <summary>
    /// A class that declares constants for all ObjectTypes in the Model Design.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class ObjectTypes
    {
        /// <summary>
        /// The identifier for the IWeapon ObjectType.
        /// </summary>
        public const uint IWeapon = 3;
    }
    #endregion

    #region Variable Identifiers
    /// <summary>
    /// A class that declares constants for all Variables in the Model Design.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class Variables
    {
        /// <summary>
        /// The identifier for the IWeapon_Id Variable.
        /// </summary>
        public const uint IWeapon_Id = 4;

        /// <summary>
        /// The identifier for the IWeapon_Name Variable.
        /// </summary>
        public const uint IWeapon_Name = 5;

        /// <summary>
        /// The identifier for the IWeapon_Price Variable.
        /// </summary>
        public const uint IWeapon_Price = 6;

        /// <summary>
        /// The identifier for the IWeapon_Origin Variable.
        /// </summary>
        public const uint IWeapon_Origin = 7;

        /// <summary>
        /// The identifier for the IWeapon_WeaponType Variable.
        /// </summary>
        public const uint IWeapon_WeaponType = 8;
    }
    #endregion

    #region ObjectType Node Identifiers
    /// <summary>
    /// A class that declares constants for all ObjectTypes in the Model Design.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class ObjectTypeIds
    {
        /// <summary>
        /// The identifier for the IWeapon ObjectType.
        /// </summary>
        public static readonly ExpandedNodeId IWeapon = new ExpandedNodeId(Data.ObjectTypes.IWeapon, Data.Namespaces.Data);
    }
    #endregion

    #region Variable Node Identifiers
    /// <summary>
    /// A class that declares constants for all Variables in the Model Design.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class VariableIds
    {
        /// <summary>
        /// The identifier for the IWeapon_Id Variable.
        /// </summary>
        public static readonly ExpandedNodeId IWeapon_Id = new ExpandedNodeId(Data.Variables.IWeapon_Id, Data.Namespaces.Data);

        /// <summary>
        /// The identifier for the IWeapon_Name Variable.
        /// </summary>
        public static readonly ExpandedNodeId IWeapon_Name = new ExpandedNodeId(Data.Variables.IWeapon_Name, Data.Namespaces.Data);

        /// <summary>
        /// The identifier for the IWeapon_Price Variable.
        /// </summary>
        public static readonly ExpandedNodeId IWeapon_Price = new ExpandedNodeId(Data.Variables.IWeapon_Price, Data.Namespaces.Data);

        /// <summary>
        /// The identifier for the IWeapon_Origin Variable.
        /// </summary>
        public static readonly ExpandedNodeId IWeapon_Origin = new ExpandedNodeId(Data.Variables.IWeapon_Origin, Data.Namespaces.Data);

        /// <summary>
        /// The identifier for the IWeapon_WeaponType Variable.
        /// </summary>
        public static readonly ExpandedNodeId IWeapon_WeaponType = new ExpandedNodeId(Data.Variables.IWeapon_WeaponType, Data.Namespaces.Data);
    }
    #endregion

    #region BrowseName Declarations
    /// <summary>
    /// Declares all of the BrowseNames used in the Model Design.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class BrowseNames
    {
        /// <summary>
        /// The BrowseName for the Id component.
        /// </summary>
        public const string Id = "Id";

        /// <summary>
        /// The BrowseName for the IWeapon component.
        /// </summary>
        public const string IWeapon = "IWeapon";

        /// <summary>
        /// The BrowseName for the Name component.
        /// </summary>
        public const string Name = "Name";

        /// <summary>
        /// The BrowseName for the Origin component.
        /// </summary>
        public const string Origin = "Origin";

        /// <summary>
        /// The BrowseName for the Price component.
        /// </summary>
        public const string Price = "Price";

        /// <summary>
        /// The BrowseName for the WeaponType component.
        /// </summary>
        public const string WeaponType = "WeaponType";
    }
    #endregion

    #region Namespace Declarations
    /// <summary>
    /// Defines constants for all namespaces referenced by the model design.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class Namespaces
    {
        /// <summary>
        /// The URI for the cas namespace (.NET code namespace is '').
        /// </summary>
        public const string cas = "http://cas.eu/UA/CommServer/";

        /// <summary>
        /// The URI for the OpcUa namespace (.NET code namespace is 'Opc.Ua').
        /// </summary>
        public const string OpcUa = "http://opcfoundation.org/UA/";

        /// <summary>
        /// The URI for the OpcUaXsd namespace (.NET code namespace is 'Opc.Ua').
        /// </summary>
        public const string OpcUaXsd = "http://opcfoundation.org/UA/2008/02/Types.xsd";

        /// <summary>
        /// The URI for the Data namespace (.NET code namespace is 'Data').
        /// </summary>
        public const string Data = "http://smiths.com/TPUM2023/Shop/";
    }
    #endregion
}