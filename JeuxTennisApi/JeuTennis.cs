using System;
using System.Collections.Generic;
using System.Linq;

namespace JeuxTennisApi
{
    public class JeuTennis
    {
        // public readonly List<Jeu> Jeux = new List<Jeu>();
        public readonly List<Set> Sets = new List<Set> { new Set(), new Set(), new Set() };
        private Set setActuel;
        private Joueur[] joueurs;
        public Joueur vainqueurMatch;

        public JeuTennis(Joueur[] joueurs)
        {
            this.joueurs = joueurs;
            Sets[0] = setActuel = new Set();
            setActuel.Jeux.Add(new Jeu(joueurs));
        }

        private void NextJeu()
        {
            Jeu jeu = new Jeu(joueurs);
            setActuel.TieBreak.check(setActuel);

            setActuel.Jeux.Add(jeu);

            foreach (Joueur joueur in joueurs)
            {
                joueur.scoreTieBreak = 0;
            }
        }

        private void NextSet()
        {
            if (this.vainqueurMatch != null)
            {
                throw new ApplicationException("Le match est déjà fini vainqueur du match est " +
                                               this.vainqueurMatch.Nom +
                                               " " + this.vainqueurMatch.Prenom);
            }

            this.EstFinit();

            if (this.vainqueurMatch != null)
            {
                return;
            }


            if (vainqueurMatch != null)
            {
                this.vainqueurMatch = vainqueurMatch;
            }

            foreach (Joueur j in joueurs)
            {
                j.scoreTieBreak = 0;
            }

            int indexSetActuel = Sets.IndexOf(setActuel);
            // Sets.Add(setActuel = new Set());
            setActuel = Sets[indexSetActuel + 1];
            // NextJeu();
            // setActuel.Jeux.Add(new Jeu(joueurs));
        }

        public Joueur GetJoueurById(int idJoueur)
        {
            return joueurs.First(joueur => joueur.Id == idJoueur);
        }

        public int GagnerPointJeu(int idJoueur)
        {
            Joueur joueur = setActuel.Jeux.Last().getJoueurById(idJoueur);

            // if (setActuel.TieBreak.estTieBreak)
            // {
            //     joueur.scoreTieBreak++;
            //     
            //     if (joueurs.Count(j => j.scoreTieBreak >= 7) >= 2)
            //     {
            //         NextSet();
            //     }
            //     return joueur.scoreTieBreak;
            // }
            if (setActuel.TieBreak.estTieBreak)
            {
                joueur.scoreTieBreak++;

                Joueur estGagnant = setActuel.SetVainqueur();
                if (estGagnant != null)
                {
                    GagnerJeu(estGagnant);
                }
                
                return joueur.scoreTieBreak;
            }

            Jeu jeu = setActuel.Jeux.Last();


            if (joueur.GetJeuScore() == 40 &&
                !jeu.Avantage.EstEgalite &&
                joueurs[0].GetJeuScore() != joueurs[1].GetJeuScore())
            {
                GagnerJeu(joueur);

                return joueur.GetJeuScore();
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
            Jeu jeu = setActuel.Jeux.Last();

            jeu.SetVainqueur(joueur);
            foreach (Joueur j in joueurs)
            {
                j.ResetJeuScore();
            }


            if (setActuel.TieBreak.estTieBreak)
            {
                // joueur.scoreTieBreak++;
                // return joueur.scoreTieBreak;
            }

            Joueur vainqueur = setActuel.SetVainqueur();
            if (vainqueur != null)
            {
                NextSet();
            }

            NextJeu();
        }

        public Set getSetActuel()
        {
            return setActuel;
        }

        public void EstFinit()
        {
            int setAvecVainqueur = Sets.Count(set => set.Vainqueur != null);

            if (setAvecVainqueur >= 2)
            {
                int cj1 = Sets.Count(set => set.Vainqueur == joueurs[0]);
                int cj2 = Sets.Count(set => set.Vainqueur == joueurs[1]);

                if (cj1 == 2)
                {
                    this.vainqueurMatch = joueurs[0];
                }

                if (cj2 == 2)
                {
                    this.vainqueurMatch = joueurs[1];
                }
            }
        }
    }
}