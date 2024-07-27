using MastermindApi;
using Xunit;

namespace SpecFlowMastermindApi;

[Binding]
public class MastermindStepDifinitions
{
    private Mastermind game;
    private string secretCode;
    private (int ExactMatches, int ColorMatches) guessResult;
    private Exception thrownException;

    [Given(@"le jeu est configuré avec une longueur de code de (.*) et (.*) couleurs")]
    public void GivenLeJeuEstConfigureAvecUneLongueurDeCodeDeEtCouleurs(int length, int colors)
    {
        game = new Mastermind(length, colors);
    }


    [When(@"le code est généré")]
    public void WhenLeCodeEstGenere()
    {
        game.GenerateCode();
        secretCode = game.secretCode;
    }

    [Then(@"le code devrait avoir (.*) chiffres")]
    public void ThenLeCodeDevraitAvoirChiffres(int length)
    {
        Assert.Equal(length, secretCode.Length);
    }

    [Then(@"chaque chiffre devrait être entre (.*) et (.*)")]
    public void ThenChaqueChiffreDevraitEtreEntreEt(int min, int max)
    {
        foreach (char digit in secretCode)
        {
            int value = digit - '0';
            Assert.True(value >= min && value <= max);
        }
    }

    [When(@"je définis le code ""(.*)""")]
    public void WhenJeDefinisLeCode(string code)
    {
        try
        {
            game.SetCode(code);
            secretCode = code;
        }
        catch (Exception ex)
        {
            ScenarioContext.Current.Add("Exception", ex);
        }
    }

    [Then(@"le code secret devrait être ""(.*)""")]
    public void ThenLeCodeSecretDevraitEtre(string expectedCode)
    {
        string actualCode = game.secretCode;
        Assert.Equal(expectedCode, actualCode);
    }

    [When(@"j'essaie de définir le code ""(.*)""")]
    public void WhenJessaieDeDefinirLeCode(string code)
    {
        try
        {
            game.SetCode(code);
            secretCode = code;
        }
        catch (Exception ex)
        {
            thrownException = ex;
        }
    }

    [Then(@"cela devrait lancer une ArgumentException")]
    public void ThenCelaDevraitLancerUneArgumentException()
    {
        Assert.NotNull(thrownException);
        Assert.IsType<ArgumentException>(thrownException);
    }

    [Given(@"le code secret est ""(.*)""")]
    public void GivenLeCodeSecretEst(string code)
    {
        game.SetCode(code);
        secretCode = code;
    }

    [When(@"je devine ""(.*)""")]
    public void WhenJeDevine(string guess)
    {
        guessResult = game.CheckGuess(guess);
    }

    [Then(@"le résultat devrait être (.*) correspondances exactes et (.*) correspondance de couleur")]
    public void ThenLeResultatDevraitEtreCorrespondancesExactesEtCorrespondanceDeCouleur(int exactMatches, int colorMatches)
    {
        Assert.Equal(exactMatches, guessResult.ExactMatches);
        Assert.Equal(colorMatches, guessResult.ColorMatches);
    }

    [Then(@"le résultat devrait être (.*) correspondances exactes et (.*) correspondances de couleur")]
    public void ThenLeResultatDevraitEtreCorrespondancesExactesEtCorrespondancesDeCouleur(int exactMatches, int colorMatches)
    {
        Assert.Equal(exactMatches, guessResult.ExactMatches);
        Assert.Equal(colorMatches, guessResult.ColorMatches);
    }
}