Feature: ScoreTennisSpecFlowFeature

Feature: ScoreTennis

	Scenario: Incrementer le score du joueur 1
		Given le score initial du joueur 1 est 0
		When le joueur 1 marque un point
		Then le score du joueur 1 devrait être 15
		
	Scenario: Incrementer le score du joueur 2
		Given le score initial du joueur 2 est 0
		When le joueur 2 marque un point
		Then le score du joueur 2 devrait être 15