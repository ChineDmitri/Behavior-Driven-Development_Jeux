Feature: IHMJeuTennis

    Scenario: Demmarer application application
        Given Je suis en "http://localhost:5144"
        When Je clique "Créer match"
          | Nom      | Prenom |
          | Chine    | Dmitri |
          | Medvedev | Dmitri |
        Then Je dois avoir une page "Match"
          | Joueur          | SETS PRÉCÉDENTS | Sets | Jeux | Points |
          | Chine Dmitri    | -               | 0    | 0    | 0      |
          | Medvedev Dmitri | -               | 0    | 0    | 0      |