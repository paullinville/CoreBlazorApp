using Midland.Core.Validation.Exceptions;

namespace Midland.Core.Common;

public class ExceptionDetails : List<Detail>
{
    public ExceptionDetails()
    { }

    public ExceptionDetails(Exception ex)
    {
        AddDetail(ex?.InnerException);
    }

    public List<Detail> Diffs(ExceptionDetails other)
    {
        var diffs = new List<Detail>();

        return diffs;
    }

    private void AddDetail(Exception ex)
    {
        if (ex != null)
        {
            Add(new Detail(ex));
            AddDetail(ex.InnerException);
        }
    }
}