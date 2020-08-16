using System;
using System.Collections.Generic;
using System.Text;

namespace Gitmax.Lib.Extensions {
    public static class TypeExtensions {
        public static object GetDefaultValue(this Type type) {
            return type.IsValueType ? Activator.CreateInstance(type) : null;
        }
    }
}
