using JeuxTennisApi;
using Xunit;

namespace SpecFlowJeuxTennisApi;

[Binding]
public class ScoreTennisStepDifinitions
{
    private JeuxTennis jeuxTennis;
    private ScoreTennis scoreTennis;

    [Given(@"le score initial du joueur (.*) est de (.*)")]
    public void GivenLeScoreInitialDuJoueur1Est(int idJoueur, int scoreInitial)
    {
        Joueur joueur1 = new Joueur("Federrer", "Roger");
        Joueur joueur2 = new Joueur("Nadal", "Rafael");
        Joueur[] joueurs = { joueur1, joueur2 };

        scoreTennis = new ScoreTennis(joueurs);
        jeuxTennis = new JeuxTennis(scoreTennis);

        jeuxTennis.Score
            .GetJouerParId(idJoueur).JeuxScoreIndex = new List<int>(Joueur.points).IndexOf(scoreInitial);
    }

    [When(@"le joueur (.*) marque un point")]
    public void WhenLeJoueur1MarqueUnPoint(int idJoueur)
    {
        jeuxTennis.Score.IncrementerJoueurScoreJeuParId(idJoueur);
    }

    [Then(@"le score du joueur (.*) devrait être de (.*)")]
    public void ThenLeScoreDuJoueur1DevraitEtre(int idJoueur, int scoreAttendu)
    {
        Assert.Equal(scoreAttendu, jeuxTennis.GetScore().GetJouerParId(idJoueur).ScoreJeu);
    }

    [Then(@"le joueur (.*) gagne le jeu")]
    public void ThenLeJoueurGagneLeJeu(int p0)
    {
        ScenarioContext.StepIsPending();
    }
}