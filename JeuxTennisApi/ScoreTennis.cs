namespace JeuxTennisApi
{
    public class ScoreTennis : IScoreTennis
    {
        private int _joueur1Score;
        private int _joueur2Score;
        private int _setActuel;
        private int _jeuActuel;

        public ScoreTennis()
        {
            _joueur1Score = 0;
            _joueur2Score = 0;
            _setActuel = 1;
            _jeuActuel = 1;
        }

        public int Joueur1Score
        {
            get { return _joueur1Score; }
            set { _joueur1Score = value; }
        }

        public int Joueur2Score
        {
            get { return _joueur2Score; }
            set { _joueur2Score = value; }
        }

        public int SetActuel
        {
            get { return _setActuel; }
            set { _setActuel = value; }
        }

        public int JeuActuel
        {
            get { return _jeuActuel; }
            set { _jeuActuel = value; }
        }

        public void IncrementerJoueur1Score()
        {
            _joueur1Score++;
            if (_joueur1Score >= 4 && _joueur1Score - _joueur2Score >= 2)
            {
                _jeuActuel++;
                _joueur1Score = 0;
                _joueur2Score = 0;
                if (_jeuActuel >= 6 && _jeuActuel - _jeuActuel % 2 == 0)
                {
                    _setActuel++;
                    _jeuActuel = 1;
                }
            }
        }

        public void IncrementerJoueur2Score()
        {
            _joueur2Score++;
            if (_joueur2Score >= 4 && _joueur2Score - _joueur1Score >= 2)
            {
                _jeuActuel++;
                _joueur1Score = 0;
                _joueur2Score = 0;
                if (_jeuActuel >= 6 && _jeuActuel - _jeuActuel % 2 == 0)
                {
                    _setActuel++;
                    _jeuActuel = 1;
                }
            }
        }
    }
}