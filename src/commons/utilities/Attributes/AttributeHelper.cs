using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Mov.Utilities.Attributes
{
    /// <summary>
    /// アトリビュートのヘルパークラス
    /// </summary>
    public static class AttributeHelper
    {
        
        public static T GetAttribute<T>(MemberInfo member) where T : Attribute
        {
            var attribute = member.GetCustomAttributes(typeof(T), false).SingleOrDefault();
            if (attribute == null)
            {
                throw new ArgumentException(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        "The {0} attribute must be defined on member {1}",
                        typeof(T).Name,
                        member.Name));
            }
            return (T)attribute;
        }

    }
}