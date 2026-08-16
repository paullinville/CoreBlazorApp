namespace Midland.Core.Common;

public class SortOrderField : SortOrder
{
    public SortOrderField()
    { }

    public SortOrderField(string field)
    {
        Field = field;
    }

    public SortOrderField(string field, bool ascending)
    {
        Field = field;
        Asc = ascending;
    }

    public string Field { get; set; }

    public string SortDirection()
    {
        var Desc = (Asc ?? true) ? "ASC" : "DESC";
        return $"{Field} {Desc}";
    }
}