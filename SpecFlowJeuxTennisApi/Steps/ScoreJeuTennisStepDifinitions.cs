using JeuxTennisApi;
using Xunit;

namespace SpecFlowJeuxTennisApi;

[Binding]
public class ScoreJeuTennisStepDifinitions
{
    public JeuTennis _jeuTennis;
    public Joueur _joueur1 = new Joueur(1, "Djokovic", "Novak");
    public Joueur _joueur2 = new Joueur(2, "Nadal", "Rafael");

    [Given(@"le score initial du joueur (.*) est de (.*)")]
    public void GivenLeScoreInitialDuJoueurEst(int idJoueur, int scoreInitial)
    {
        _jeuTennis = new JeuTennis(new Joueur[] { _joueur1, _joueur2 });

        Joueur joueur = _jeuTennis.GetJoueurById(idJoueur);
        int indexScoreJeu = Array.IndexOf(Jeu.POINTS, scoreInitial);
        int scoreUnderTest = 0;
        for (int i = 0; i < indexScoreJeu; i++)
        {
            scoreUnderTest = _jeuTennis.GagnerPointJeu(idJoueur);
        }

        Assert.Equal(scoreInitial, joueur.GetJeuScore());
        Assert.Equal(scoreInitial, scoreUnderTest);
    }

    [Given(@"les scores initial des joueurs (.*) et (.*) est de (.*)")]
    public void GivenLeScoreInitialDuJoueurEst(int idJoueur1, int idJoueur2, int scoreInitial)
    {
        _jeuTennis = new JeuTennis(new Joueur[] { _joueur1, _joueur2 });

        Joueur j1 = _jeuTennis
            .getSetActuel()
            .Jeux
            .Last()
            .getJoueurById(idJoueur1);
        Joueur j2 = _jeuTennis
            .getSetActuel()
            .Jeux.Last().
            getJoueurById(idJoueur2);
        j1.setMaxJeuScore();
        j2.setMaxJeuScore();

        Assert.Equal(scoreInitial, j1.GetJeuScore());
        Assert.Equal(scoreInitial, j2.GetJeuScore());
    }

    [When(@"le joueur (.*) marque un point")]
    public void WhenLeJoueurMarqueUnPoint(int idJoueur)
    {
        _jeuTennis.GagnerPointJeu(idJoueur);
    }

    [Then(@"le score du joueur (.*) devrait être de (.*)")]
    public void ThenLeScoreDuJoueurDevraitEtre(int idJoueur, int scoreAttendu)
    {
        Joueur joueur = _jeuTennis.GetJoueurById(idJoueur);

        Assert.Equal(scoreAttendu, joueur.GetJeuScore());
    }

    [Then(@"le joueur (.*) gagne le jeu")]
    public void ThenLeJoueurGagneLeJeu(int joueurId)
    {
        Joueur joueur = _jeuTennis.GetJoueurById(joueurId);
        Joueur jouerExpected = _jeuTennis
            .getSetActuel()
            .Jeux[_jeuTennis.getSetActuel().Jeux.Count - 2]
            .GetVainqueur();

        Assert.Equal(jouerExpected, joueur);
    }

    [
        When(@"le joueur (.*) a l'avantage"),
        Then(@"le joueur (.*) a l'avantage")
    ]
    public void ThenLeJoueurALavantage(int idJoueur)
    {
        Joueur joueur = _jeuTennis.GetJoueurById(idJoueur);
        Assert.True(_jeuTennis.getSetActuel().Jeux.Last().Avantage.Avantager == joueur);
    }

    [Then(@"le jeux est en égalité et jeurs n'ont pas l'avantage")]
    public void ThenLeJeuxEstEnEgalite()
    {
        Assert.Equal(_jeuTennis.getSetActuel().Jeux.Last().Avantage.EstEgalite, true);
        Assert.Equal(_jeuTennis.getSetActuel().Jeux.Last().Avantage.Avantager, null);
    }
}