using TicTacToeApi;
using Xunit;

namespace SpecFlowTicTacToeApi.Steps;

[Binding]
public class TicTacToeStepDefinitions
{
    private TicTacToe game;
    private Exception thrownException;

    [Given(@"le jeu est configuré avec un plateau de (.*)")]
    public void GivenLeJeuEstConfigureAvecUnPlateauDe(string size)
    {
        Assert.Equal("3x3", size);
        game = new TicTacToe();
    }

    [Given(@"le jeu est démarré")]
    [When(@"le jeu est démarré")]
    public void WhenLeJeuEstDemarre()
    {
        game = new TicTacToe();
    }

    [Then(@"le plateau devrait être vide")]
    public void ThenLePlateauDevraitEtreVide()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Assert.Equal(Player.None, game.GetPiece(i, j));
            }
        }
    }

    [Then(@"le joueur actuel devrait être \[X]")]
    public void ThenLeJoueurActuelDevraitEtreX()
    {
        Assert.Equal(Player.X, game.CurrentPlayer);
    }

    [When(@"je place un pion X en position \((.*), (.*)\)")]
    // [Given(@"je place un pion X en position \((.*), (.*)\)")]
    public void WhenJePlaceUnPionXEnPosition(int row, int col)
    {
        game.PlacePiece(row - 1, col - 1);
    }

    [Then(@"le plateau devrait contenir un pion X en position \((.*), (.*)\)")]
    public void ThenLePlateauDevraitContenirUnPionXEnPosition(int row, int col)
    {
        Assert.Equal(Player.X, game.GetPiece(row - 1, col - 1));
    }

    [Then(@"le joueur actuel devrait être \[O]")]
    public void ThenLeJoueurActuelDevraitEtreO()
    {
        Assert.Equal(Player.O, game.CurrentPlayer);
    }

    [When(@"j'essaie de placer un pion O en position \((.*), (.*)\)")]
    public void WhenJessaieDePlacerUnPionOEnPosition(int row, int col)
    {
        try
        {
            game.PlacePiece(row - 1, col - 1);
        }
        catch (Exception ex)
        {
            thrownException = ex;
        }
    }

    [Then(@"cela devrait lancer une ArgumentException")]
    public void ThenCelaDevraitLancerUneArgumentException()
    {
        Assert.IsType<ArgumentException>(thrownException);
    }

    [When(@"je vérifie la victoire")]
    public void WhenJeVerifieLaVictoire()
    {
        // Affichage de débogage
        Console.WriteLine("État du plateau avant vérification de la victoire :");
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Console.Write(game.GetPiece(i, j) + " ");
            }
            Console.WriteLine();
        }
        Console.WriteLine("Résultat de CheckWin() : " + game.CheckWin());
    }

    [Then(@"le joueur (.*) devrait gagner")]
    public void ThenLeJoueurXDevraitGagner(string player)
    {
        // Assert.Equal(Player.X, game.CheckWin());
        Assert.Equal(player == "X" ? Player.X : Player.O, game.CheckWin());
    }

    
    [Given(@"je place un pion (.*) en position \((.*), (.*)\)")]
    public void GivenJePlaceUnPionEnPosition(string player, int row, int col)
    {
        game.PlacePiece(row - 1, col - 1);
        Assert.Equal(player == "X" ? Player.O : Player.X, game.CurrentPlayer);
    }

    [Then(@"la partie devrait être égale")]
    public void ThenLaPartieDevraitEtreEgale()
    {
        Assert.Equal(Player.None, game.CheckWin());
    }
}