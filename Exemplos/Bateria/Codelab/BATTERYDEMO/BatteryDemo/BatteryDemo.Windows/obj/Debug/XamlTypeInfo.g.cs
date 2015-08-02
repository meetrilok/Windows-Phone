﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------



namespace BatteryDemo
{
    public partial class App : global::Windows.UI.Xaml.Markup.IXamlMetadataProvider
    {
        private global::BatteryDemo.BatteryDemo_Windows_XamlTypeInfo.XamlTypeInfoProvider _provider;

        public global::Windows.UI.Xaml.Markup.IXamlType GetXamlType(global::System.Type type)
        {
            if(_provider == null)
            {
                _provider = new global::BatteryDemo.BatteryDemo_Windows_XamlTypeInfo.XamlTypeInfoProvider();
            }
            return _provider.GetXamlTypeByType(type);
        }

        public global::Windows.UI.Xaml.Markup.IXamlType GetXamlType(string fullName)
        {
            if(_provider == null)
            {
                _provider = new global::BatteryDemo.BatteryDemo_Windows_XamlTypeInfo.XamlTypeInfoProvider();
            }
            return _provider.GetXamlTypeByName(fullName);
        }

        public global::Windows.UI.Xaml.Markup.XmlnsDefinition[] GetXmlnsDefinitions()
        {
            return new global::Windows.UI.Xaml.Markup.XmlnsDefinition[0];
        }
    }
}

namespace BatteryDemo.BatteryDemo_Windows_XamlTypeInfo
{
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks", "4.0.0.0")]    
    [System.Diagnostics.DebuggerNonUserCodeAttribute()]
    internal partial class XamlTypeInfoProvider
    {
        public global::Windows.UI.Xaml.Markup.IXamlType GetXamlTypeByType(global::System.Type type)
        {
            global::Windows.UI.Xaml.Markup.IXamlType xamlType;
            if (_xamlTypeCacheByType.TryGetValue(type, out xamlType))
            {
                return xamlType;
            }
            int typeIndex = LookupTypeIndexByType(type);
            if(typeIndex != -1)
            {
                xamlType = CreateXamlType(typeIndex);
            }
            if (xamlType != null)
            {
                _xamlTypeCacheByName.Add(xamlType.FullName, xamlType);
                _xamlTypeCacheByType.Add(xamlType.UnderlyingType, xamlType);
            }
            return xamlType;
        }

        public global::Windows.UI.Xaml.Markup.IXamlType GetXamlTypeByName(string typeName)
        {
            if (string.IsNullOrEmpty(typeName))
            {
                return null;
            }
            global::Windows.UI.Xaml.Markup.IXamlType xamlType;
            if (_xamlTypeCacheByName.TryGetValue(typeName, out xamlType))
            {
                return xamlType;
            }
            int typeIndex = LookupTypeIndexByName(typeName);
            if(typeIndex != -1)
            {
                xamlType = CreateXamlType(typeIndex);
            }
            if (xamlType != null)
            {
                _xamlTypeCacheByName.Add(xamlType.FullName, xamlType);
                _xamlTypeCacheByType.Add(xamlType.UnderlyingType, xamlType);
            }
            return xamlType;
        }

        public global::Windows.UI.Xaml.Markup.IXamlMember GetMemberByLongName(string longMemberName)
        {
            if (string.IsNullOrEmpty(longMemberName))
            {
                return null;
            }
            global::Windows.UI.Xaml.Markup.IXamlMember xamlMember;
            if (_xamlMembers.TryGetValue(longMemberName, out xamlMember))
            {
                return xamlMember;
            }
            xamlMember = CreateXamlMember(longMemberName);
            if (xamlMember != null)
            {
                _xamlMembers.Add(longMemberName, xamlMember);
            }
            return xamlMember;
        }

        global::System.Collections.Generic.Dictionary<string, global::Windows.UI.Xaml.Markup.IXamlType>
                _xamlTypeCacheByName = new global::System.Collections.Generic.Dictionary<string, global::Windows.UI.Xaml.Markup.IXamlType>();

        global::System.Collections.Generic.Dictionary<global::System.Type, global::Windows.UI.Xaml.Markup.IXamlType>
                _xamlTypeCacheByType = new global::System.Collections.Generic.Dictionary<global::System.Type, global::Windows.UI.Xaml.Markup.IXamlType>();

        global::System.Collections.Generic.Dictionary<string, global::Windows.UI.Xaml.Markup.IXamlMember>
                _xamlMembers = new global::System.Collections.Generic.Dictionary<string, global::Windows.UI.Xaml.Markup.IXamlMember>();

        string[] _typeNameTable = null;
        global::System.Type[] _typeTable = null;

        private void InitTypeTables()
        {
            _typeNameTable = new string[13];
            _typeNameTable[0] = "BatteryDemo.BatteryServicePage";
            _typeNameTable[1] = "Windows.UI.Xaml.Controls.Page";
            _typeNameTable[2] = "Windows.UI.Xaml.Controls.UserControl";
            _typeNameTable[3] = "Windows.Devices.Enumeration.DeviceInformation";
            _typeNameTable[4] = "Object";
            _typeNameTable[5] = "Int32";
            _typeNameTable[6] = "BatteryDemo.MainPage";
            _typeNameTable[7] = "System.Collections.ObjectModel.ObservableCollection`1<Windows.Devices.Enumeration.DeviceInformation>";
            _typeNameTable[8] = "System.Collections.ObjectModel.Collection`1<Windows.Devices.Enumeration.DeviceInformation>";
            _typeNameTable[9] = "Windows.Devices.Enumeration.EnclosureLocation";
            _typeNameTable[10] = "String";
            _typeNameTable[11] = "Boolean";
            _typeNameTable[12] = "System.Collections.Generic.IReadOnlyDictionary`2<String, Object>";

            _typeTable = new global::System.Type[13];
            _typeTable[0] = typeof(global::BatteryDemo.BatteryServicePage);
            _typeTable[1] = typeof(global::Windows.UI.Xaml.Controls.Page);
            _typeTable[2] = typeof(global::Windows.UI.Xaml.Controls.UserControl);
            _typeTable[3] = typeof(global::Windows.Devices.Enumeration.DeviceInformation);
            _typeTable[4] = typeof(global::System.Object);
            _typeTable[5] = typeof(global::System.Int32);
            _typeTable[6] = typeof(global::BatteryDemo.MainPage);
            _typeTable[7] = typeof(global::System.Collections.ObjectModel.ObservableCollection<global::Windows.Devices.Enumeration.DeviceInformation>);
            _typeTable[8] = typeof(global::System.Collections.ObjectModel.Collection<global::Windows.Devices.Enumeration.DeviceInformation>);
            _typeTable[9] = typeof(global::Windows.Devices.Enumeration.EnclosureLocation);
            _typeTable[10] = typeof(global::System.String);
            _typeTable[11] = typeof(global::System.Boolean);
            _typeTable[12] = typeof(global::System.Collections.Generic.IReadOnlyDictionary<global::System.String, global::System.Object>);
        }

        private int LookupTypeIndexByName(string typeName)
        {
            if (_typeNameTable == null)
            {
                InitTypeTables();
            }
            for (int i=0; i<_typeNameTable.Length; i++)
            {
                if(0 == string.CompareOrdinal(_typeNameTable[i], typeName))
                {
                    return i;
                }
            }
            return -1;
        }

        private int LookupTypeIndexByType(global::System.Type type)
        {
            if (_typeTable == null)
            {
                InitTypeTables();
            }
            for(int i=0; i<_typeTable.Length; i++)
            {
                if(type == _typeTable[i])
                {
                    return i;
                }
            }
            return -1;
        }

        private object Activate_0_BatteryServicePage() { return new global::BatteryDemo.BatteryServicePage(); }
        private object Activate_6_MainPage() { return new global::BatteryDemo.MainPage(); }
        private object Activate_7_ObservableCollection() { return new global::System.Collections.ObjectModel.ObservableCollection<global::Windows.Devices.Enumeration.DeviceInformation>(); }
        private object Activate_8_Collection() { return new global::System.Collections.ObjectModel.Collection<global::Windows.Devices.Enumeration.DeviceInformation>(); }
        private void VectorAdd_7_ObservableCollection(object instance, object item)
        {
            var collection = (global::System.Collections.Generic.ICollection<global::Windows.Devices.Enumeration.DeviceInformation>)instance;
            var newItem = (global::Windows.Devices.Enumeration.DeviceInformation)item;
            collection.Add(newItem);
        }
        private void VectorAdd_8_Collection(object instance, object item)
        {
            var collection = (global::System.Collections.Generic.ICollection<global::Windows.Devices.Enumeration.DeviceInformation>)instance;
            var newItem = (global::Windows.Devices.Enumeration.DeviceInformation)item;
            collection.Add(newItem);
        }

        private global::Windows.UI.Xaml.Markup.IXamlType CreateXamlType(int typeIndex)
        {
            global::BatteryDemo.BatteryDemo_Windows_XamlTypeInfo.XamlSystemBaseType xamlType = null;
            global::BatteryDemo.BatteryDemo_Windows_XamlTypeInfo.XamlUserType userType;
            string typeName = _typeNameTable[typeIndex];
            global::System.Type type = _typeTable[typeIndex];

            switch (typeIndex)
            {

            case 0:   //  BatteryDemo.BatteryServicePage
                userType = new global::BatteryDemo.BatteryDemo_Windows_XamlTypeInfo.XamlUserType(this, typeName, type, GetXamlTypeByName("Windows.UI.Xaml.Controls.Page"));
                userType.Activator = Activate_0_BatteryServicePage;
                userType.AddMemberName("Device");
                userType.AddMemberName("BatteryLevel");
                userType.SetIsLocalType();
                xamlType = userType;
                break;

            case 1:   //  Windows.UI.Xaml.Controls.Page
                xamlType = new global::BatteryDemo.BatteryDemo_Windows_XamlTypeInfo.XamlSystemBaseType(typeName, type);
                break;

            case 2:   //  Windows.UI.Xaml.Controls.UserControl
                xamlType = new global::BatteryDemo.BatteryDemo_Windows_XamlTypeInfo.XamlSystemBaseType(typeName, type);
                break;

            case 3:   //  Windows.Devices.Enumeration.DeviceInformation
                userType = new global::BatteryDemo.BatteryDemo_Windows_XamlTypeInfo.XamlUserType(this, typeName, type, GetXamlTypeByName("Object"));
                userType.AddMemberName("EnclosureLocation");
                userType.AddMemberName("Id");
                userType.AddMemberName("IsDefault");
                userType.AddMemberName("IsEnabled");
                userType.AddMemberName("Name");
                userType.AddMemberName("Properties");
                xamlType = userType;
                break;

            case 4:   //  Object
                xamlType = new global::BatteryDemo.BatteryDemo_Windows_XamlTypeInfo.XamlSystemBaseType(typeName, type);
                break;

            case 5:   //  Int32
                xamlType = new global::BatteryDemo.BatteryDemo_Windows_XamlTypeInfo.XamlSystemBaseType(typeName, type);
                break;

            case 6:   //  BatteryDemo.MainPage
                userType = new global::BatteryDemo.BatteryDemo_Windows_XamlTypeInfo.XamlUserType(this, typeName, type, GetXamlTypeByName("Windows.UI.Xaml.Controls.Page"));
                userType.Activator = Activate_6_MainPage;
                userType.AddMemberName("Devices");
                userType.SetIsLocalType();
                xamlType = userType;
                break;

            case 7:   //  System.Collections.ObjectModel.ObservableCollection`1<Windows.Devices.Enumeration.DeviceInformation>
                userType = new global::BatteryDemo.BatteryDemo_Windows_XamlTypeInfo.XamlUserType(this, typeName, type, GetXamlTypeByName("System.Collections.ObjectModel.Collection`1<Windows.Devices.Enumeration.DeviceInformation>"));
                userType.CollectionAdd = VectorAdd_7_ObservableCollection;
                userType.SetIsReturnTypeStub();
                xamlType = userType;
                break;

            case 8:   //  System.Collections.ObjectModel.Collection`1<Windows.Devices.Enumeration.DeviceInformation>
                userType = new global::BatteryDemo.BatteryDemo_Windows_XamlTypeInfo.XamlUserType(this, typeName, type, GetXamlTypeByName("Object"));
                userType.Activator = Activate_8_Collection;
                userType.CollectionAdd = VectorAdd_8_Collection;
                xamlType = userType;
                break;

            case 9:   //  Windows.Devices.Enumeration.EnclosureLocation
                userType = new global::BatteryDemo.BatteryDemo_Windows_XamlTypeInfo.XamlUserType(this, typeName, type, GetXamlTypeByName("Object"));
                userType.SetIsReturnTypeStub();
                xamlType = userType;
                break;

            case 10:   //  String
                xamlType = new global::BatteryDemo.BatteryDemo_Windows_XamlTypeInfo.XamlSystemBaseType(typeName, type);
                break;

            case 11:   //  Boolean
                xamlType = new global::BatteryDemo.BatteryDemo_Windows_XamlTypeInfo.XamlSystemBaseType(typeName, type);
                break;

            case 12:   //  System.Collections.Generic.IReadOnlyDictionary`2<String, Object>
                userType = new global::BatteryDemo.BatteryDemo_Windows_XamlTypeInfo.XamlUserType(this, typeName, type, null);
                userType.SetIsReturnTypeStub();
                xamlType = userType;
                break;
            }
            return xamlType;
        }


        private object get_0_BatteryServicePage_Device(object instance)
        {
            var that = (global::BatteryDemo.BatteryServicePage)instance;
            return that.Device;
        }
        private void set_0_BatteryServicePage_Device(object instance, object Value)
        {
            var that = (global::BatteryDemo.BatteryServicePage)instance;
            that.Device = (global::Windows.Devices.Enumeration.DeviceInformation)Value;
        }
        private object get_1_BatteryServicePage_BatteryLevel(object instance)
        {
            var that = (global::BatteryDemo.BatteryServicePage)instance;
            return that.BatteryLevel;
        }
        private void set_1_BatteryServicePage_BatteryLevel(object instance, object Value)
        {
            var that = (global::BatteryDemo.BatteryServicePage)instance;
            that.BatteryLevel = (global::System.Int32)Value;
        }
        private object get_2_MainPage_Devices(object instance)
        {
            var that = (global::BatteryDemo.MainPage)instance;
            return that.Devices;
        }
        private void set_2_MainPage_Devices(object instance, object Value)
        {
            var that = (global::BatteryDemo.MainPage)instance;
            that.Devices = (global::System.Collections.ObjectModel.ObservableCollection<global::Windows.Devices.Enumeration.DeviceInformation>)Value;
        }
        private object get_3_DeviceInformation_EnclosureLocation(object instance)
        {
            var that = (global::Windows.Devices.Enumeration.DeviceInformation)instance;
            return that.EnclosureLocation;
        }
        private object get_4_DeviceInformation_Id(object instance)
        {
            var that = (global::Windows.Devices.Enumeration.DeviceInformation)instance;
            return that.Id;
        }
        private object get_5_DeviceInformation_IsDefault(object instance)
        {
            var that = (global::Windows.Devices.Enumeration.DeviceInformation)instance;
            return that.IsDefault;
        }
        private object get_6_DeviceInformation_IsEnabled(object instance)
        {
            var that = (global::Windows.Devices.Enumeration.DeviceInformation)instance;
            return that.IsEnabled;
        }
        private object get_7_DeviceInformation_Name(object instance)
        {
            var that = (global::Windows.Devices.Enumeration.DeviceInformation)instance;
            return that.Name;
        }
        private object get_8_DeviceInformation_Properties(object instance)
        {
            var that = (global::Windows.Devices.Enumeration.DeviceInformation)instance;
            return that.Properties;
        }

        private global::Windows.UI.Xaml.Markup.IXamlMember CreateXamlMember(string longMemberName)
        {
            global::BatteryDemo.BatteryDemo_Windows_XamlTypeInfo.XamlMember xamlMember = null;
            global::BatteryDemo.BatteryDemo_Windows_XamlTypeInfo.XamlUserType userType;

            switch (longMemberName)
            {
            case "BatteryDemo.BatteryServicePage.Device":
                userType = (global::BatteryDemo.BatteryDemo_Windows_XamlTypeInfo.XamlUserType)GetXamlTypeByName("BatteryDemo.BatteryServicePage");
                xamlMember = new global::BatteryDemo.BatteryDemo_Windows_XamlTypeInfo.XamlMember(this, "Device", "Windows.Devices.Enumeration.DeviceInformation");
                xamlMember.Getter = get_0_BatteryServicePage_Device;
                xamlMember.Setter = set_0_BatteryServicePage_Device;
                break;
            case "BatteryDemo.BatteryServicePage.BatteryLevel":
                userType = (global::BatteryDemo.BatteryDemo_Windows_XamlTypeInfo.XamlUserType)GetXamlTypeByName("BatteryDemo.BatteryServicePage");
                xamlMember = new global::BatteryDemo.BatteryDemo_Windows_XamlTypeInfo.XamlMember(this, "BatteryLevel", "Int32");
                xamlMember.Getter = get_1_BatteryServicePage_BatteryLevel;
                xamlMember.Setter = set_1_BatteryServicePage_BatteryLevel;
                break;
            case "BatteryDemo.MainPage.Devices":
                userType = (global::BatteryDemo.BatteryDemo_Windows_XamlTypeInfo.XamlUserType)GetXamlTypeByName("BatteryDemo.MainPage");
                xamlMember = new global::BatteryDemo.BatteryDemo_Windows_XamlTypeInfo.XamlMember(this, "Devices", "System.Collections.ObjectModel.ObservableCollection`1<Windows.Devices.Enumeration.DeviceInformation>");
                xamlMember.Getter = get_2_MainPage_Devices;
                xamlMember.Setter = set_2_MainPage_Devices;
                break;
            case "Windows.Devices.Enumeration.DeviceInformation.EnclosureLocation":
                userType = (global::BatteryDemo.BatteryDemo_Windows_XamlTypeInfo.XamlUserType)GetXamlTypeByName("Windows.Devices.Enumeration.DeviceInformation");
                xamlMember = new global::BatteryDemo.BatteryDemo_Windows_XamlTypeInfo.XamlMember(this, "EnclosureLocation", "Windows.Devices.Enumeration.EnclosureLocation");
                xamlMember.Getter = get_3_DeviceInformation_EnclosureLocation;
                xamlMember.SetIsReadOnly();
                break;
            case "Windows.Devices.Enumeration.DeviceInformation.Id":
                userType = (global::BatteryDemo.BatteryDemo_Windows_XamlTypeInfo.XamlUserType)GetXamlTypeByName("Windows.Devices.Enumeration.DeviceInformation");
                xamlMember = new global::BatteryDemo.BatteryDemo_Windows_XamlTypeInfo.XamlMember(this, "Id", "String");
                xamlMember.Getter = get_4_DeviceInformation_Id;
                xamlMember.SetIsReadOnly();
                break;
            case "Windows.Devices.Enumeration.DeviceInformation.IsDefault":
                userType = (global::BatteryDemo.BatteryDemo_Windows_XamlTypeInfo.XamlUserType)GetXamlTypeByName("Windows.Devices.Enumeration.DeviceInformation");
                xamlMember = new global::BatteryDemo.BatteryDemo_Windows_XamlTypeInfo.XamlMember(this, "IsDefault", "Boolean");
                xamlMember.Getter = get_5_DeviceInformation_IsDefault;
                xamlMember.SetIsReadOnly();
                break;
            case "Windows.Devices.Enumeration.DeviceInformation.IsEnabled":
                userType = (global::BatteryDemo.BatteryDemo_Windows_XamlTypeInfo.XamlUserType)GetXamlTypeByName("Windows.Devices.Enumeration.DeviceInformation");
                xamlMember = new global::BatteryDemo.BatteryDemo_Windows_XamlTypeInfo.XamlMember(this, "IsEnabled", "Boolean");
                xamlMember.Getter = get_6_DeviceInformation_IsEnabled;
                xamlMember.SetIsReadOnly();
                break;
            case "Windows.Devices.Enumeration.DeviceInformation.Name":
                userType = (global::BatteryDemo.BatteryDemo_Windows_XamlTypeInfo.XamlUserType)GetXamlTypeByName("Windows.Devices.Enumeration.DeviceInformation");
                xamlMember = new global::BatteryDemo.BatteryDemo_Windows_XamlTypeInfo.XamlMember(this, "Name", "String");
                xamlMember.Getter = get_7_DeviceInformation_Name;
                xamlMember.SetIsReadOnly();
                break;
            case "Windows.Devices.Enumeration.DeviceInformation.Properties":
                userType = (global::BatteryDemo.BatteryDemo_Windows_XamlTypeInfo.XamlUserType)GetXamlTypeByName("Windows.Devices.Enumeration.DeviceInformation");
                xamlMember = new global::BatteryDemo.BatteryDemo_Windows_XamlTypeInfo.XamlMember(this, "Properties", "System.Collections.Generic.IReadOnlyDictionary`2<String, Object>");
                xamlMember.Getter = get_8_DeviceInformation_Properties;
                xamlMember.SetIsReadOnly();
                break;
            }
            return xamlMember;
        }
    }

    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks", "4.0.0.0")]    
    [System.Diagnostics.DebuggerNonUserCodeAttribute()]
    internal class XamlSystemBaseType : global::Windows.UI.Xaml.Markup.IXamlType
    {
        string _fullName;
        global::System.Type _underlyingType;

        public XamlSystemBaseType(string fullName, global::System.Type underlyingType)
        {
            _fullName = fullName;
            _underlyingType = underlyingType;
        }

        public string FullName { get { return _fullName; } }

        public global::System.Type UnderlyingType
        {
            get
            {
                return _underlyingType;
            }
        }

        virtual public global::Windows.UI.Xaml.Markup.IXamlType BaseType { get { throw new global::System.NotImplementedException(); } }
        virtual public global::Windows.UI.Xaml.Markup.IXamlMember ContentProperty { get { throw new global::System.NotImplementedException(); } }
        virtual public global::Windows.UI.Xaml.Markup.IXamlMember GetMember(string name) { throw new global::System.NotImplementedException(); }
        virtual public bool IsArray { get { throw new global::System.NotImplementedException(); } }
        virtual public bool IsCollection { get { throw new global::System.NotImplementedException(); } }
        virtual public bool IsConstructible { get { throw new global::System.NotImplementedException(); } }
        virtual public bool IsDictionary { get { throw new global::System.NotImplementedException(); } }
        virtual public bool IsMarkupExtension { get { throw new global::System.NotImplementedException(); } }
        virtual public bool IsBindable { get { throw new global::System.NotImplementedException(); } }
        virtual public bool IsReturnTypeStub { get { throw new global::System.NotImplementedException(); } }
        virtual public bool IsLocalType { get { throw new global::System.NotImplementedException(); } }
        virtual public global::Windows.UI.Xaml.Markup.IXamlType ItemType { get { throw new global::System.NotImplementedException(); } }
        virtual public global::Windows.UI.Xaml.Markup.IXamlType KeyType { get { throw new global::System.NotImplementedException(); } }
        virtual public object ActivateInstance() { throw new global::System.NotImplementedException(); }
        virtual public void AddToMap(object instance, object key, object item)  { throw new global::System.NotImplementedException(); }
        virtual public void AddToVector(object instance, object item)  { throw new global::System.NotImplementedException(); }
        virtual public void RunInitializer()   { throw new global::System.NotImplementedException(); }
        virtual public object CreateFromString(string input)   { throw new global::System.NotImplementedException(); }
    }
    
    internal delegate object Activator();
    internal delegate void AddToCollection(object instance, object item);
    internal delegate void AddToDictionary(object instance, object key, object item);

    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks", "4.0.0.0")]    
    [System.Diagnostics.DebuggerNonUserCodeAttribute()]
    internal class XamlUserType : global::BatteryDemo.BatteryDemo_Windows_XamlTypeInfo.XamlSystemBaseType
    {
        global::BatteryDemo.BatteryDemo_Windows_XamlTypeInfo.XamlTypeInfoProvider _provider;
        global::Windows.UI.Xaml.Markup.IXamlType _baseType;
        bool _isArray;
        bool _isMarkupExtension;
        bool _isBindable;
        bool _isReturnTypeStub;
        bool _isLocalType;

        string _contentPropertyName;
        string _itemTypeName;
        string _keyTypeName;
        global::System.Collections.Generic.Dictionary<string, string> _memberNames;
        global::System.Collections.Generic.Dictionary<string, object> _enumValues;

        public XamlUserType(global::BatteryDemo.BatteryDemo_Windows_XamlTypeInfo.XamlTypeInfoProvider provider, string fullName, global::System.Type fullType, global::Windows.UI.Xaml.Markup.IXamlType baseType)
            :base(fullName, fullType)
        {
            _provider = provider;
            _baseType = baseType;
        }

        // --- Interface methods ----

        override public global::Windows.UI.Xaml.Markup.IXamlType BaseType { get { return _baseType; } }
        override public bool IsArray { get { return _isArray; } }
        override public bool IsCollection { get { return (CollectionAdd != null); } }
        override public bool IsConstructible { get { return (Activator != null); } }
        override public bool IsDictionary { get { return (DictionaryAdd != null); } }
        override public bool IsMarkupExtension { get { return _isMarkupExtension; } }
        override public bool IsBindable { get { return _isBindable; } }
        override public bool IsReturnTypeStub { get { return _isReturnTypeStub; } }
        override public bool IsLocalType { get { return _isLocalType; } }

        override public global::Windows.UI.Xaml.Markup.IXamlMember ContentProperty
        {
            get { return _provider.GetMemberByLongName(_contentPropertyName); }
        }

        override public global::Windows.UI.Xaml.Markup.IXamlType ItemType
        {
            get { return _provider.GetXamlTypeByName(_itemTypeName); }
        }

        override public global::Windows.UI.Xaml.Markup.IXamlType KeyType
        {
            get { return _provider.GetXamlTypeByName(_keyTypeName); }
        }

        override public global::Windows.UI.Xaml.Markup.IXamlMember GetMember(string name)
        {
            if (_memberNames == null)
            {
                return null;
            }
            string longName;
            if (_memberNames.TryGetValue(name, out longName))
            {
                return _provider.GetMemberByLongName(longName);
            }
            return null;
        }

        override public object ActivateInstance()
        {
            return Activator(); 
        }

        override public void AddToMap(object instance, object key, object item) 
        {
            DictionaryAdd(instance, key, item);
        }

        override public void AddToVector(object instance, object item)
        {
            CollectionAdd(instance, item);
        }

        override public void RunInitializer() 
        {
            System.Runtime.CompilerServices.RuntimeHelpers.RunClassConstructor(UnderlyingType.TypeHandle);
        }

        override public object CreateFromString(string input)
        {
            if (_enumValues != null)
            {
                int value = 0;

                string[] valueParts = input.Split(',');

                foreach (string valuePart in valueParts) 
                {
                    object partValue;
                    int enumFieldValue = 0;
                    try
                    {
                        if (_enumValues.TryGetValue(valuePart.Trim(), out partValue))
                        {
                            enumFieldValue = global::System.Convert.ToInt32(partValue);
                        }
                        else
                        {
                            try
                            {
                                enumFieldValue = global::System.Convert.ToInt32(valuePart.Trim());
                            }
                            catch( global::System.FormatException )
                            {
                                foreach( string key in _enumValues.Keys )
                                {
                                    if( string.Compare(valuePart.Trim(), key, global::System.StringComparison.OrdinalIgnoreCase) == 0 )
                                    {
                                        if( _enumValues.TryGetValue(key.Trim(), out partValue) )
                                        {
                                            enumFieldValue = global::System.Convert.ToInt32(partValue);
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                        value |= enumFieldValue; 
                    }
                    catch( global::System.FormatException )
                    {
                        throw new global::System.ArgumentException(input, FullName);
                    }
                }

                return value; 
            }
            throw new global::System.ArgumentException(input, FullName);
        }

        // --- End of Interface methods

        public Activator Activator { get; set; }
        public AddToCollection CollectionAdd { get; set; }
        public AddToDictionary DictionaryAdd { get; set; }

        public void SetContentPropertyName(string contentPropertyName)
        {
            _contentPropertyName = contentPropertyName;
        }

        public void SetIsArray()
        {
            _isArray = true; 
        }

        public void SetIsMarkupExtension()
        {
            _isMarkupExtension = true;
        }

        public void SetIsBindable()
        {
            _isBindable = true;
        }

        public void SetIsReturnTypeStub()
        {
            _isReturnTypeStub = true;
        }

        public void SetIsLocalType()
        {
            _isLocalType = true;
        }

        public void SetItemTypeName(string itemTypeName)
        {
            _itemTypeName = itemTypeName;
        }

        public void SetKeyTypeName(string keyTypeName)
        {
            _keyTypeName = keyTypeName;
        }

        public void AddMemberName(string shortName)
        {
            if(_memberNames == null)
            {
                _memberNames =  new global::System.Collections.Generic.Dictionary<string,string>();
            }
            _memberNames.Add(shortName, FullName + "." + shortName);
        }

        public void AddEnumValue(string name, object value)
        {
            if (_enumValues == null)
            {
                _enumValues = new global::System.Collections.Generic.Dictionary<string, object>();
            }
            _enumValues.Add(name, value);
        }
    }

    internal delegate object Getter(object instance);
    internal delegate void Setter(object instance, object value);

    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks", "4.0.0.0")]    
    [System.Diagnostics.DebuggerNonUserCodeAttribute()]
    internal class XamlMember : global::Windows.UI.Xaml.Markup.IXamlMember
    {
        global::BatteryDemo.BatteryDemo_Windows_XamlTypeInfo.XamlTypeInfoProvider _provider;
        string _name;
        bool _isAttachable;
        bool _isDependencyProperty;
        bool _isReadOnly;

        string _typeName;
        string _targetTypeName;

        public XamlMember(global::BatteryDemo.BatteryDemo_Windows_XamlTypeInfo.XamlTypeInfoProvider provider, string name, string typeName)
        {
            _name = name;
            _typeName = typeName;
            _provider = provider;
        }

        public string Name { get { return _name; } }

        public global::Windows.UI.Xaml.Markup.IXamlType Type
        {
            get { return _provider.GetXamlTypeByName(_typeName); }
        }

        public void SetTargetTypeName(string targetTypeName)
        {
            _targetTypeName = targetTypeName;
        }
        public global::Windows.UI.Xaml.Markup.IXamlType TargetType
        {
            get { return _provider.GetXamlTypeByName(_targetTypeName); }
        }

        public void SetIsAttachable() { _isAttachable = true; }
        public bool IsAttachable { get { return _isAttachable; } }

        public void SetIsDependencyProperty() { _isDependencyProperty = true; }
        public bool IsDependencyProperty { get { return _isDependencyProperty; } }

        public void SetIsReadOnly() { _isReadOnly = true; }
        public bool IsReadOnly { get { return _isReadOnly; } }

        public Getter Getter { get; set; }
        public object GetValue(object instance)
        {
            if (Getter != null)
                return Getter(instance);
            else
                throw new global::System.InvalidOperationException("GetValue");
        }

        public Setter Setter { get; set; }
        public void SetValue(object instance, object value)
        {
            if (Setter != null)
                Setter(instance, value);
            else
                throw new global::System.InvalidOperationException("SetValue");
        }
    }
}



