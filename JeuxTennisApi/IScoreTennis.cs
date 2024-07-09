namespace JeuxTennisApi
{
    public interface IScoreTennis
    {
        int Joueur1Score { get; }
        int Joueur2Score { get; }
        int SetActuel { get; }
        int JeuActuel { get; }

        void IncrementerJoueur1Score();
        void IncrementerJoueur2Score();
    }
}