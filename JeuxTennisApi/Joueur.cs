using System;

namespace JeuxTennisApi
{
    public class Joueur
    {
        public static int[] points = { 0, 15, 30, 40 };
        public int JeuxScoreIndex;
        public int JeuxGagnes;
        public int SetsGagnes;

        public string Nom;
        public string Prenom;

        public Joueur(string nom, string prenom)
        {
            Nom = nom;
            Prenom = prenom;
            JeuxScoreIndex = 0;
            JeuxGagnes = 0;
            SetsGagnes = 0;
        }

        public int ScoreJeu
        {
            get { return points[JeuxScoreIndex]; }
        }

        public void IncrementerScore()
        {
            if (JeuxScoreIndex < points.Length - 1)
            {
                JeuxScoreIndex++;
            }
            else if (JeuxScoreIndex == points.Length - 1)
            {
                // Supposons qu'un joueur gagne la partie après avoir atteint 40 points et marqué encore un point.
                JeuxScoreIndex = 0; // Réinitialiser le score après avoir gagné une partie.
            }
        }
    }
}