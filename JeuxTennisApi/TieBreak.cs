using System;
using System.Linq;
using Enumerable = System.Linq.Enumerable;

namespace JeuxTennisApi
{
    public class TieBreak : Avantage
    {
        public bool estTieBreak { get; private set; } = false;
        private Joueur[] joueurs;

        public void check(Set set)
        {
            int j1Gagner = set.Jeux.Count(j =>
            {
                try
                {
                    var joueur = j.getJoueurById(1);
                    return joueur != null && j.GetVainqueur() == joueur;
                }
                catch (System.InvalidOperationException)
                {
                    Console.WriteLine("Le jeu n'est pas encore terminé");
                    return false; // Renvoyez false pour exclure ce cas du décompte
                }
            });
            int j2Gagner = set.Jeux.Count(j =>
            {
                try
                {
                    var joueur = j.getJoueurById(2);
                    return joueur != null && j.GetVainqueur() == joueur;
                }
                catch (System.InvalidOperationException)
                {
                    Console.WriteLine("Le jeu n'est pas encore terminé");
                    return false; // Renvoyez false pour exclure ce cas du décompte
                }
            });

            if (j1Gagner == 6 && j2Gagner == 6)
            {
                estTieBreak = true;
                joueurs = set.Jeux.Last().getAllJoueurs();
            }
        }
    }
}