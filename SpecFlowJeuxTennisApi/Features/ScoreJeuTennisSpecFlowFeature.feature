Feature: ScoreJeuTennisSpecFlowFeature

	Scenario: Incrementer le score du joueur 1
		Given le score initial du joueur 1 est de 0
		When le joueur 1 marque un point
		Then le score du joueur 1 devrait être de 15
		
	Scenario: Incrementer le score du joueur 2
		Given le score initial du joueur 2 est de 15
		When le joueur 2 marque un point
		Then le score du joueur 2 devrait être de 30
		
	Scenario: Joueur 1 gagne un jeu
		Given le score initial du joueur 2 est de 30
		When le joueur 1 marque un point
		Then le joueur 1 gagne le jeu
		
	Scenario: Joueur 1 et joueur 2 ont un score de 40
		Given le score initial du joueur 2 est de 40
		And le score initial du joueur 1 est de 40
		When le joueur 1 marque un point
		Then le joueur 1 a l'avantage
	
	Scenario: Joueur 1 a l'avantage et marque un point
		Given le joueur 1 a l'avantage
		When le joueur 1 marque un point
		Then le joueur 1 gagne le jeu
		
	Scenario: Joueur 1 a l'avantage et joueur 2 marque un point
		Given le joueur 1 a l'avantage
		When le joueur 2 marque un point
		Then le score du joueur 1 devrait être de 40
		And le score du joueur 2 devrait être de 40