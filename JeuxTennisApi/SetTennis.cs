using System.Collections.Generic;

namespace JeuxTennisApi
{
    public class SetTennis
    {
        // Jouer Joureur qui a gagné le set
        public KeyValuePair<Joueur, JeuTennis> stat = new KeyValuePair<Joueur, JeuTennis>();

        public SetTennis(Joueur joueur, JeuTennis jeuTennis)
        {
            stat = new KeyValuePair<Joueur, JeuTennis>(joueur, jeuTennis);
        }
    }
}