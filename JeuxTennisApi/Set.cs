using System;
using System.Collections.Generic;
using System.Linq;

namespace JeuxTennisApi
{
    public class Set
    {
        public readonly List<Jeu> Jeux = new List<Jeu>();
        
        public Joueur Vainqueur { get; set; }

        public Joueur SetVainqueur()
        {
            int j1Gagner = Jeux.Count(jeu => jeu.GetVainqueur() == jeu.getJoueurById(1));
            int j2Gagner = Jeux.Count(jeu => jeu.GetVainqueur() == jeu.getJoueurById(2));

            int difference = Math.Abs(j1Gagner - j2Gagner);
            
            if (j1Gagner >= 6 && difference>= 2)
            {
                Vainqueur = Jeux.Last().getJoueurById(1);
                return Jeux.Last().getJoueurById(1);
            }

            if (j2Gagner >= 6 && difference >= 2)
            {
                Vainqueur = Jeux.Last().getJoueurById(2);
                return Jeux.Last().getJoueurById(2);
            }
            
            return null;
        }
    }
}