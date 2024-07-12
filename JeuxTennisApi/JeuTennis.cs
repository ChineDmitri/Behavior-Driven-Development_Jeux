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

            if (joueur.GetJeuScore() == 40 &&
                !jeu.Avantage.EstEgalite &&
                joueurs[0].GetJeuScore() != joueurs[1].GetJeuScore())
            {
                GagnerJeu(joueur);
            }

            if (joueurs[0].GetJeuScore() == 40 && joueurs[1].GetJeuScore() == 40)
            {
                jeu.Avantage.EstEgalite = true;
            }

            if (!jeu.Avantage.EstEgalite)
            {
                joueur.IncrementerJeuScore();
            }
            else
            {
                if (jeu.Avantage.Avantager == joueur)
                {
                    GagnerJeu(joueur);
                }

                if (jeu.Avantage.Avantager == null)
                {
                    jeu.Avantage.Avantager = joueur;
                }
                else
                {
                    jeu.Avantage.Avantager = null;
                }
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