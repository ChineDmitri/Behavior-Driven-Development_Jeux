Feature: IHMJeuTennisLaunchAuto

    Background: Demmarer application et créer un match
        Given Je suis en "http://localhost:5144"
        When Je clique "Créer match" pour
          | Nom      | Prenom |
          | Chine    | Dmitri |
          | Medvedev | Daniil |
        Then Je dois avoir une vue "Match"
          | Joueur          | SETS PRÉCÉDENTS | Sets | Jeux | Points |
          | Chine Dmitri    | -               | 0    | 0    | 0      |
          | Medvedev Daniil | -               | 0    | 0    | 0      |

    Scenario: Chauqe joueur ont gagné un point
        Then Je dois avoir une vue "Match"
          | Joueur          | SETS PRÉCÉDENTS | Sets | Jeux | Points |
          | Chine Dmitri    | -               | 0    | 0    | 0      |
          | Medvedev Daniil | -               | 0    | 0    | 0      |
        When Je clique "Gagné point" pour
          | idJoueur |
          | 1        |
        And Je clique "Gagné point" pour
          | idJoueur |
          | 2        |
        Then Je dois avoir une vue "Match"
          | Joueur          | SETS PRÉCÉDENTS | Sets | Jeux | Points |
          | Chine Dmitri    | -               | 0    | 0    | 15     |
          | Medvedev Daniil | -               | 0    | 0    | 15     |