using JeuxTennisApi;
using Xunit;

namespace SpecFlowJeuxTennisApi;

[Binding]
public class ScoreJeuTennisStepDifinitions
{
    JeuTennis _jeuTennis;
    // Joueur _joueur1 = new Joueur(1, "Djokovic", "Novak");
    // Joueur _joueur2 = new Joueur(2, "Nadal", "Rafael");

    [Given(@"le score initial du joueur (.*) est de (.*)")]
    public void GivenLeScoreInitialDuJoueurEst(int idJoueur, int scoreInitial)
    {
        Joueur joueurUnderTest = new Joueur(idJoueur, "Nadal", "Rafael");
        Joueur joueurSecond = new Joueur(11, "Djokovic", "Novak");
        _jeuTennis = new JeuTennis(new Joueur[] { joueurUnderTest, joueurSecond });
        
        Joueur joueur = _jeuTennis.GetJoueurById(idJoueur);
        int indexScoreJeu = Array.IndexOf(Jeu.POINTS, scoreInitial);
        for (int i = 0; i < indexScoreJeu; i++)
        {
            _jeuTennis.GagnerPointJeu(idJoueur);
        }

        Assert.Equal(scoreInitial, joueur.GetJeuScore());
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
        Joueur jouerExpected = _jeuTennis.Jeux[_jeuTennis.Jeux.Count - 2].GetVainqueur();
        
        Assert.Equal(jouerExpected, joueur);
        
    }

    [Then(@"le joueur (.*) a l'avantage")]
    public void ThenLeJoueurALavantage(int p0)
    {
        ScenarioContext.StepIsPending();
    }

    [Given(@"le joueur (.*) a l'avantage")]
    public void GivenLeJoueurALavantage(int p0)
    {
        ScenarioContext.StepIsPending();
    }
}