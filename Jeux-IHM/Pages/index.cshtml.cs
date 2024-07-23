using JeuxTennisApi;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JeuxIHM.Pages;

public class index : PageModel
{
    public int Score { get; set; }

    public void OnGet()
    {

    }
}