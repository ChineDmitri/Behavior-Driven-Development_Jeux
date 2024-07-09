namespace JeuxTennisApi
{
    public interface IJeuxTennisApi
    {
        // Create a new game
        public void NouveauJeu(string joueur1Nom, string joueur2Nom);

        // Serve the ball (start a new point)
        void Service();

        // Player 1 wins a point
        void Joueur1GagnePoint();

        // Player 2 wins a point
        void Joueur2GagnePoint();

        // Get the current score
        IScoreTennis GetScoreActuel();

        // Get the winner of the game (if the game is over)
        string GetVainqueur();
    }
}