global using Midland.Core.Common;
using Midland.Core.Api;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Midland.Core.Common;

public static class ReflectionExtensions
{
    public static List<PropertyInfo> BindablePropertyInfo(this Type val)
    {
        return (from PropertyInfo prop in val.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                where prop.Bindable()
                select prop).ToList();
    }

    public static Filter CreateFilter(PropertyInfo property, object obj)
    {
        if (property.GetCustomAttribute(typeof(SortAndFilterIgnoreAttribute)) != null) return null;

        if (property.PropertyType == typeof(FilterValue) || property.PropertyType.IsSubclassOf(typeof(FilterValue)))
        {
            var attribute = (FilterPropertyAttribute)property.GetCustomAttribute(typeof(FilterPropertyAttribute));
            var propValue = (FilterValue)property.GetValue(obj, null);
            if (propValue == null)
            {
                return null;
            }
            else if (propValue is Filter filter)
            {
                filter.Field = filter.Field.IsNullOrBlank(attribute?.Field ?? property.Name);
                filter.Comparison = filter.Comparison.IsNullOrBlank(attribute?.Comparison);
                filter.Order ??= attribute?.Order;
                filter.Group = attribute?.Group ?? 0;
                return filter;
            }
            else
            {
                return new Filter
                {
                    Field = attribute?.Field ?? property.Name,
                    Comparison = propValue.Comparison.IsNullOrBlank(attribute?.Comparison),
                    Value = propValue.Value,
                    Order = propValue.Order ?? attribute?.Order,
                    Group = attribute?.Group ?? 0
                };
            }
        }
        else if (property.PropertyType == typeof(string) || property.PropertyType.IsValueType)
        {
            var fieldInfo = GetFilterFieldInfo(property);
            if (fieldInfo != null)
            {
                return new Filter { Field = fieldInfo.Item1, Value = GetStringValue(property, obj), Comparison = fieldInfo.Item2, Order = fieldInfo.Item3, Group = fieldInfo.Item4 };
            }
        }
        else if (property.PropertyType.IsGenericList())
        {
            var fieldInfo = GetFilterFieldInfo(property);
            if (fieldInfo != null)
            {
                var compare = "IN";
                if (fieldInfo.Item2.IsNotNullOrBlank())
                {
                    compare = fieldInfo.Item2;
                }
                var type = property.PropertyType.GetGenericArguments()[0];
                var value = property.GetValue(obj);
                if (value != null)
                {
                    var json = System.Text.Json.JsonSerializer.Serialize(value);
                    return new Filter { Field = fieldInfo.Item1, Value = json, Comparison = compare, Order = fieldInfo.Item3, ListType = type, Group = fieldInfo.Item4 };
                }
            }
        }
        return null;
    }

    public static List<Filter> CreateFilters(this Object obj)
    {
        var filters = new List<Filter>();
        foreach (var item in obj.GetType().BindablePropertyInfo())
        {
            filters.AddIfNotNull(CreateFilter(item, obj));
        }

        return filters;
    }

    public static List<SortOrderField> CreateSorts(this Object obj)
    {
        var list = new List<SortOrderField>();
        list.AddRange(obj.CreateSortsByAttribute());
        list.AddRange(obj.CreateSortsByPropertyReference());
        list.AddRange(obj.CreateSortsByPropertyName());
        return list;
    }

    public static List<SortOrderField> CreateSortsByAttribute(this Object obj)
    {
        var sorting = new List<SortOrderField>();
        var filterProperties = obj.GetType().BindablePropertyInfo()
                                        .Where(p => p.GetCustomAttribute<SortOrderAttribute>() != null &&
                                               p.PropertyType == typeof(SortOrder));
        foreach (var propInfo in filterProperties)
        {
            if (propInfo.GetValue(obj) is SortOrder sortValues)
            {
                var attribute = (SortOrderAttribute)propInfo.GetCustomAttribute(typeof(SortOrderAttribute));
                sorting.Add(new SortOrderField
                {
                    Field = attribute?.Field ?? propInfo.Name,
                    Asc = sortValues?.Asc ?? attribute.Asc,
                    Order = attribute.Order
                });
            }
        }
        return sorting;
    }

    public static List<SortOrderField> CreateSortsByPropertyName(this Object obj)
    {
        var sorting = new List<SortOrderField>();
        var propInfo = obj.GetType()
                          .BindablePropertyInfo()
                          .Where(p => p.Name.Equals(ApiConstants.SortByPropertyName, StringComparison.OrdinalIgnoreCase))
                          .FirstOrDefault();
        if (propInfo != null)
        {
            var field = propInfo.GetValue(obj);
            if (field != null && field.ToString().IsNotNullOrBlank())
            {
                var direction = obj.GetType()
                                   .BindablePropertyInfo()
                                   .Where(p => p.Name.Equals(ApiConstants.SortByDirPropertyName, StringComparison.CurrentCultureIgnoreCase))
                                   .FirstOrDefault();
                sorting.Add(new SortOrderField()
                {
                    Field = propInfo.GetValue(obj).ToString().MapSortingName(obj),
                    Order = int.MinValue,
                    Asc = direction?.GetValue(obj)?.ToString().ToUpper() == "DESC" ? false : true,
                });
            }
        }

        return sorting;
    }

    public static List<SortOrderField> CreateSortsByPropertyReference(this Object obj)
    {
        var sorting = new List<SortOrderField>();
        var filterProperties = obj.GetType().BindablePropertyInfo().Where(p => p.PropertyType == typeof(SortOrderField));
        foreach (var propInfo in filterProperties)
        {
            var sortValues = (SortOrderField)propInfo.GetValue(obj);
            if (sortValues != null && sortValues.Field.IsNotNullOrBlank())
            {
                sorting.Add(new SortOrderField()
                {
                    Field = sortValues.Field.MapSortingName(obj),
                    Order = sortValues?.Order ?? 0,
                    Asc = sortValues?.Asc ?? true,
                });
            }
        }
        return sorting;
    }

    public static string DisplayDescription(this PropertyInfo propInfo, string defaultValue = null)
    {
        string description = null;

        if (Attribute.IsDefined(propInfo, typeof(DisplayAttribute)))
        {
            var att = (DisplayAttribute)Attribute.GetCustomAttribute(propInfo, typeof(DisplayAttribute));
            description = att.Description;
        }

        if (description.IsNullOrBlank())
        {
            if (defaultValue.IsNullOrBlank())
            {
                description = propInfo.Name.Replace('_', ' ').BreakByCapitals();
            }
            else
            {
                description = defaultValue;
            }
        }

        return description;
    }

    public static string DisplayName(this PropertyInfo propInfo, bool AddSpaces = true)
    {
        string name = null;

        if (Attribute.IsDefined(propInfo, typeof(DisplayAttribute)))
        {
            var attribute = (DisplayAttribute)Attribute.GetCustomAttribute(propInfo, typeof(DisplayAttribute));
            name = attribute.Name;
        }

        if (name.IsNullOrBlank())
        {
            if (AddSpaces)
            {
                name = propInfo.Name.Replace('_', ' ').BreakByCapitals();
            }
            else
            {
                name = propInfo.Name;
            }
        }
        return name;
    }

    public static int DisplayOrder(this PropertyInfo propInfo)
    {
        if (Attribute.IsDefined(propInfo, typeof(DisplayAttribute)))
        {
            var order = ((DisplayAttribute)Attribute.GetCustomAttribute(propInfo, typeof(DisplayAttribute))).GetOrder();
            return order ?? int.MaxValue;
        }
        else
        {
            return int.MaxValue;
        }
    }

    public static Tuple<string, string, int, int> GetFilterFieldInfo(PropertyInfo property)
    {
        if (property.GetCustomAttribute(typeof(SortAndFilterIgnoreAttribute)) != null) return null;
        var attribute = (FilterPropertyAttribute)property.GetCustomAttribute(typeof(FilterPropertyAttribute));
        if (attribute != null)
        {
            return new Tuple<string, string, int, int>(attribute?.Field ?? property.Name, attribute.Comparison, attribute.Order, attribute.Group);
        }
        else
        {
            return new Tuple<string, string, int, int>(property.Name, null, int.MaxValue, 0);
        }
    }

    public static Type GetListType(this Type listType)
    {
        Type genericType = listType.GetGenericArguments()[0];
        return genericType;
    }

    public static object GetPropValue(this object obj, string name)
    {
        if (obj == null) return null;

        var type = obj.GetType();
        var propertyInfo = type.GetProperty(name, BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public);
        if (propertyInfo != null)
        {
            return propertyInfo.GetValue(obj, BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public, null, null, null);
        }
        return null;
    }

    /// <summary>
    /// Safely gets the value of a property by name without throwing AmbiguousMatchException.
    /// </summary>
    /// <param name="obj">The object instance (or null for static properties).</param>
    /// <param name="propertyName">The property name to find.</param>
    /// <param name="bindingFlags">
    /// Optional binding flags (default: public instance, including base classes).
    /// </param>
    /// <param name="declaringTypeFilter">Optional filter to match a specific declaring type.</param>
    /// <returns>The property value, or null if not found or inaccessible.</returns>
    public static object GetPropValueSafe(
        this object obj,
        string propertyName,
        BindingFlags bindingFlags = BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy,
        Type declaringTypeFilter = null)
    {
        if (obj == null) return null;

        if (string.IsNullOrWhiteSpace(propertyName)) return null;

        var type = obj.GetType();

        // Find the property without causing AmbiguousMatchException
        var prop = type.GetProperties(bindingFlags)
                       .Where(p => p.Name == propertyName)
                       .Where(p => declaringTypeFilter == null || p.DeclaringType == declaringTypeFilter)
                       .FirstOrDefault();

        if (prop == null || !prop.CanRead)
            return null; // No readable property found

        try
        {
            return prop.GetValue(obj);
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public static IEnumerable<PropertyInfo> GetReadablePublicProperties(this Type type)
    {
        if (type.IsInterface)
        {
            var propertyInfos = new List<PropertyInfo>();
            var considered = new List<Type>();
            var queue = new Queue<Type>();
            considered.Add(type);
            queue.Enqueue(type);
            Type subType;
            while (queue.Count > 0)
            {
                subType = queue.Dequeue();
                foreach (var subInterface in subType.GetInterfaces().ToList())
                {
                    if (considered.Contains(subInterface)) { continue; }

                    considered.Add(subInterface);
                    queue.Enqueue(subInterface);
                }

                var typeProperties = subType.GetProperties(BindingFlags.FlattenHierarchy |
                                                                          BindingFlags.Public |
                                                                          BindingFlags.Instance).ToList();

                var newPropertyInfos = typeProperties.Where(prop => !propertyInfos.Contains(prop)).ToList();

                propertyInfos.InsertRange(0, newPropertyInfos);
            }

            return
                from itm in propertyInfos
                where itm.CanRead
                select itm;
        }

        return type.GetProperties(BindingFlags.FlattenHierarchy | BindingFlags.Public | BindingFlags.Instance);
    }

    public static string GetStringValue(this PropertyInfo property, Object obj)
    {
        if (obj == null) return null;

        var value = property.GetValue(obj, null);
        if (value != null)
        {
            return value.ToString();
        }
        return null;
    }

    public static bool HasProp(this object obj, string name, out PropertyInfo propInfo)
    {
        var type = obj.GetType();
        propInfo = type.GetProperty(name, BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public);
        return propInfo != null;
    }

    public static bool IsGenericList(this Type type)
    {
        return type.IsGenericType && type.GetGenericTypeDefinition() == typeof(List<>);
    }

    public static string ListItemDataName(this MemberInfo memberInfo)
    {
        string name = null;

        if (Attribute.IsDefined(memberInfo, typeof(DataTypeAttribute)))
        {
            var att = (DataTypeAttribute)Attribute.GetCustomAttribute(memberInfo, typeof(DataTypeAttribute));
            name = att.CustomDataType;
            if (name.IsNullOrBlank())
            {
                name = att.DataType.ToString();
            }
        }
        return name;
    }

    public static string MapSortingName(this string field, object obj)
    {
        var filterProperties = obj.GetType().BindablePropertyInfo()
                                .Where(p => p.GetCustomAttribute<FilterPropertyAttribute>() != null &&
                                       p.PropertyType != typeof(SortOrderField));

        var found = filterProperties.FirstOrDefault(r => r.Name.Equals(field, StringComparison.OrdinalIgnoreCase));
        if (found != null)
        {
            return found.GetCustomAttribute<FilterPropertyAttribute>().Field;
        }
        return field;
    }

    public static IEnumerable<PropertyInfo> OrderProperties(this IEnumerable<PropertyInfo> props)
    {
        var results = new List<PropertyInfo>();
        var orderedProps = new Dictionary<int, List<PropertyInfo>>();

        foreach (var prop in props)
        {
            int order = prop.DisplayOrder();
            if (order < int.MaxValue)
            {
                if (!orderedProps.ContainsKey(order))
                {
                    orderedProps.Add(order, []);
                }
                orderedProps[order].Add(prop);
            }
            else
            {
                results.Add(prop);
            }
        }

        foreach (var order in orderedProps.Keys.OrderByDescending(key => key))
        {
            var reversed = orderedProps[order];
            reversed.Reverse();
            foreach (var prop in reversed)
            {
                results.Insert(0, prop);
            }
        }

        return results;
    }

    public static string PropertyTypeName(this PropertyInfo propertyInfo)
    {
        if (propertyInfo.PropertyType.IsGenericType)
        {
            if (propertyInfo.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                return propertyInfo.PropertyType.GetGenericArguments()[0].Name;
            }
            else
            {
                var argCount = int.Parse(propertyInfo.PropertyType.Name.AfterX("`"));
                var args = new List<string>();
                for (var i = 0; i < argCount; i++)
                {
                    args.Add(propertyInfo.PropertyType.GetGenericArguments()[0].Name);
                }
                return $"{propertyInfo.PropertyType.Name.BeforeX("`")}<{args.ListToString(",")}>";
            }
        }

        return propertyInfo.PropertyType.Name;
    }

    public static void SetPropValue(this object obj, string name, object value)
    {
        var type = obj.GetType();
        var info = type.GetProperty(name, BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public);
        info?.SetValue(obj, value, BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public, null, null, null);
    }

    internal static bool Bindable(this PropertyInfo propInfo)
    {
        if (propInfo == null || !propInfo.CanRead)
        {
            return false;
        }
        else if (Attribute.IsDefined(propInfo, typeof(BindableAttribute)))
        {
            return (Attribute.GetCustomAttribute(propInfo, typeof(BindableAttribute)) as BindableAttribute).Bindable;
        }
        else
        {
            return true;
        }
    }
}