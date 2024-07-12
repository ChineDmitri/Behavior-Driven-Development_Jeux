Feature: ScoreJeuTennisSpecFlowFeature

    Scenario: Incrementer le score du joueur 1
        Given le score initial du joueur 1 est de 0
        When le joueur 1 marque un point
        Then le score du joueur 1 devrait être de 15

    Scenario: Incrementer le score du joueur 2
        Given le score initial du joueur 2 est de 15
        When le joueur 2 marque un point
        Then le score du joueur 2 devrait être de 30
        
    Scenario: Jeu gagne sans égalité
        Given le score initial du joueur 2 est de 40
        When le joueur 2 marque un point
        Then le joueur 2 gagne le jeu

    Scenario: Joueur 1 et joueur 2 ont un score de 40
        Given les scores initial des joueurs 2 et 1 est de 40
        When le joueur 1 marque un point
        Then le joueur 1 a l'avantage
        
    Scenario: Joueur 1 gagne un jeu quand c'est égalité
        Given les scores initial des joueurs 2 et 1 est de 40
        When le joueur 2 marque un point
        And le joueur 2 marque un point
        Then le joueur 2 gagne le jeu

    Scenario: Joueur 1 a l'avantage et marque un point
        Given les scores initial des joueurs 2 et 1 est de 40
        When le joueur 1 marque un point
        And le joueur 1 a l'avantage
        And le joueur 1 marque un point
        Then le joueur 1 gagne le jeu

    Scenario: Joueurs ont l'avantage et joueur 2 marque un point et joueur 1 marque un point
        Given les scores initial des joueurs 2 et 1 est de 40
        When le joueur 1 marque un point
        And le joueur 1 a l'avantage
        And le joueur 2 marque un point
        Then le jeux est en égalité et jeurs n'ont pas l'avantage