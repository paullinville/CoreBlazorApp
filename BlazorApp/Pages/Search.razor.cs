namespace BlazorApp.Pages;

public partial class Search
{
    private string SearchText { get; set; } = string.Empty;

    private string SearchCategory { get; set; } = string.Empty;

    private List<SearchResultItem> GridData { get; } = [];

    private class SearchResultItem
    {
        public string Primary { get; set; } = string.Empty;

        public string Secondary { get; set; } = string.Empty;
    }
}
