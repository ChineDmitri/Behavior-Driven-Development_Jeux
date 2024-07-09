using System;
using System.Collections.Generic;
using System.Linq;

namespace JeuxTennisApi
{
    public class JeuxTennis
    {
        public ScoreTennis Score;

        public JeuxTennis(ScoreTennis initScore)
        {
            Score = initScore;
        }

        // Service pour ajouter un point à un joueur
        public void AjouterPoint(Joueur joueur)
        {
            if (Score == null || Score.Joueurs == null)
            {
                throw new Exception("Score : Joueurs is null");
            }

            Score.Joueurs.First(j => j == joueur).IncrementerScore();
            VerifierSiJoueurAGagneUnJeu(joueur);
        }

        // Service pour vérifier si un joueur a gagné un jeu
        private void VerifierSiJoueurAGagneUnJeu(Joueur joueur)
        {
            if (joueur.ScoreJeu == 40)
            {
                // Le joueur a gagné un jeu
                Score.JeuActuel.vainqueur = joueur;
                // VerifierSiJoueurAGagneUnSet(joueur);
            }
        }

        // Service pour vérifier si un joueur a gagné un set
        private void VerifierSiJoueurAGagneUnSet(Joueur joueur)
        {
            if (Score.JeuActuel.vainqueur == joueur && Score.SetActuel.stat.Key == joueur)
            {
                // Le joueur a gagné un set
                Score.SetActuel.stat = new KeyValuePair<Joueur, JeuTennis>(joueur, Score.JeuActuel);
                VerifierSiJoueurAGagneLaPartie(joueur);
            }
        }

        // Service pour vérifier si un joueur a gagné la partie
        private void VerifierSiJoueurAGagneLaPartie(Joueur joueur)
        {
            if (Score.SetActuel.stat.Key == joueur && Score.Sets.Count(s => s.stat.Key == joueur) >= 2)
            {
                // Le joueur a gagné la partie
                // Vous pouvez ici déclencher un événement ou une notification pour signaler la fin de la partie
            }
        }

        // Service pour récupérer le score actuel
        public ScoreTennis GetScore()
        {
            return Score;
        }
    }
}