using JeuxTennisApi;
using Xunit;

namespace SpecFlowJeuxTennisApi;

[Binding]
public class ScoreJeuTennisStepDifinitions
{

    [Given(@"le score initial du joueur (.*) est de (.*)")]
    public void GivenLeScoreInitialDuJoueurEst(int idJoueur, int scoreInitial)
    {
        ScenarioContext.StepIsPending();
    }

    [When(@"le joueur (.*) marque un point")]
    public void WhenLeJoueurMarqueUnPoint(int idJoueur)
    {
        ScenarioContext.StepIsPending();
    }

    [Then(@"le score du joueur (.*) devrait être de (.*)")]
    
    public void ThenLeScoreDuJoueurDevraitEtre(int idJoueur, int scoreAttendu)
    {
        ScenarioContext.StepIsPending();
    }
    [Then(@"le joueur (.*) gagne le jeu")]
    public void ThenLeJoueurGagneLeJeu(int p0)
    {
        ScenarioContext.StepIsPending();
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