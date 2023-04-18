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
using System.Xml;
using System.Runtime.Serialization;
using Data;
using Opc.Ua;

namespace Data
{
    #region IWeaponState Class
    #if (!OPCUA_EXCLUDE_IWeaponState)
    /// <summary>
    /// Stores an instance of the IWeapon ObjectType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class IWeaponState : BaseObjectState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public IWeaponState(NodeState parent) : base(parent)
        {
        }

        /// <summary>
        /// Returns the id of the default type definition node for the instance.
        /// </summary>
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(Data.ObjectTypes.IWeapon, Data.Namespaces.Data, namespaceUris);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            base.Initialize(context);
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        /// <summary>
        /// Initializes the instance with a node.
        /// </summary>
        protected override void Initialize(ISystemContext context, NodeState source)
        {
            InitializeOptionalChildren(context);
            base.Initialize(context, source);
        }

        /// <summary>
        /// Initializes the any option children defined for the instance.
        /// </summary>
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString =
           "AgAAABwAAABodHRwOi8vY2FzLmV1L1VBL0NvbW1TZXJ2ZXIvIAAAAGh0dHA6Ly9zbWl0aHMuY29tL1RQ" +
           "VU0yMDIzL1Nob3Av/////wRggAIBAAAAAgAPAAAASVdlYXBvbkluc3RhbmNlAQIDAAECAwADAAAA////" +
           "/wUAAAAVYIkKAgAAAAIAAgAAAElkAQIEAAAuAEQEAAAAAA7/////AQH/////AAAAABVgiQoCAAAAAgAE" +
           "AAAATmFtZQECBQAALgBEBQAAAAAM/////wEB/////wAAAAAVYIkKAgAAAAIABQAAAFByaWNlAQIGAAAu" +
           "AEQGAAAAAAr/////AQH/////AAAAABVgiQoCAAAAAgAGAAAAT3JpZ2luAQIHAAAuAEQHAAAAABv/////" +
           "AQH/////AAAAABVgiQoCAAAAAgAKAAAAV2VhcG9uVHlwZQECCAAALgBECAAAAAAb/////wEB/////wAA" +
           "AAA=";
        #endregion
        #endif
        #endregion

        #region Public Properties
        /// <remarks />
        public PropertyState<Guid> Id
        {
            get
            {
                return m_id;
            }

            set
            {
                if (!Object.ReferenceEquals(m_id, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_id = value;
            }
        }

        /// <remarks />
        public PropertyState<string> Name
        {
            get
            {
                return m_name;
            }

            set
            {
                if (!Object.ReferenceEquals(m_name, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_name = value;
            }
        }

        /// <remarks />
        public PropertyState<float> Price
        {
            get
            {
                return m_price;
            }

            set
            {
                if (!Object.ReferenceEquals(m_price, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_price = value;
            }
        }

        /// <remarks />
        public PropertyState Origin
        {
            get
            {
                return m_origin;
            }

            set
            {
                if (!Object.ReferenceEquals(m_origin, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_origin = value;
            }
        }

        /// <remarks />
        public PropertyState WeaponType
        {
            get
            {
                return m_weaponType;
            }

            set
            {
                if (!Object.ReferenceEquals(m_weaponType, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_weaponType = value;
            }
        }
        #endregion

        #region Overridden Methods
        /// <summary>
        /// Populates a list with the children that belong to the node.
        /// </summary>
        /// <param name="context">The context for the system being accessed.</param>
        /// <param name="children">The list of children to populate.</param>
        public override void GetChildren(
            ISystemContext context,
            IList<BaseInstanceState> children)
        {
            if (m_id != null)
            {
                children.Add(m_id);
            }

            if (m_name != null)
            {
                children.Add(m_name);
            }

            if (m_price != null)
            {
                children.Add(m_price);
            }

            if (m_origin != null)
            {
                children.Add(m_origin);
            }

            if (m_weaponType != null)
            {
                children.Add(m_weaponType);
            }

            base.GetChildren(context, children);
        }

        /// <summary>
        /// Finds the child with the specified browse name.
        /// </summary>
        protected override BaseInstanceState FindChild(
            ISystemContext context,
            QualifiedName browseName,
            bool createOrReplace,
            BaseInstanceState replacement)
        {
            if (QualifiedName.IsNull(browseName))
            {
                return null;
            }

            BaseInstanceState instance = null;

            switch (browseName.Name)
            {
                case Data.BrowseNames.Id:
                {
                    if (createOrReplace)
                    {
                        if (Id == null)
                        {
                            if (replacement == null)
                            {
                                Id = new PropertyState<Guid>(this);
                            }
                            else
                            {
                                Id = (PropertyState<Guid>)replacement;
                            }
                        }
                    }

                    instance = Id;
                    break;
                }

                case Data.BrowseNames.Name:
                {
                    if (createOrReplace)
                    {
                        if (Name == null)
                        {
                            if (replacement == null)
                            {
                                Name = new PropertyState<string>(this);
                            }
                            else
                            {
                                Name = (PropertyState<string>)replacement;
                            }
                        }
                    }

                    instance = Name;
                    break;
                }

                case Data.BrowseNames.Price:
                {
                    if (createOrReplace)
                    {
                        if (Price == null)
                        {
                            if (replacement == null)
                            {
                                Price = new PropertyState<float>(this);
                            }
                            else
                            {
                                Price = (PropertyState<float>)replacement;
                            }
                        }
                    }

                    instance = Price;
                    break;
                }

                case Data.BrowseNames.Origin:
                {
                    if (createOrReplace)
                    {
                        if (Origin == null)
                        {
                            if (replacement == null)
                            {
                                Origin = new PropertyState(this);
                            }
                            else
                            {
                                Origin = (PropertyState)replacement;
                            }
                        }
                    }

                    instance = Origin;
                    break;
                }

                case Data.BrowseNames.WeaponType:
                {
                    if (createOrReplace)
                    {
                        if (WeaponType == null)
                        {
                            if (replacement == null)
                            {
                                WeaponType = new PropertyState(this);
                            }
                            else
                            {
                                WeaponType = (PropertyState)replacement;
                            }
                        }
                    }

                    instance = WeaponType;
                    break;
                }
            }

            if (instance != null)
            {
                return instance;
            }

            return base.FindChild(context, browseName, createOrReplace, replacement);
        }
        #endregion

        #region Private Fields
        private PropertyState<Guid> m_id;
        private PropertyState<string> m_name;
        private PropertyState<float> m_price;
        private PropertyState m_origin;
        private PropertyState m_weaponType;
        #endregion
    }
    #endif
    #endregion
}