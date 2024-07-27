Feature: Jeu de Mastermind
En tant que joueur
Je veux jouer au Mastermind
Afin de m'amuser à deviner des codes secrets

    Background:
        Given le jeu est configuré avec une longueur de code de 4 et 6 couleurs

    Scenario: Générer un code secret
        When le code est généré
        Then le code devrait avoir 4 chiffres
        And chaque chiffre devrait être entre 0 et 5

    Scenario: Définir un code personnalisé
        When je définis le code "1234"
        Then le code secret devrait être "1234"

    Scenario: Définir un code personnalisé invalide
        When j'essaie de définir le code "1239"
        Then cela devrait lancer une ArgumentException

    Scenario: Vérifier une supposition correcte
        Given le code secret est "1234"
        When je devine "1234"
        Then le résultat devrait être 4 correspondances exactes et 0 correspondance de couleur

    Scenario: Vérifier une supposition partiellement correcte
        Given le code secret est "1234"
        When je devine "1243"
        Then le résultat devrait être 2 correspondances exactes et 2 correspondances de couleur

    Scenario: Vérifier une supposition sans correspondance
        Given le code secret est "1234"
        When je devine "5555"
        Then le résultat devrait être 0 correspondances exactes et 0 correspondances de couleur

    Scenario: Vérifier une supposition avec uniquement des correspondances de couleur
        Given le code secret est "1234"
        When je devine "4321"
        Then le résultat devrait être 0 correspondances exactes et 4 correspondances de couleur

    Scenario: Vérifier une supposition invalide (mauvaise longueur)
        Given le code secret est "1234"
        When j'essaie de définir le code "123"
        Then cela devrait lancer une ArgumentException