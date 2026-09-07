using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace Midland.Core.Authorization;

public class ListCountAttribute : ValidationAttribute
{
    public int Min { get; set; } = 0;
    public int Max { get; set; } = int.MaxValue;

    public override bool IsValid(object? value)
    {
        if (value is null)
        {
            return Min <= 0;
        }

        if (value is IList list)
        {
            return list.Count >= Min && list.Count <= Max;
        }

        if (value is IEnumerable enumerable)
        {
            var count = 0;
            foreach (var _ in enumerable)
            {
                count++;
            }

            return count >= Min && count <= Max;
        }

        return false;
    }
}
