using System;

namespace JeuxTennisApi
{
    public class Joueur
    {
        private int[] points = { 0, 15, 30, 40 };
        private int _scoreIndex;
        public string Nom { get; private set; }
        public string Prenom { get; private set; }

        public Joueur(string nom, string prenom)
        {
            Nom = nom;
            Prenom = prenom;
            _scoreIndex = 0;
        }

        public int Score
        {
            get { return points[_scoreIndex]; }
        }

        public void IncrementerScore()
        {
            if (_scoreIndex < points.Length - 1)
            {
                _scoreIndex++;
            }
            else if (_scoreIndex == points.Length - 1)
            {
                // Supposons qu'un joueur gagne la partie après avoir atteint 40 points et marqué encore un point.
                _scoreIndex = 0; // Réinitialiser le score après avoir gagné une partie.
            }
        }
    }
}