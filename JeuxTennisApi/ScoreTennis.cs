using System;

namespace JeuxTennisApi
{
    public class ScoreTennis : IScoreTennis
    {
        private Joueur[] _joueurs;
        private int _setActuel;
        private int _jeuActuel;

        public ScoreTennis(Joueur[] joueurs)
        {
            if (joueurs.Length != 2 || joueurs.Length != 4)
            {
                throw new ArgumentException("Il doit y avoir exactement deux ou quatre joueurs.");
            }

            _joueurs = joueurs;

            _setActuel = 0;
            _jeuActuel = 0;
        }

        public int JoueurScoreById(int joueurId)
        {
            if (joueurId < 1 || joueurId > 4)
            {
                throw new ArgumentException("JoueurId invalide.");
            }

            return _joueurs[joueurId - 1].Score;
        }

        public int SetActuel
        {
            get { return _setActuel; }
        }

        public int JeuActuel
        {
            get { return _jeuActuel; }
        }

        public void IncrementerJoueurScoreById(int joueurId)
        {
            if (joueurId < 1 || joueurId > 4)
            {
                throw new ArgumentException("JoueurId invalide.");
            }

            int index = joueurId - 1;
            _joueurs[index].IncrementerScore();

            if (_joueurs[index].Score == 0 && _joueurs[0].Score != _joueurs[1].Score) // Joueur a gagné la partie
            {
                _jeuActuel++;
                // Gérer la logique de set et de match ici
            }
        }
    }
}