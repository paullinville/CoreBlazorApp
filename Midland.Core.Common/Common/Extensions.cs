using System.Collections;
using System.Globalization;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Web;

namespace Midland.Core.Common;

public static class Extensions
{
    private static Random rnd = new Random();

    public static void AddIfNotNull<T>(this List<T> list, T value)
    {
        if (list != null && value != null)
        {
            list.Add(value);
        }
    }

    public static string After(this string str, int startIndex)
    {
        if (str == null) return null;
        startIndex = Math.Max(0, startIndex);
        int maxStartIndex = str.Length - 1;

        if (maxStartIndex < startIndex)
        {
            return "";
        }
        else
        {
            return str.Substring(startIndex);
        }
    }

    public static string After(this string str, int startIndex, int length)
    {
        if (str == null) return null;
        startIndex = Math.Max(0, startIndex);
        int maxStartIndex = str.Length - 1;
        int maxLength = str.Length - startIndex;

        if (maxStartIndex < startIndex)
        {
            return "";
        }

        if (maxLength > length)
        {
            maxLength = length;
        }

        return str.Substring(startIndex, maxLength);
    }

    public static string AfterLastX(this string str, string x, bool includeX = false, StringComparison compare = StringComparison.OrdinalIgnoreCase)
    {
        if (str.IsNullOrBlank())
            return "";

        int i;

        i = str.LastIndexOf(x, compare);
        if (!includeX & i >= 0)
            i = i + x.Length;

        if (i >= 0)
            return str.Substring(i);
        else
            return "";
    }

    public static string AfterX(this string str, string x, bool includeX = false, StringComparison compare = StringComparison.OrdinalIgnoreCase)
    {
        if (str.IsNullOrBlank())
        {
            return "";
        }

        int i;

        i = str.IndexOf(x, compare);
        if (!includeX & i >= 0)
        {
            i = i + x.Length;
        }

        if (i >= 0)
        {
            return str.Substring(i);
        }
        else
        {
            return "";
        }
    }

    public static string AlphaNumericOnly(this string str)
    {
        char[] arr = str.ToCharArray();

        arr = Array.FindAll<char>(arr, (c => (char.IsLetterOrDigit(c))));

        return new string(arr);
    }

    /// <summary>
    /// Appends the value to the list then returns the list.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="list">The list to be added to</param>
    /// <param name="value">The value to add</param>
    /// <param name="appendIfNull">
    /// if true (default) nulls are appended. If false is passed null values will not be appended.
    /// </param>
    /// <returns></returns>
    public static List<T> Append<T>(this List<T> list, T value, bool appendIfNull = true)
    {
        if (list != null && (value != null || appendIfNull))
        {
            list.Add(value);
        }

        return list;
    }

    /// <summary>
    /// Returns the value of <strong>this</strong> object converted to the specified type.
    /// </summary>
    /// <typeparam name="T">The Type being converted to.</typeparam>
    /// <param name="value">The value being converted.</param>
    /// <returns></returns>
    public static T As<T>(this object value)
        => value.As<T>(default);

    /// <summary>
    /// Returns the value of <strong>this</strong> object converted to the specified type.
    /// </summary>
    /// <typeparam name="T">The Type being converted to.</typeparam>
    /// <param name="value">The value being converted.</param>
    /// <param name="defaultValue">The default value to return if 'value' is NULL.</param>
    /// <returns></returns>
    public static T As<T>(this object value, T defaultValue = default)
    {
        try
        {
            var toType = typeof(T);
            if (value == null || value == DBNull.Value || Equals(value, defaultValue)) return defaultValue;
            if (value is string)
            {
                if (toType == typeof(Guid))
                {
                    return As(new Guid(Convert.ToString(value, CultureInfo.CurrentCulture)), defaultValue);
                }
                else if (string.IsNullOrEmpty(value as string) && toType != typeof(string))
                {
                    return As(null, defaultValue);
                }
                else if (toType.IsEnum)
                {
                    if (Enum.IsDefined(toType, value))
                    {
                        return (T)Enum.Parse(toType, value.ToString());
                    }
                    else if ((value as string).IsNumeric())
                    {
                        var intValue = Convert.ToInt32(value);
                        return intValue.As<T>();
                    }
                }
                else if (toType == typeof(bool))
                {
                    if ((new[] { "1", "TRUE", "YES" }).Contains(value.ToString().ToUpper()))
                    {
                        return As(true, defaultValue);
                    }
                    else if ((new[] { "0", "FALSE", "NO" }).Contains(value.ToString().ToUpper()))
                    {
                        return As(false, defaultValue);
                    }
                }
                else if (toType == typeof(decimal) && (value as string).ContainsAny("$", ",", " "))
                {
                    return As(value.ToString().Replace("$", "").Replace(",", "").Replace(" ", ""), defaultValue);
                }
            }
            else
            {
                if (typeof(T) == typeof(string))
                {
                    return As(Convert.ToString(value, CultureInfo.CurrentCulture), defaultValue);
                }
            }

            if (toType.IsGenericType && toType.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
            {
                toType = Nullable.GetUnderlyingType(toType);
            }

            var canConvert = toType is IConvertible || toType.IsValueType && !toType.IsEnum;
            return canConvert ? (T)Convert.ChangeType(value, toType, CultureInfo.CurrentCulture) : (T)value;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return defaultValue;
        }
    }

    public static IEnumerable<T> AsList<T>(this T val)
    {
        return new List<T>() { val };
    }

    public static string BeforeX(this string str, string x, bool includeX = false, StringComparison compare = StringComparison.OrdinalIgnoreCase)
    {
        int i;

        i = str.IndexOf(x, compare);
        if (i < 0)
        {
            return "";
        }
        if (includeX)
        {
            i = i + x.Length;
        }
        if (i >= 0)
        {
            return str.Substring(0, i);
        }
        else
        {
            return "";
        }
    }

    public static string BreakByCapitals(this string name)
    {
        if (name == null) return null;
        return string.Join(" ", Regex.Split(name, @"(?<=[a-z])(?=[A-Z])|(?<=[A-Z])(?=[A-Z][a-z])|(?<=[a-z])(?=[0-9])"));
    }

    public static string BreakByCapitols(this string name, string insertString = " $1")
    {
        return Regex.Replace(name, "((?<=[a-z])[A-Z]|[A-Z](?=[a-z]))", insertString).Trim();
    }

    public static bool Contains(this string source, string compare, StringComparison comparison = StringComparison.OrdinalIgnoreCase)
    {
        return source?.IndexOf(compare, comparison) >= 0;
    }

    public static bool ContainsAny(this string source, params string[] needles)
    => needles.Any(needle => source.Contains(needle));

    public static Dictionary<string, string> ConvertTo(this IDictionary<string, object> dic)
    {
        if (dic == null || dic.IsEmpty())
        {
            return new Dictionary<string, string>();
        }
        else
        {
            return new Dictionary<string, string>(dic?.Select(de => new KeyValuePair<string, string>(de.Key, de.Value?.ToString())));
        }
    }

    public static string CopyFile(this string settingsName, string originDirectory, string destinationDirectory)
    {
        if (File.Exists(Path.Combine(originDirectory, settingsName)))
        {
            if (!originDirectory.Equals(destinationDirectory, StringComparison.OrdinalIgnoreCase))
            {
                File.Copy(Path.Combine(originDirectory, settingsName), Path.Combine(destinationDirectory, settingsName), true);
                return $"{settingsName} copied to {destinationDirectory}";
            }
            {
                return $"{settingsName} Not Copied. origin ({originDirectory}) and destination ({destinationDirectory}) folders are the same.";
            }
        }
        else
        {
            return $"{settingsName} Not Copied. {Path.Combine(originDirectory, settingsName)} not found.";
        }
    }

    public static DateTime? Date(this string str)
    {
        if (DateTime.TryParse(str, out DateTime d))
        {
            return d;
        }
        else
        {
            return null;
        }
    }

    public static List<DateTime> DaysInWeek(this DateTime val, DayOfWeek firstDayOfWeek = DayOfWeek.Monday)
    {
        return val.WeekForDate(firstDayOfWeek).Values.ToList();
    }

    public static string EncodeRoute(this string route)
    {
        var output = new System.Text.StringBuilder();
        foreach (var part in route.Split('/', StringSplitOptions.RemoveEmptyEntries))
        {
            output.Append(HttpUtility.UrlEncode(part) + "/");
        }
        return output.ToString().TrimEnd('/');
    }

    public static U Entry<T, U>(this IDictionary<T, U> dic, T key, U valIfNotContained = default)
    {
        if (dic == null || key == null)
        {
            return valIfNotContained;
        }

        if (dic.ContainsKey(key))
            return dic[key];
        else
            return valIfNotContained;
    }

    public static bool Equivalent(this string value, string compare)
    {
        if (value == null)
        {
            return compare == null || compare.IsNullOrBlank();
        }
        else if (compare == null)
        {
            return value == null || value.IsNullOrBlank();
        }
        else
        {
            return value.Trim().Equals(compare.Trim(), StringComparison.OrdinalIgnoreCase);
        }
    }

    public static Dictionary<T, U> FilterOut<T, U>(this IDictionary<T, U> val, IEnumerable<T> keysToremove)
    {
        Dictionary<T, U> result = new Dictionary<T, U>(val);
        foreach (T key in keysToremove.Values())
        {
            if (key != null)
                result.Remove(key);
        }
        return result;
    }

    public static Dictionary<T, U> FilterTo<T, U>(this IDictionary<T, U> val, IEnumerable<T> keysToCopy)
    {
        Dictionary<T, U> result = new Dictionary<T, U>();
        foreach (T key in keysToCopy.Values())
        {
            if (key != null && val.ContainsKey(key))
                result.Add(key, val[key]);
        }
        return result;
    }

    public static Dictionary<Key, T> FilterToDictionary<Key, T>(this IEnumerable<T> vals, Func<T, Key> selector)
    {
        Dictionary<Key, T> dic = new Dictionary<Key, T>();
        foreach (var item in vals.Values())
        {
            Key thekey = selector.Invoke(item);
            if (!dic.ContainsKey(thekey))
            {
                dic.Add(thekey, item);
            }
        }
        return dic;
    }

    public static string FirstLetterToLower(this string source)
    {
        if (string.IsNullOrEmpty(source))
        {
            return string.Empty;
        }
        // convert to char array of the string
        char[] letters = source.ToCharArray();
        // upper case the first char
        letters[0] = char.ToLower(letters[0]);
        // return the array made of the new char array
        return new string(letters);
    }

    public static string FirstLetterToUpper(this string source)
    {
        if (string.IsNullOrEmpty(source))
        {
            return string.Empty;
        }
        // convert to char array of the string
        char[] letters = source.ToCharArray();
        // upper case the first char
        letters[0] = char.ToUpper(letters[0]);
        // return the array made of the new char array
        return new string(letters);
    }

    public static IEnumerable<T> ForEach<T>(this IEnumerable<T> val, Action<T> action)
    {
        foreach (T itm in val.Values())
        {
            action(itm);
        }
        return val;
    }

    /// <summary>
    /// Returns a random item (with replacement). If the list passed is null or has no items it
    /// returns the default(T).
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="values"></param>
    /// <returns></returns>
    public static T GetRandom<T>(this List<T> values)
    {
        if (values.IsEmpty()) return default(T);

        return values[rnd.Next(values.Count)];
    }

    public static Dictionary<Key, List<T>> GroupTo<Key, T>(this IEnumerable<T> vals, Func<T, Key> selector)
    {
        Dictionary<Key, List<T>> dic = new Dictionary<Key, List<T>>();
        foreach (T itm in vals.Values())
        {
            Key thekey = selector.Invoke(itm);
            if (thekey != null)
            {
                if (!dic.ContainsKey(thekey))
                {
                    dic.Add(thekey, new List<T>());
                }
                dic[thekey].Add(itm);
            }
        }

        return dic;
    }

    public static Dictionary<key, List<U>> GroupTo<key, T, U>(this IEnumerable<T> vals, Func<T, key> selector, Func<T, U> valueSelect)
    {
        Dictionary<key, List<U>> dic = new Dictionary<key, List<U>>();
        foreach (T itm in vals.Values())
        {
            key thekey = selector.Invoke(itm);
            if (thekey != null)
            {
                if (!dic.ContainsKey(thekey))
                {
                    dic.Add(thekey, new List<U>());
                }
                dic[thekey].Add(valueSelect.Invoke(itm));
            }
        }

        return dic;
    }

    public static Dictionary<object, List<T>> GroupTo<T>(this IEnumerable<T> vals, Func<T, object> selector)
    {
        Dictionary<object, List<T>> dic = new Dictionary<object, List<T>>();
        foreach (T itm in vals.Values())
        {
            object thekey = selector.Invoke(itm);
            if (!dic.ContainsKey(thekey))
            {
                dic.Add(thekey, new List<T>());
            }
            dic[thekey].Add(itm);
        }

        return dic;
    }

    public static bool IsEmpty(this Guid? val)
    {
        if (!val.HasValue || val.Value.IsEmpty())
            return true;
        else
            return false;
    }

    public static bool IsEmpty(this Guid val)
    {
        return val.Equals(Guid.Empty);
    }

    public static bool IsEmpty<T>(this IEnumerable<T> val)
    {
        return val == null || val.Count() == 0;
    }

    public static bool IsEmptyGuid(this string val)
    {
        if (val.IsNullOrBlank())
        {
            return true;
        }
        else
        {
            if (Guid.TryParse(val, out Guid result))
            {
                return result.IsEmpty();
            }
            else
            {
                return false;
            }
        }
    }

    public static bool IsGuid(this string val)
    {
        if (val.IsNullOrBlank())
        {
            return false;
        }
        else
        {
            if (Guid.TryParse(val, out Guid result))
            {
                return result.IsNotEmpty();
            }
            else
            {
                return false;
            }
        }
    }

    public static bool IsNonWorkDay(this DateTime day, IEnumerable<DateTime> Holidays)
    {
        return day.DayOfWeek == DayOfWeek.Saturday || day.DayOfWeek == DayOfWeek.Sunday || Holidays.Contains(day.Date);
    }

    public static bool IsNotEmpty(this Guid? val)
    {
        return !val.IsEmpty();
    }

    public static bool IsNotEmpty(this Guid val)
    {
        return !val.Equals(Guid.Empty);
    }

    public static bool IsNotEmpty<T>(this IEnumerable<T> val)
    {
        return !val.IsEmpty();
    }

    public static bool IsNotNullOrBlank(this string val)
    {
        return !val.IsNullOrBlank();
    }

    public static bool IsNullOrBlank(this string val)
    {
        if (val == null)
            return true;

        if (val.Trim() == "")
            return true;
        return false;
    }

    public static string IsNullOrBlank(this string val, string useValue)
    {
        if (val == null)
            return useValue;

        if (val.Trim() == "")
            return useValue;
        return val;
    }

    public static bool IsNumeric(this string source)
    {
        if (source.IsNullOrBlank())
        {
            return false;
        }
        else
        {
            return double.TryParse(source, out _);
        }
    }

    public static string Left(this string tempStr, int v2)
    {
        if (tempStr == null)
        {
            return tempStr;
        }
        return tempStr.After(0, v2);
    }

    public static string ListToString(this IEnumerable<string> val)
    {
        System.Text.StringBuilder bld = new System.Text.StringBuilder();
        foreach (string strng in val)
            bld.Append(strng);
        return bld.ToString();
    }

    public static string ListToString(this IEnumerable<string> value, string delimiter, bool trimValues = true)
    {
        int count = value.Count() - 1;
        List<string> list = value.ToList();
        System.Text.StringBuilder strBldr = new System.Text.StringBuilder();
        for (int loopCounter = 0; loopCounter <= count; loopCounter++)
        {
            if (trimValues)
                strBldr.Append((list[loopCounter] + "").Trim());
            else
                strBldr.Append(list[loopCounter]);

            if (loopCounter < count)
                strBldr.Append(delimiter);
        }
        return strBldr.ToString();
    }

    public static string ListToString(this IEnumerable<char> value, string delimiter, bool trimValues = true)
    {
        return (from itm in value
                select Convert.ToString(itm)).ListToString(delimiter, trimValues);
    }

    public static string MakeQueryString(this object obj)
    {
        if (obj == null)
        {
            return "";
        }
        else
        {
            var properties = from p in obj.GetType().GetProperties()
                             select p.Name + "=" + HttpUtility.UrlEncode($"{p.GetValue(obj, null) ?? "null"}");

            if (properties.IsEmpty())
            {
                return "";
            }
            else
            {
                return "?" + String.Join("&", properties.ToArray());
            }
        }
    }

    public static DateTime NearestDayOfWeek(this DateTime val, DayOfWeek dow)
    {
        if (val.DayOfWeek == dow)
        {
            return val;
        }
        else
        {
            DateTime tempDate = val;
            do
            {
                tempDate = tempDate.AddDays(1);
            }
            while (!(tempDate.DayOfWeek == dow));
            return tempDate;
        }
    }

    public static DateTime NearestWeekDay(this DateTime val)
    {
        var dow = val;

        while (dow.DayOfWeek == DayOfWeek.Saturday || dow.DayOfWeek == DayOfWeek.Sunday)
        {
            dow = dow.AddDays(1);
        }
        return dow;
    }

    public static DateTime NearestWorkDay(this DateTime val, uint days, HashSet<DateTime> holidays)
    {
        var dow = val;
        DateTime? nextDay = null;
        var hol = holidays ?? new HashSet<DateTime>();
        var count = 0;
        while (nextDay == null)
        {
            if (dow.DayOfWeek == DayOfWeek.Saturday || dow.DayOfWeek == DayOfWeek.Sunday || hol.Contains(dow))
            {
                dow = dow.AddDays(1);
            }
            else if (count == days)
            {
                nextDay = dow;
            }
            else
            {
                count++;
                dow = dow.AddDays(1);
            }
        }

        while (dow.DayOfWeek == DayOfWeek.Saturday || dow.DayOfWeek == DayOfWeek.Sunday)
        {
            dow = dow.AddDays(1);
        }
        return dow;
    }

    public static DateTime NextWeekDay(this DateTime val)
    {
        var dow = val.AddDays(1);
        return dow.NearestWeekDay();
    }

    public static DateTime NextWorkDay(this DateTime start, int numberOfDays, IEnumerable<DateTime> Holidays)
    {
        var Count = 0;
        DateTime sDay = start.NearestWeekDay();

        IEnumerable<DateTime> skipped = Holidays.Values().Select(d => d.Date).ToHashSet();
        bool isWorkingDay(DateTime currentDate)
        {
            return !(
                currentDate.DayOfWeek == DayOfWeek.Saturday
                || currentDate.DayOfWeek == DayOfWeek.Sunday
                || skipped.Contains(currentDate.Date));
        }

        while (!isWorkingDay(sDay))
        {
            sDay = sDay.AddDays(1);
        }

        while (Count < numberOfDays)
        {
            sDay = sDay.AddDays(1);
            if (isWorkingDay(sDay))
            {
                Count++;
            }
        }

        return sDay;
    }

    public static IEnumerable<T> PageOf<T>(this PageRequestModel pageRequestModel, IEnumerable<T> all)
    {
        return all.Values().Skip(pageRequestModel.Skip()).Take(pageRequestModel.Take());
    }

    public static PageResultsModel<T> PageResults<T>(this PageRequestModel pageRequestModel, IEnumerable<T> all)
    {
        var pages = all.Values().Skip(pageRequestModel.Skip()).Take(pageRequestModel.Take()).ToList();

        return new PageResultsModel<T>(pages, pageRequestModel, all.Count());
    }

    public static IEnumerable<Tuple<string, string>> PossibleTags(this Type data)
    {
        var tags = new List<Tuple<string, string>>();
        foreach (PropertyInfo propInfo in data.GetProperties().Where(prop => prop.PropertyType.Namespace.StartsWith("Foil.Common.BusinessServices.Models")))
        {
            propInfo.PropertyType
                    .GetProperties()
                    .ForEach(field => tags.Add(new Tuple<string, string>($"{field.DisplayName()}", $"{propInfo.Name}:{field.Name}")));
        }

        data.GetProperties().ForEach(prop => tags.Add(new Tuple<string, string>($"{prop.DisplayName()}", $"{data.Name}:{prop.Name}")));
        return tags;
    }

    public static DateTime PreviousDayOfWeek(this DateTime val, DayOfWeek dow)
    {
        DateTime tempDate = val;
        do
        {
            tempDate = tempDate.AddDays(-1);
        }
        while (!(tempDate.DayOfWeek == dow));
        return tempDate;
    }

    public static DayOfWeek PreviousDayOfWeek(this DayOfWeek val)
    {
        if (val == DayOfWeek.Sunday)
        {
            return DayOfWeek.Saturday;
        }
        else
        {
            return val - 1;
        }
    }

    public static DateTime PreviousWorkDay(this DateTime start, int numberOfDays, IEnumerable<DateTime> Holidays)
    {
        var Count = 0;
        DateTime sDay = start;

        IEnumerable<DateTime> skipped = Holidays.Values().Select(d => d.Date).ToHashSet();

        bool isWorkingDay(DateTime currentDate)
        {
            return !(
                currentDate.DayOfWeek == DayOfWeek.Saturday
                || currentDate.DayOfWeek == DayOfWeek.Sunday
                || skipped.Contains(currentDate.Date));
        }

        while (!isWorkingDay(sDay))
        {
            sDay = sDay.AddDays(-1);
        }

        while (Count < numberOfDays)
        {
            sDay = sDay.AddDays(-1);
            if (isWorkingDay(sDay))
            {
                Count++;
            }
        }

        return sDay;
    }

    public static int Quarter(this DateTime date)
    {
        if (date.Month >= 1 && date.Month <= 3)
        {
            return 1;
        }
        else if (date.Month >= 4 && date.Month <= 6)
        {
            return 2;
        }
        else if (date.Month >= 7 && date.Month <= 9)
        {
            return 3;
        }
        else
        {
            return 4;
        }
    }

    /// <summary>
    /// Removes the string between the first instance of <paramref name="start"/> and the first
    /// instance of <paramref name="end"/> if the index of <paramref name="end"/> is &gt; the index
    /// of <paramref name="start"/>. The <paramref name="start"/> and <paramref name="end"/> values
    /// are discarded.
    /// </summary>
    /// <param name="str">The value to search</param>
    /// <param name="start">String starting the match</param>
    /// <param name="end">String ending the match</param>
    /// <param name="removed">The value found between <paramref name="start"/> and <paramref name="end"/></param>
    /// <param name="compare"></param>
    /// <returns>The <paramref name="str"/> with the part that was chopped.</returns>
    public static string Remove(this string str, string start, string end, out string removed, StringComparison compare = StringComparison.OrdinalIgnoreCase)
    {
        if (str.IsNullOrBlank() || start == null || end == null)
        {
            removed = "";
            return str;
        }

        int indexStart = str.IndexOf(start, compare);

        if (indexStart < 0)
        {
            removed = "";
            return str;
        }

        int indexEnd = str.IndexOf(end, indexStart + start.Length, compare);

        if (indexEnd < 0)
        {
            removed = "";
            return str;
        }

        if (indexStart >= 0 && indexStart < indexEnd)
        {
            removed = str.Substring(indexStart + start.Length, indexEnd - (indexStart + start.Length));
            return str.Substring(0, indexStart) + str.Substring(indexEnd + end.Length);
        }
        else
        {
            removed = "";
            return str;
        }
    }

    public static string RemoveAfterX(this string str, string x, out string removed, bool includeX = false, StringComparison compare = StringComparison.OrdinalIgnoreCase)
    {
        if (str.IsNullOrBlank() || x == null)
        {
            removed = "";
            return str;
        }

        int num = str.IndexOf(x, compare);

        if (!includeX && num >= 0)
        {
            num += x.Length;
        }

        if (num >= 0)
        {
            removed = str.Substring(num);
            return str.Substring(0, num);
        }
        removed = "";
        return str;
    }

    public static string RemoveBeforeX(this string str, string x, out string removed, bool includeX = false, StringComparison compare = StringComparison.OrdinalIgnoreCase)
    {
        if (str.IsNullOrBlank() || x == null)
        {
            removed = "";
            return str;
        }

        int num = str.IndexOf(x, compare);

        if (num < 0)
        {
            removed = "";
            return str;
        }

        if (includeX)
        {
            num += x.Length;
        }

        if (num >= 0)
        {
            removed = str.Substring(0, num);
            return str.Substring(num);
        }

        removed = "";
        return str;
    }

    /// <summary>
    /// Removes the string between the first instance of <paramref name="start"/> and the first
    /// instance of <paramref name="end"/>. if the index of <paramref name="end"/> is &gt; the index
    /// of <paramref name="start"/>. Optionally <paramref name="start"/> and <paramref name="end"/>
    /// can be included in <paramref name="removed"/>
    /// </summary>
    /// <param name="str">The string to search</param>
    /// <param name="start">The string to start the removal</param>
    /// <param name="end">The string to end the removal</param>
    /// <param name="removed">What was removed.</param>
    /// <param name="includeStart">If true will include <paramref name="start"/> value.</param>
    /// <param name="includeEnd">If true will include <paramref name="end"/> value.</param>
    /// <param name="compare"></param>
    /// <returns></returns>
    public static string RemoveBetween(this string str, string start, string end, out string removed, bool includeStart = false, bool includeEnd = false, StringComparison compare = StringComparison.OrdinalIgnoreCase)
    {
        if (str.IsNullOrBlank() || start == null || end == null)
        {
            removed = "";
            return str;
        }

        int indexStart = str.IndexOf(start, compare);

        if (indexStart < 0)
        {
            removed = "";
            return str;
        }

        if (!includeStart && indexStart >= 0)
        {
            indexStart += start.Length;
        }

        int indexEnd = str.IndexOf(end, indexStart + 1, compare);

        if (indexEnd < 0)
        {
            removed = "";
            return str;
        }

        if (includeEnd && indexEnd >= 0)
        {
            indexEnd += end.Length;
        }

        if (indexStart >= 0 && indexStart < indexEnd)
        {
            removed = str.Substring(indexStart, indexEnd - indexStart);
            return str.Substring(0, indexStart) + str.Substring(indexEnd);
        }
        else
        {
            removed = "";
            return str;
        }
    }

    public static string RemoveDomain(this string name) => name?.Split('\\').Last();

    public static string Repeat(this string val, int count)
    {
        var sr = new System.Text.StringBuilder();
        return sr.Insert(0, val, count).ToString();
    }

    public static string ReportDate(this DateTime? date, string format = "d")
    {
        if (date.HasValue)
        {
            if (format != null)
            {
                return date.Value.ToShortDateString();
            }
            else
            {
                return date.Value.ToString(format);
            }
        }
        else
        {
            return "";
        }
    }

    public static string Right(this string tempStr, int v)
    {
        if (tempStr == null)
            return tempStr;
        return tempStr.After(tempStr.Length - v);
    }

    public static void SetDictionaryEntry<T, U>(this Dictionary<T, U> dic, T key, U value)
    {
        if (dic.ContainsKey(key))
            dic[key] = value;
        else
            dic.Add(key, value);
    }

    public static DateTime SqlBeginDate(this DateTime? val)
    {
        if (val.HasValue)
        {
            if (val.Value < new DateTime(1753, 1, 1))
            {
                return new DateTime(1753, 1, 1);
            }
            else
            {
                return new DateTime(val.Value.Year, val.Value.Month, val.Value.Day);
            }
        }
        else
        {
            return new DateTime(1753, 1, 1);
        }
    }

    public static DateTime SqlBeginDate(this DateTime val)
    {
        if (val < new DateTime(1753, 1, 1))
        {
            return new DateTime(1753, 1, 1);
        }
        else
        {
            return new DateTime(val.Year, val.Month, val.Day);
        }
    }

    public static DateTime SqlEndDate(this DateTime? val)
    {
        if (val.HasValue)
        {
            return new DateTime(val.Value.Year, val.Value.Month, val.Value.Day, 23, 59, 59, 996);
        }
        else
        {
            return DateTime.MaxValue;
        }
    }

    public static DateTime SqlEndDate(this DateTime val)
    {
        return new DateTime(val.Year, val.Month, val.Day, 23, 59, 59, 996);
    }

    public static List<T> SubRange<T>(this IEnumerable<T> val, int startIndex, int length)
    {
        var results = new List<T>();
        for (int i = startIndex; i <= startIndex + length - 1; i++)
        {
            if (i > val.Count() - 1)
            {
                return results;
            }
            else
            {
                results.Add(val.ElementAt(i));
            }
        }
        return results;
    }

    public static List<T> SubRange<T>(this IEnumerable<T> val, int startIndex)
    {
        List<T> lst = new List<T>();
        for (int i = startIndex; i <= val.Count() - 1; i++)
        {
            if (i > val.Count() - 1)
            {
                return lst;
            }
            else
            {
                lst.Add(val.ElementAt(i));
            }
        }
        return lst;
    }

    public static DateTime Time(this DateTime val)
    {
        return new DateTime(DateTime.MinValue.Year, DateTime.MinValue.Month, DateTime.MinValue.Day, val.Hour, val.Minute, val.Second, val.Millisecond);
    }

    public static DateTime ToDate(this string str, bool errorIsMin = true)
    {
        if (DateTime.TryParse(str, out DateTime d))
        {
            return d;
        }
        else
        {
            if (errorIsMin)
            {
                return DateTime.MinValue;
            }
            else
            {
                return DateTime.MaxValue;
            }
        }
    }

    public static int? ToInt(this string val)
    {
        if (int.TryParse(val, out int i))
        {
            return i;
        }
        else
        {
            return null;
        }
    }

    public static string ToQueryString(this object request)
    {
        if (request == null)
            throw new ArgumentNullException("request");
        // Get all properties on the object
        var properties = request.GetType().BindablePropertyInfo()
            .Where(x => x.GetValue(request, null) != null)
            .ToDictionary(x => x.Name, x => x.GetValue(request, null));
        // Get names for all IEnumerable properties (excl. string)
        var listPropertyNames = properties
            .Where(x => !(x.Value is string) && x.Value is IEnumerable)
            .Select(x => x.Key)
            .ToList();

        // Concat all key/value pairs into a string separated by ampersand
        var query = string.Join("&", properties.Where(x => !listPropertyNames.Contains(x.Key))
            .Select(x => string.Concat(x.Key, "=", Uri.EscapeDataString(x.Value.ToString()))));

        var listQueries = "";
        foreach (var propName in listPropertyNames)
        {
            var valueType = properties[propName].GetType();
            var valueElemType = valueType.IsGenericType
                                    ? valueType.GetGenericArguments()[0]
                                    : valueType.GetElementType();

            if (properties[propName] != null)
            {
                foreach (var value in properties[propName] as IEnumerable)
                {
                    if (value != null)
                    {
                        listQueries += "&" + propName + "=" + Uri.EscapeDataString(value.ToString());
                    }
                }
            }
        }

        if (listQueries.IsNotNullOrBlank())
        {
            query = query + listQueries;
        }

        return query;
    }

    public static List<string> ToStringList(this string val)
    {
        List<string> lst = new List<string>();
        foreach (char c in val.ToCharArray())
            lst.Add(Convert.ToString(c));

        return lst;
    }

    public static string ToYesNo(this bool value)
    {
        return value ? "Yes" : "No";
    }

    public static DateTime TrimTicks(this DateTime aDate)
    {
        return new DateTime(aDate.Year, aDate.Month, aDate.Day, aDate.Hour, aDate.Minute, aDate.Second, aDate.Millisecond);
    }

    public static string TrueFalseNull(this bool? value, string trueVal, string falseVal, string nullText = "")
    {
        if (value.HasValue)
        {
            return value.Value ? trueVal : falseVal;
        }
        else
        {
            return nullText;
        }
    }

    public static DateTime Truncate(this DateTime date, long resolution)
    {
        return new DateTime(date.Ticks - date.Ticks % resolution, date.Kind);
    }

    public static IEnumerable<T> Values<T>(this IEnumerable<T> val)
    {
        if (val == null)
            return new List<T>();
        else
            return val;
    }

    public static int WeekDays(this DateTime start, DateTime end, IEnumerable<DateTime> Holidays)
    {
        int multiplier = 1;
        DateTime sDay;
        DateTime eDay;
        if (start.Date >= end.Date)
        {
            multiplier = -1;

            sDay = end.Date;
            eDay = start.Date;
        }
        else
        {
            sDay = start.Date;
            eDay = end.Date;
        }

        int count = 0;
        while (sDay < eDay)
        {
            if (sDay.DayOfWeek < DayOfWeek.Saturday && sDay.DayOfWeek > DayOfWeek.Sunday && !Holidays.Contains(sDay))
            {
                count += 1;
            }
            sDay = sDay.AddDays(1d);
        }

        return count * multiplier;
    }

    public static Dictionary<DayOfWeek, DateTime> WeekForDate(this DateTime val, DayOfWeek firstDayOfWeek = DayOfWeek.Monday)
    {
        Dictionary<DayOfWeek, DateTime> lst = new Dictionary<DayOfWeek, DateTime>();
        if (val.DayOfWeek == firstDayOfWeek)
        {
            for (int i = 0; i <= 6; i++)
            {
                lst.Add(val.AddDays(i).DayOfWeek, val.AddDays(i).Date);
            }
        }
        else
        {
            DateTime tempDate = val.PreviousDayOfWeek(firstDayOfWeek);
            for (int i = 0; i <= 6; i++)
            {
                lst.Add(tempDate.AddDays(i).DayOfWeek, tempDate.AddDays(i).Date);
            }
        }
        return lst;
    }

    public static IEnumerable<DateTime> WorkDays(this DateTime start, int numberOfDays, IEnumerable<DateTime> Holidays)
    {
        HashSet<DateTime> weekDays = new HashSet<DateTime>();

        DateTime sDay = start.Date;

        while (weekDays.Count < numberOfDays)
        {
            if (sDay.DayOfWeek != DayOfWeek.Sunday && sDay.DayOfWeek != DayOfWeek.Saturday && !Holidays.Contains(sDay))
            {
                weekDays.Add(sDay);
            }
            sDay = sDay.AddDays(1);
        }

        return weekDays;
    }
}