using System;
using System.Collections.Generic;

namespace JeuxTennisApi
{
    public class ScoreTennis
    {
        public Joueur[] Joueurs;
        public SetTennis[] Sets;
        public SetTennis SetActuel { get; private set; }
        public JeuTennis JeuActuel { get; private set; }


        public ScoreTennis(Joueur[] joueurs)
        {
            if (joueurs.Length != 2)
            {
                throw new ArgumentException("Il doit y avoir exactement deux joueurs.");
            }

            Joueurs = joueurs;
            Sets = new SetTennis[3];
        }

        public Joueur GetJouerParId(int joueurId)
        {
            if (joueurId < 1 || joueurId > 2)
            {
                throw new ArgumentException("JoueurId invalide.");
            }

            return Joueurs[joueurId - 1];
        }

        public void IncrementerJoueurScoreJeuParId(int joueurId)
        {
            if (joueurId > 2 || joueurId < 1)
            {
                throw new ArgumentException("JoueurId invalide.");
            }

            int index = joueurId - 1;
            Joueurs[index].IncrementerScore();

            if (Joueurs[index].ScoreJeu == 0 && Joueurs[0].ScoreJeu != Joueurs[1].ScoreJeu) // Joueur a gagné la partie
            {
                // _jeuActuel++;
                // Gérer la logique de set et de match ici
            }
        }
    }
}