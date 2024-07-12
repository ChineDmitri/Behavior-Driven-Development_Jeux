using System.Collections.Generic;
using System.Linq;

namespace JeuxTennisApi
{
    public class JeuTennis
    {
        public readonly List<Jeu> Jeux = new List<Jeu>();
        public readonly List<Set> Sets = new List<Set> { new Set(), new Set(), new Set() };
        private Joueur[] joueurs;

        public JeuTennis(Joueur[] joueurs)
        {
            this.joueurs = joueurs;

            Jeux.Add(new Jeu(joueurs));
        }

        private void NextJeu()
        {
            Jeux.Add(new Jeu(joueurs));
        }

        public Joueur GetJoueurById(int idJoueur)
        {
            return joueurs.First(joueur => joueur.Id == idJoueur);
        }

        public int GagnerPointJeu(int idJoueur)
        {
            Joueur joueur = Jeux.Last().getJoueurById(idJoueur);
            Jeu jeu = Jeux.Last();
            joueur.IncrementerJeuScore();
            
            if (joueur.GetJeuScore() == 40 && !jeu.EstEgalite)
            {
                GagnerJeu(joueur);
            }

            return joueur.GetJeuScore();
        }
        
        private void GagnerJeu(Joueur joueur)
        {
            Jeux.Last().SetVainqueur(joueur);
            foreach (Joueur j in joueurs)
            {
                j.ResetJeuScore();
            }

            NextJeu();
        }
    }
}