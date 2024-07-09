namespace JeuxTennisApi
{
    public interface IJeuxTennisApi
    {
        // Create a new game
        void CreateGame(string player1Name, string player2Name);

        // Serve the ball (start a new point)
        void Service();

        // Player 1 wins a point
        void Jouer1GagnePoint();

        // Player 2 wins a point
        void Jouer2GagnePoint();

        // Get the current score
        TennisScore GetResult();

        // Get the winner of the game (if the game is over)
        string GetWinner();
    }
}