using JeuxTennisApi;
using Xunit;

namespace SpecFlowJeuxTennisApi;

[Binding]
public class ScoreTennisStepDifinitions
{
    private ScoreTennis _scoreTennis;

    [Given("le score initial du joueur (.*) est (.*)")]
    public void GivenLeScoreInitialDuJoueur1Est(int joueur, int scoreInitial)
    {
        _scoreTennis = new ScoreTennis();
        if (joueur == 1)
            _scoreTennis.Joueur1Score = scoreInitial;
        else if (joueur == 2)
            _scoreTennis.Joueur2Score = scoreInitial;
        else
            Assert.True(false, "Joueur invalide");
    }

    [When("le joueur (.*) marque un point")]
    public void WhenLeJoueur1MarqueUnPoint(int idJoueur)
    {
        if (idJoueur > 0 && idJoueur < 3)
            _scoreTennis.IncrementerJoueurScoreById(idJoueur);
        else if (idJoueur == 2)
            _scoreTennis.IncrementerJoueur2Score();
        else
            Assert.True(false, "Joueur invalide");
    }

    [Then("le score du joueur (.*) devrait être (.*)")]
    public void ThenLeScoreDuJoueur1DevraitEtre(int joueur, int scoreFinal)
    {
        if (joueur == 1)
            Assert.Equal(scoreFinal, _scoreTennis.Joueur1Score);
        else if (joueur == 2)
            Assert.Equal(scoreFinal, _scoreTennis.Joueur2Score);
        else
            Assert.True(false, "Joueur invalide");
    }
}