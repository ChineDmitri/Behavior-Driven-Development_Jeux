Feature: ScoreSetTennisSpecFlowFeature

    Scenario: Jouer gagne premier set
        Given Scone initial du set pour Joueur 1 est 4 et Joueur 2 est 5
        And dans un set le score initial du joueur 1 est de 15
        And dans un set le score initial du joueur 2 est de 40
        When dans un set le joueur 2 marque un point
        Then le set a gagné le joueur 2