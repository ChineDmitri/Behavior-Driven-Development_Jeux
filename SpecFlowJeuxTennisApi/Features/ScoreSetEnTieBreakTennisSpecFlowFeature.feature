Feature: ScoreSetEnTieBreakTennisSpecFlowFeature

    Background:
        Given Scone initial du set pour Joueur 2 est 6 et Joueur 1 est 5
        And dans un set le score du jeu initial du joueur 1 est de 15
        And dans un set le score du jeu initial du joueur 2 est de 40
        When dans un set le joueur 2 marque un point
        Then le set est en tie break
        And le score de jouer 1 en tie break est 0
        And le score de jouer 2 en tie break est 0

    Scenario: Gagner point en tie break
        Given le set est en tie break
        When dans un set le joueur 2 marque un point
        Then le score de jouer 2 en tie break est 1
        And le score de jouer 1 en tie break est 0

    Scenario: Gagner set en tie break à sec
        Given le set est en tie break
        When dans un set le joueur 1 marque 7 points
        Then le set a gagné le joueur 1
       
    Scenario: Gagner set en tie break avec difference de deux points
        Given le set est en tie break
        When dans un set le joueur 1 marque 6 points
        And dans un set le joueur 2 marque 6 points
        And dans un set le joueur 1 marque 2 points
        Then le set a gagné le joueur 1