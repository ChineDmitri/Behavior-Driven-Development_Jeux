# Jeux API

Ce repository contient l'implémentation des *API* pour les jeux et les spécifications *SpecFlow* avec Gherkin.

<img src="./assets/img/specflow.png" height="100" /> <img src="./assets/img/dotnet.jpeg" height="100" /><img src="./assets/img/aspnet.png" height="100" /> <img src="./assets/img/vuejs.png" height="75" /> 

## 📚 Jeux disponibles dans cette librairie :

| Jeu                            | API              | SpecFlow       |
|--------------------------------|------------------|------------------------------|
| 🕹️ TicTacToe (morpion)         | TicTacToeApi     | SpecFlowIHMTicTacToe         |
| 🎾 Partie de tennis (deux sets gagnants) | JeuxTennisApi    | SpecFlowIHMJeuxTennis        |
| 🎯 Fléchettes                  | FlechettesApi    | SpecFlowFlechettes           |
| 🔍 Mastermind                  | MastermindApi    | SpecFlowMastermind           |

## 🚀 Dotnet utilisé : 6.0

### 🛠️ Instructions d'installation

------------

#### 🎁 [Bonus]
Pour la démonstration de l'application, nous avons décidé d'utiliser une application web Single-page Application (VueJs + ASP.NET) utilisant JeuxTennisApi. En effet, dans l'équipe, nous avons des développeurs utilisant Linux et nous n'avons pas la possibilité d'utiliser certaines fonctionnalités de dotnet simple (comme WPF).

##### 🌐 Interface Homme-Machine (IHM) de Jeux Tennis
L'IHM de Jeux Tennis se trouve dans le projet Jeux-IHM et sa spécification est SpecFlowIHMJeuxTennis qui utilise Selenium.

##### ▶️ Pour lancer les tests :
1. Clonez le répository
```bash
git clone https://github.com/ChineDmitri/Behavior-Driven-Development_Jeux
cd Behavior-Driven-Development_Jeux
```

2. Démarrage de l'IHM dans une invite de commande :
```bash
cd Jeux-IHM
dotnet build
dotnet run
```

3. Exécution de la spécification dans une autre invite de commande :
```bash
cd SpecFlowIHMJeuxTennis 
dotnet build 
dotnet test SpecFlowIHMJeuxTennis.csproj ```
```

