﻿using Network.Attributes;
using Network.Packets;
using System;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;

namespace Network.Converter
{
    /// <summary>
    /// Provides helper methods for serialising and deserialising packets to and from their binary form.
    /// </summary>
    internal static class PacketConverterHelper
    {
        #region Variables

        /// <summary>
        /// The <see cref="Type"/> of the custom property that will cause a property to be ignored during serialisation.
        /// See <see cref="PacketIgnorePropertyAttribute"/> for more information regarding its usage.
        /// </summary>
        public static readonly Type PropertyIgnoreAttributeType = typeof(PacketIgnorePropertyAttribute);

        #endregion Variables

        #region Methods

        #region Type Checking

        /// <summary>
        /// Checks whether the given <see cref="Type"/> is a primitive type, that is if it lives in the 'System' namespace.
        /// </summary>
        /// <param name="type">The <see cref="Type"/> to test.</param>
        /// <returns>Whether the given <see cref="Type"/> is a primitive.</returns>
        /// <remarks>If the given <see cref="Type"/> is null, then the method will return false.</remarks>
        public static bool TypeIsPrimitive(Type type) => type?.Namespace?.Equals("System") ?? false;

        /// <summary>
        /// Checks whether the underlying <see cref="Type"/> of the given property is a primitive type. See
        /// <see cref="TypeIsPrimitive"/> for more information regarding its usage.
        /// </summary>
        /// <param name="property">The <see cref="PropertyInfo"/> to test.</param>
        /// <returns>Whether the given <see cref="PropertyInfo"/>s underlying <see cref="Type"/> is primitive.</returns>
        /// <remarks>
        /// If the given properties underlying element <see cref="Type"/> is null, then the method will return false.
        /// </remarks>
        public static bool PropertyIsPrimitive(PropertyInfo property) => property.PropertyType?.Namespace?.Equals("System") ?? false;

        #endregion Type Checking

        #region Getting Properties Of An Object

        /// <summary>
        /// Gets all the <see cref="PropertyInfo"/>s of the given <see cref="Type"/> that should be serialised (lack the
        /// <see cref="PacketIgnorePropertyAttribute"/> attribute) and returns them as an array.
        /// </summary>
        /// <param name="type">The <see cref="Type"/> whose <see cref="PropertyInfo"/>s to read.</param>
        /// <returns>An array of all the <see cref="PropertyInfo"/>s on the given object.</returns>
        public static PropertyInfo[] GetTypeProperties(Type type)
        {
            //Returns all properties of the given type that lack the custom PacketIgnorePropertyAttribute
            return type.GetProperties().Where(property =>
            {
                return property.GetCustomAttribute(PropertyIgnoreAttributeType) == null;
            }).ToArray();
        }

        /// <summary>
        /// Gets all the <see cref="PropertyInfo"/>s of the given <see cref="object"/> that should be serialised and
        /// returns them as an array. See <see cref="GetTypeProperties"/> for more information.
        /// </summary>
        /// <param name="_object">The <see cref="object"/> whose <see cref="PropertyInfo"/>s to read.</param>
        /// <returns>An array of all the <see cref="PropertyInfo"/>s on the given object.</returns>
        public static PropertyInfo[] GetObjectProperties(object _object)
        {
            //Returns all properties of the given objects type that lack the custom PacketIgnorePropertyAttribute
            return _object.GetType().GetProperties().Where(property =>
            {
                return property.GetCustomAttribute(PropertyIgnoreAttributeType) == null;
            }).ToArray();
        }

        #endregion Getting Properties Of An Object

        #region Type Instantiation

        /// <summary>
        /// Instantiates and returns a default <see cref="object"/> of the given <see cref="Type"/>.
        /// </summary>
        /// <param name="objectType">The <see cref="Type"/> to instantiate.</param>
        /// <returns>The default instance of the given <see cref="Type"/>.</returns>
        public static object InstantiateObject(Type objectType)
        {
            bool parameterlessConstructorExists =
                objectType.GetConstructor(BindingFlags.Public | BindingFlags.Instance, null, new Type[0], null) != null;

            //If a default parameterless constructor exists, we use it
            if (parameterlessConstructorExists)
            {
                return Activator.CreateInstance(objectType);
            }

            return FormatterServices.GetUninitializedObject(objectType);
        }

        /// <summary>
        /// Instantiates and returns a default <see cref="Packet"/> of the given <see cref="Type"/>.
        /// </summary>
        /// <param name="packetType">The <see cref="Type"/> to instantiate.</param>
        /// <returns>The default instance of the given <see cref="Type"/>.</returns>
        public static Packet InstantiatePacket(Type packetType) => (Packet)InstantiateObject(packetType);

        /// <summary>
        /// Instantiates and returns a default <see cref="object"/> of the given generic type.
        /// </summary>
        /// <typeparam name="O">The generic type of the object to instantiate.</typeparam>
        /// <returns>The default instance of the given generic type.</returns>
        public static O InstantiateGenericObject<O>() => (O)InstantiateObject(typeof(O));

        /// <summary>
        /// Instantiates and returns a default <see cref="object"/> of the given generic type.
        /// </summary>
        /// <typeparam name="P">The generic type of packet to instantiate.</typeparam>
        /// <returns>The default instance of the given generic type.</returns>
        public static P InstantiateGenericPacket<P>() where P : Packet => (P)InstantiateObject(typeof(P));

        #endregion Type Instantiation

        #endregion Methods
    }
}