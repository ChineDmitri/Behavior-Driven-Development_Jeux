using System;
using System.Collections.Generic;
using System.Linq;

namespace JeuxTennisApi
{
    public class Set
    {
        public readonly List<Jeu> Jeux = new List<Jeu>();

        public Joueur Vainqueur { get; set; }

        public TieBreak TieBreak { get; set; } = new TieBreak();

        public Joueur SetVainqueur()
        {
            if (!TieBreak.estTieBreak)
            {
                return processSimple();
            }

            return processTieBreak();
        }

        private Joueur processSimple()
        {
            int j1Gagner = Jeux.Count(jeu => jeu.GetVainqueur() == jeu.getJoueurById(1));
            int j2Gagner = Jeux.Count(jeu => jeu.GetVainqueur() == jeu.getJoueurById(2));

            int difference = Math.Abs(j1Gagner - j2Gagner);

            if (j1Gagner >= 6 && difference >= 2)
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

        private Joueur processTieBreak()
        {
            Joueur j1 = Jeux.Last().getJoueurById(1);
            Joueur j2 = Jeux.Last().getJoueurById(2);

            if ((j1.scoreTieBreak >= 7 || j2.scoreTieBreak >= 7) &&
                Math.Abs(j1.scoreTieBreak - j2.scoreTieBreak) >= 2)
            {
                Vainqueur = j1.scoreTieBreak > j2.scoreTieBreak ? j1 : j2;

                return Vainqueur;
            }

            return null;
        }
    }
}