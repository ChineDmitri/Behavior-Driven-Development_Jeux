using System;

namespace JeuxTennisApi
{
    public class JeuxTennisApi : IJeuxTennisApi
    {
        private string _joueur1Nom;
        private string _joueur2Nom;
        private int _joueur1Sets;
        private int _joueur2Sets;
        private int _joueur1Jeux;
        private int _joueur2Jeux;
        private int _joueur1Points;
        private int _joueur2Points;
        private bool _jeuEnCours;

        public JeuxTennisApi()
        {
            _joueur1Sets = 0;
            _joueur2Sets = 0;
            _joueur1Jeux = 0;
            _joueur2Jeux = 0;
            _joueur1Points = 0;
            _joueur2Points = 0;
            _jeuEnCours = false;
        }

        public void NouveauJeu(string joueur1Nom, string joueur2Nom)
        {
            _joueur1Nom = joueur1Nom;
            _joueur2Nom = joueur2Nom;
            _jeuEnCours = true;
        }

        public void Service()
        {
            if (!_jeuEnCours)
            {
                throw new InvalidOperationException("Jeu n'est pas en cours");
            }

            // Début d'un nouveau point
            _joueur1Points = 0;
            _joueur2Points = 0;
        }

        public void Joueur1GagnePoint()
        {
            if (!_jeuEnCours)
            {
                throw new InvalidOperationException("Jeu n'est pas en cours");
            }

            _joueur1Points++;
            VerifierVictoireJeu();
        }

        public void Joueur2GagnePoint()
        {
            if (!_jeuEnCours)
            {
                throw new InvalidOperationException("Jeu n'est pas en cours");
            }

            _joueur2Points++;
            VerifierVictoireJeu();
        }

        private void VerifierVictoireJeu()
        {
            if (_joueur1Points >= 4 && _joueur1Points - _joueur2Points >= 2)
            {
                _joueur1Jeux++;
                _joueur1Points = 0;
                _joueur2Points = 0;
                VerifierVictoireSet();
            }
            else if (_joueur2Points >= 4 && _joueur2Points - _joueur1Points >= 2)
            {
                _joueur2Jeux++;
                _joueur1Points = 0;
                _joueur2Points = 0;
                VerifierVictoireSet();
            }
        }

        private void VerifierVictoireSet()
        {
            if (_joueur1Jeux >= 6 && _joueur1Jeux - _joueur2Jeux >= 2)
            {
                _joueur1Sets++;
                _joueur1Jeux = 0;
                _joueur2Jeux = 0;
                VerifierFinJeu();
            }
            else if (_joueur2Jeux >= 6 && _joueur2Jeux - _joueur1Jeux >= 2)
            {
                _joueur2Sets++;
                _joueur1Jeux = 0;
                _joueur2Jeux = 0;
                VerifierFinJeu();
            }
        }

        private void VerifierFinJeu()
        {
            if (_joueur1Sets >= 2)
            {
                _jeuEnCours = false;
            }
            else if (_joueur2Sets >= 2)
            {
                _jeuEnCours = false;
            }
        }

        public IScoreTennis GetScoreActuel()
        {
            return new ScoreTennis
            {
                Joueur1Score = _joueur1Points,
                Joueur2Score = _joueur2Points,
                SetActuel = _joueur1Sets,
                JeuActuel = _joueur1Jeux
            };
        }

        public string GetVainqueur()
        {
            if (_joueur1Sets >= 2)
            {
                return _joueur1Nom;
            }
            else if (_joueur2Sets >= 2)
            {
                return _joueur2Nom;
            }
            else
            {
                return null;
            }
        }
    }
}