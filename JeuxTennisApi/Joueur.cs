using System;

namespace JeuxTennisApi
{
    public class Joueur
    {
        public int Id { get; private set; }

        public string Nom { get; private set; }
        public string Prenom { get; private set; }

        public int indexJeuScore { get; private set; } = 0;

        public void setMaxJeuScore()
        {
            this.indexJeuScore = 3;
        }

        public Joueur(int id, string nom, string prenom)
        {
            Id = id;
            Nom = nom;
            Prenom = prenom;
        }

        public void IncrementerJeuScore()
        {
            indexJeuScore++;
        }
        
        public int GetJeuScore()
        {
            return Jeu.POINTS[indexJeuScore];
        }

        public void ResetJeuScore()
        {
            indexJeuScore = 0;
        }
    }
}