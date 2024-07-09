using System;

namespace JeuxTennisApi
{
    public class JeuTennisApi : IJeuTennisApi
    {
        private string joueur1Nom;
        private string joueur2Nom;
        private int joueur1Sets;
        private int joueur2Sets;
        private int joueur1Jeux;
        private int joueur2Jeux;
        private int joueur1Points;
        private int joueur2Points;
        private bool jeuEnCours;

        public JeuTennisApi()
        {
            joueur1Sets = 0;
            joueur2Sets = 0;
            joueur1Jeux = 0;
            joueur2Jeux = 0;
            joueur1Points = 0;
            joueur2Points = 0;
            jeuEnCours = false;
        }

        public void NouveauJeu(string joueur1Nom, string joueur2Nom)
        {
            this.joueur1Nom = joueur1Nom;
            this.joueur2Nom = joueur2Nom;
            jeuEnCours = true;
        }

        public void Service()
        {
            if (!jeuEnCours)
            {
                throw new InvalidOperationException("Jeu n'est pas en cours");
            }

            // Début d'un nouveau point
            joueur1Points = 0;
            joueur2Points = 0;
        }

        public void Joueur1GagnePoint()
        {
            if (!jeuEnCours)
            {
                throw new InvalidOperationException("Jeu n'est pas en cours");
            }

            joueur1Points++;
            VerifierVictoireJeu();
        }

        public void Joueur2GagnePoint()
        {
            if (!jeuEnCours)
            {
                throw new InvalidOperationException("Jeu n'est pas en cours");
            }

            joueur2Points++;
            VerifierVictoireJeu();
        }

        private void VerifierVictoireJeu()
        {
            if (joueur1Points >= 4 && joueur1Points - joueur2Points >= 2)
            {
                joueur1Jeux++;
                joueur1Points = 0;
                joueur2Points = 0;
                VerifierVictoireSet();
            }
            else if (joueur2Points >= 4 && joueur2Points - joueur1Points >= 2)
            {
                joueur2Jeux++;
                joueur1Points = 0;
                joueur2Points = 0;
                VerifierVictoireSet();
            }
        }

        private void VerifierVictoireSet()
        {
            if (joueur1Jeux >= 6 && joueur1Jeux - joueur2Jeux >= 2)
            {
                joueur1Sets++;
                joueur1Jeux = 0;
                joueur2Jeux = 0;
                VerifierFinJeu();
            }
            else if (joueur2Jeux >= 6 && joueur2Jeux - joueur1Jeux >= 2)
            {
                joueur2Sets++;
                joueur1Jeux = 0;
                joueur2Jeux = 0;
                VerifierFinJeu();
            }
        }

        private void VerifierFinJeu()
        {
            if (joueur1Sets >= 2)
            {
                jeuEnCours = false;
            }
            else if (joueur2Sets >= 2)
            {
                jeuEnCours = false;
            }
        }

        public ScoreTennis GetScoreActuel()
        {
            return new ScoreTennis
            {
                Joueur1Sets = joueur1Sets,
                Joueur2Sets = joueur2Sets,
                Joueur1Jeux = joueur1Jeux,
                Joueur2Jeux = joueur2Jeux,
                Joueur1Points = joueur1Points,
                Joueur2Points = joueur2Points
            };
        }

        public string GetVainqueur()
        {
            if (joueur1Sets >= 2)
            {
                return joueur1Nom;
            }
            else if (joueur2Sets >= 2)
            {
                return joueur2Nom;
            }
            else
            {
                return null;
            }
        }
    }

    public class ScoreTennis
    {
        public int Joueur1Sets { get; set; }
        public int Joueur2Sets { get; set; }
        public int Joueur1Jeux { get; set; }
        public int Joueur2Jeux { get; set; }
        public int Joueur1Points { get; set; }
        public int Joueur2Points { get; set; }
    }
}