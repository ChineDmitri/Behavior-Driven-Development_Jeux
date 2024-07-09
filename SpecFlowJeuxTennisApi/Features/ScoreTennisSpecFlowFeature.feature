Feature: ScoreTennisSpecFlowFeature
	Simple calculator for adding two numbers

Feature: ScoreTennis

	Scenario: Incrementer le score du joueur 1
		Given le score initial du joueur 1 est 0
		When le joueur 1 marque un point
		Then le score du joueur 1 devrait être 1