namespace JeuxTennisApi
{
    public interface IScoreTennis
    {
        int JoueurScoreById(int joueurId);
        int SetActuel { get; }
        int JeuActuel { get; }

        void IncrementerJoueurScoreById(int joueurId);
    }
}