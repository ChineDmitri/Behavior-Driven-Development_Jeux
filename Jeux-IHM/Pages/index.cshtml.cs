using JeuxTennisApi;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages;

public class index : PageModel
{
    public int Score { get; set; }

    public void OnGet()
    {

    }
}