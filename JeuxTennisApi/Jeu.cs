using System;
using System.Linq;

namespace JeuxTennisApi
{
    public class Jeu
    {
        public static readonly int[] POINTS = { 0, 15, 30, 40 };
        public Joueur[] joueurs { get; }
        public Joueur vainqueur { get; private set; }
        public Avantage Avantage { get; set; } = new Avantage();


        public Jeu(Joueur[] joueurs)
        {
            this.joueurs = joueurs;
            vainqueur = null;
        }

        public Joueur getJoueurById(int idJoueur)
        {
            return joueurs.First(joueur => joueur.Id == idJoueur);
        }

        public Joueur[] getAllJoueurs()
        {
            return joueurs;
        }

        public void SetVainqueur(Joueur joueur)
        {
            vainqueur = joueur;
        }

        public Joueur GetVainqueur()
        {
            if (vainqueur != null)
            {
                return vainqueur;
            }

            throw new InvalidOperationException("Le jeu n'est pas encore terminé");
        }
    }
}