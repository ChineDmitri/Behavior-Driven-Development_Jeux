using JeuxTennisApi;
using Xunit;

namespace SpecFlowJeuxTennisApi;


[Binding]
public class ScoreTennisStepDifinitions
{
    private ScoreTennis _scoreTennis;
    
    [Given("le score initial du joueur 1 est (.*)")]
    public void GivenLeScoreInitialDuJoueur1Est(int scoreInitial)
    {
        _scoreTennis = new ScoreTennis();
        _scoreTennis.Joueur1Score = scoreInitial;
    }

    [When("le joueur 1 marque un point")]
    public void WhenLeJoueur1MarqueUnPoint()
    {
        _scoreTennis.IncrementerJoueur1Score();
    }

    [Then("le score du joueur 1 devrait être (.*)")]
    public void ThenLeScoreDuJoueur1DevraitEtre(int scoreFinal)
    {
        Assert.Equal(scoreFinal, _scoreTennis.Joueur1Score);
    }
}