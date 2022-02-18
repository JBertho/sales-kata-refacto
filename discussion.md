Ce qui est bien et pas bien ? 

Pas bien : 
- Liaison forte avec la classe Console
- Liaison forte avec la classe File
- Une fonction unique avec trop de comportement
- les noms de variables incompréhensible (number1, number2 , etcc)

Les structures possible du projet :
- Il semble qu'il existe 3 comportement très distinct :
  - Le print / le report / le mode erreur
  - On peut faire 2 stratégies pour ces différents comportements
  - -> Une stratégie pour le parsing de fichier
  - -> Une stratégie pout la génération des données pour faire l'affichage des informations
- Des modeles peuvent être créer pour mieux structurer le projet : 
  - Une colonne / Information de report

Pour les test :
- On peut garder les deux tests golden master de départ pour essayer les deux
comportement principaux
- Ajout d'un test pour le cas d'erreur
- Ajout de test supplémentaire dans le cas ou on doit passer dans certaines conditions non testés