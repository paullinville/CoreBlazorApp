using BlazorApp.Common;
using Microsoft.AspNetCore.Components;

namespace BlazorApp.Pages
{
    public partial class Home
    {
        [Inject]
        public ClientSettings Settings { get; set; } = default!;

        private string PageTitleText => FormatPageTitle("Home");

        private string FormatPageTitle(string pageTitle) => string.IsNullOrWhiteSpace(Settings.ApplicationName)
            ? pageTitle
            : $"{Settings.ApplicationName} - {pageTitle}";
    }
}
