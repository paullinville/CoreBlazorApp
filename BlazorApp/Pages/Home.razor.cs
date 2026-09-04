using BlazorApp.Classes;
using Microsoft.AspNetCore.Components;

namespace BlazorApp.Pages
{
    public partial class Home
    {
        [Inject]
        public ClientSettings Settings { get; set; } = default!;


    }
}
