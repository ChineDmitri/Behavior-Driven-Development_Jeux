using JeuxTennisApi;
using Newtonsoft.Json;
using WebApplication1;
using WebApplication1.Pages;
using System.Text.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});

var app = builder.Build();

JeuTennis jeuTennis = null;

app.UseCors("AllowAll");

app.MapPost("/api/createMatch", async context =>
{
    // Read the request body
    var requestBody = await new StreamReader(context.Request.Body).ReadToEndAsync();

    // Deserialize the JSON payload into a MatchDto object
    var matchData = JsonSerializer.Deserialize<MatchDto>(requestBody,
        new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

    // Validate the match data
    if (matchData == null || matchData.Player1 == null || matchData.Player2 == null)
    {
        context.Response.StatusCode = 400; // Bad Request
        await context.Response.WriteAsJsonAsync(new { message = "Invalid request body" });
        return;
    }
    
    jeuTennis = new JeuTennis(new[]
    {
        new Joueur(matchData.Player1.Id, matchData.Player1.Firstname, matchData.Player1.Lastname),
        new Joueur(matchData.Player2.Id, matchData.Player2.Firstname, matchData.Player2.Lastname)
    });
    

    // Return a success response
    context.Response.StatusCode = 201; // Created

    var response = new
    {
        j1 = jeuTennis.getSetActuel().Jeux.Last().getJoueurById(1).GetJeuScore(),
        j2 = jeuTennis.getSetActuel().Jeux.Last().getJoueurById(2).GetJeuScore(),
        Joueurs = jeuTennis.getSetActuel().Jeux.Last().getAllJoueurs(),
        Sets = jeuTennis.Sets,
        SetActuel = jeuTennis.getSetActuel(),
        VanqueurMatch = jeuTennis.vainqueurMatch
    };

    await context.Response.WriteAsJsonAsync(response);
});

app.MapGet("/api/winPoint/{idJoueur}", async (HttpContext context, int idJoueur) =>
{
    if (jeuTennis != null)
    {
        jeuTennis.GagnerPointJeu(idJoueur);

        return Results.Json(new
        {
            j1 = jeuTennis.getSetActuel().Jeux.Last().getJoueurById(1).GetJeuScore(),
            j2 = jeuTennis.getSetActuel().Jeux.Last().getJoueurById(2).GetJeuScore(),
            Joueurs = jeuTennis.getSetActuel().Jeux.Last().getAllJoueurs(),
            Sets = jeuTennis.Sets,
            SetActuel = jeuTennis.getSetActuel(),
            VanqueurMatch = jeuTennis.vainqueurMatch
        });
    }

    Results.StatusCode(404);
    return Results.Json(new { message = "Match not created" }, null, "application/json", 400);
});

app.MapGet("/api/getData", async (HttpContext context) =>
{
    if (jeuTennis != null)
    {
        return Results.Json(new
        {
            j1 = jeuTennis.getSetActuel().Jeux.Last().getJoueurById(1).GetJeuScore(),
            j2 = jeuTennis.getSetActuel().Jeux.Last().getJoueurById(2).GetJeuScore(),
            Joueurs = jeuTennis.getSetActuel().Jeux.Last().getAllJoueurs(),
            Sets = jeuTennis.Sets,
            SetActuel = jeuTennis.getSetActuel(),
            VanqueurMatch = jeuTennis.vainqueurMatch
        });
    }

    Results.StatusCode(404);
    return Results.Json(new { message = "Match not created" }, null, "application/json", 400);
});


app.UseRouting();
app.UseStaticFiles();

app.UseEndpoints(endpoints => { endpoints.MapRazorPages(); });

app.Run();
