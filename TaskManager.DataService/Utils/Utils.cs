using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Web;

namespace TaskManager.DataService.Utils
{
    public class Utils
    {
        public static PropertyInfo GetPropertyByDisplayNameAttribute(Type t, string displayName)
        {
            IEnumerable<PropertyInfo> props = t.GetProperties().Where(x => Attribute.IsDefined(x, typeof(DisplayAttribute)));
            PropertyInfo prop = props.FirstOrDefault(x => x.CustomAttributes.Any(y => y.NamedArguments != null && y.NamedArguments.Any(z => z.TypedValue.Value.Equals(displayName))));
            return prop;
        }
    }
}