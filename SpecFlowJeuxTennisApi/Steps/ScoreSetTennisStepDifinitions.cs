using JeuxTennisApi;
using Xunit;

namespace SpecFlowJeuxTennisApi;

[Binding]
public class ScoreSetTennisStepDifinitions
{
    ScoreJeuTennisStepDifinitions superTest = new ScoreJeuTennisStepDifinitions();
    // JeuTennis _jeuTennis;
    // Joueur _joueur1 = new Joueur(1, "Djokovic", "Novak");
    // Joueur _joueur2 = new Joueur(2, "Nadal", "Rafael");

    [Given(@"Scone initial du set pour Joueur (.*) est (.*) et Joueur (.*) est (.*)")]
    public void GivenSconeInitialDeSetPourJoueurEstEtJoueurEst(
        int idJoueur1,
        int scoreJeuJ1,
        int idJoueur2,
        int scoreJeuJ2)
    {
        Joueur[] joueurs = new Joueur[] { superTest._joueur1, superTest._joueur2 };
        if (superTest._jeuTennis == null)
        {
            superTest._jeuTennis = new JeuTennis(joueurs);
        }

        // Set set = new Set();
        // set.Jeux.Add(base._jeuTennis.getSetActuel().Jeux.Last());
        superTest._jeuTennis.getSetActuel().Jeux.Last().SetVainqueur(superTest._joueur1);
        for (int i = 1; i < scoreJeuJ1; i++)
        {
            Jeu j1 = new Jeu(joueurs);
            j1.SetVainqueur(superTest._joueur1);
            superTest._jeuTennis.getSetActuel().Jeux.Add(j1);
        }

        for (int i = 0; i < scoreJeuJ2; i++)
        {
            Jeu j2 = new Jeu(joueurs);
            j2.SetVainqueur(superTest._joueur2);
            superTest._jeuTennis.getSetActuel().Jeux.Add(j2);
        }

        superTest._jeuTennis.getSetActuel().Jeux.Add(new Jeu(joueurs));
        // base._jeuTennis.Sets.Add(set);

        Assert.Equal(superTest._jeuTennis.getSetActuel().Jeux.Count, scoreJeuJ1 + scoreJeuJ2 + 1);
    }

    [Then(@"le set a gagné le joueur (.*)")]
    public void ThenLeSetAGagneLeJoueur(int idJoueur1)
    {
        Joueur joueur = superTest._jeuTennis.GetJoueurById(idJoueur1);
        int indexSetAcuel = superTest._jeuTennis.Sets.IndexOf(superTest._jeuTennis.getSetActuel());
        Assert.Equal(superTest._jeuTennis.Sets[indexSetAcuel - 1].Vainqueur, joueur);
    }

    [Given(@"dans un set le score du jeu initial du joueur (.*) est de (.*)")]
    public void GivenDansUnSetLeScoreInitialDuJoueurEstDe(int idJoueur, int scoreInitial)
    {
        Joueur joueur = superTest._jeuTennis.GetJoueurById(idJoueur);
        int indexScoreJeu = Array.IndexOf(Jeu.POINTS, scoreInitial);
        int scoreUnderTest = 0;
        for (int i = 0; i < indexScoreJeu; i++)
        {
            scoreUnderTest = superTest._jeuTennis.GagnerPointJeu(idJoueur);
        }

        Assert.Equal(scoreInitial, joueur.GetJeuScore());
        Assert.Equal(scoreInitial, scoreUnderTest);
    }

    [When(@"dans un set le joueur (.*) marque un point")]
    public void WhenDansUnSetLeJoueurMarqueUnPoint(int idJoueur)
    {
        superTest.WhenLeJoueurMarqueUnPoint(idJoueur);
    }

    [
        Then(@"le set est en tie break"),
        Given(@"le set est en tie break")
    ]
    public void ThenLeSetEstEnTieBreak()
    {
        Assert.True(superTest._jeuTennis.getSetActuel().TieBreak.estTieBreak);
    }

    [Then(@"le score de jouer (.*) en tie break est (.*)")]
    public void ThenLeScoreDeJouerEnTieBreakEst(int idJoueur, int tieBreakScore)
    {
        Assert.Equal(superTest._jeuTennis.getSetActuel().Jeux.Last().getJoueurById(idJoueur).scoreTieBreak,
            tieBreakScore);
    }

    [When(@"dans un set le joueur (.*) marque (.*) points")]
    public void WhenDansUnSetLeJoueurMarquePoints(int idJoueur, int countPoints)
    {
        for (int i = 0; i < countPoints; i++)
        {
            superTest.WhenLeJoueurMarqueUnPoint(idJoueur);
        }
    }

    [Then(@"le vanqueur du match est le joueur (.*)")]
    public void ThenLeVanqueurDuMatchEstLeJoueur(int idJoueur)
    {
        Assert.NotNull(superTest._jeuTennis.vainqueurMatch);
        Assert.Equal(superTest._jeuTennis.vainqueurMatch, superTest._jeuTennis.GetJoueurById(idJoueur));
    }

}