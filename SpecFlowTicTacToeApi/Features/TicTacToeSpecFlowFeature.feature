Feature: Jeu de Flechettes

    Scenario: Initialisation du jeu
        When le jeu est démarré
        Then le score de chaque joueur devrait être de 301
        And le joueur actuel devrait être le joueur 1

    Scenario: Lancer une fléchette
        When je lance une fléchette qui atteint la zone 20
        Then le score du joueur actuel devrait être diminué de 20
        And le joueur actuel devrait rester le même

    Scenario: Lancer une fléchette qui atteint la zone double
        When je lance une fléchette qui atteint la zone double 20
        Then le score du joueur actuel devrait être diminué de 40
        And le joueur actuel devrait rester le même

    Scenario: Lancer une fléchette qui atteint la zone triple
        When je lance une fléchette qui atteint la zone triple 20
        Then le score du joueur actuel devrait être diminué de 60
        And le joueur actuel devrait rester le même

    Scenario: Lancer une fléchette qui atteint le centre
        When je lance une fléchette qui atteint le centre
        Then le score du joueur actuel devrait être diminué de 50
        And le joueur actuel devrait rester le même

    Scenario: Changer de joueur
        When je termine mon tour
        Then le joueur actuel devrait être le joueur 2

    Scenario: Vérification de la victoire
        Given le score du joueur 1 est de 0
        When je vérifie la victoire
        Then le joueur 1 devrait gagner

    Scenario: Vérification de l'égalité
        Given le score du joueur 1 est de 0
        And le score du joueur 2 est de 0
        When je vérifie la victoire
        Then la partie devrait être égale