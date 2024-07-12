using System;
using System.Linq;

namespace JeuxTennisApi
{
    public class Jeu
    {
        public static readonly int[] POINTS = { 0, 15, 30, 40 };
        private Joueur[] joueurs;
        private Joueur vainqueur;
        public bool EstEgalite { get; private set; } = false;
        
        public Jeu(Joueur[] joueurs)
        {
            this.joueurs = joueurs;
            vainqueur = null;
        }
        
        public Joueur getJoueurById(int idJoueur)
        {
            return joueurs.First(joueur => joueur.Id == idJoueur);
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