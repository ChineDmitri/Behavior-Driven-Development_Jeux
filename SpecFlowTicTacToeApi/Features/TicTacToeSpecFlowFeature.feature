Feature: Jeu de TicTacToe
En tant que joueur
Je veux jouer au TicTacToe
Afin de m'amuser à jouer contre un autre joueur

    Background:
        Given le jeu est configuré avec un plateau de 3x3

    Scenario: Initialisation du jeu
        When le jeu est démarré
        Then le plateau devrait être vide
        And le joueur actuel devrait être [X]

    Scenario: Placement d'un pion
        When je place un pion X en position (1, 1)
        Then le plateau devrait contenir un pion X en position (1, 1)
        And le joueur actuel devrait être [O]

    Scenario: Placement d'un pion en position occupée
        Given je place un pion X en position (1, 1)
        When j'essaie de placer un pion O en position (1, 1)
        Then cela devrait lancer une ArgumentException

    Scenario: Vérification de la victoire
        Given je place un pion X en position (1, 1)
        And je place un pion X en position (2, 1)
        And je place un pion X en position (3, 1)
        When je vérifie la victoire
        Then le joueur X devrait gagner

    Scenario: Vérification de l'égalité
        Given je place un pion X en position (1, 1)
        And je place un pion O en position (2, 1)
        And je place un pion X en position (3, 1)
        And je place un pion O en position (1, 2)
        And je place un pion X en position (2, 2)
        And je place un pion O en position (3, 2)
        And je place un pion X en position (1, 3)
        And je place un pion O en position (2, 3)
        And je place un pion X en position (3, 3)
        When je vérifie la victoire
        Then la partie devrait être égale

    Scenario: Vérification de la défaite
        Given je place un pion O en position (1, 1)
        And je place un pion O en position (2, 1)
        And je place un pion O en position (3, 1)
        When je vérifie la victoire
        Then le joueur O devrait gagner